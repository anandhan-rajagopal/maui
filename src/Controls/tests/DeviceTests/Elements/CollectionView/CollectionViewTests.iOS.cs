using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
using Xunit;
using Xunit.Sdk;

namespace Microsoft.Maui.DeviceTests
{
	public partial class CollectionViewTests
	{
		[Fact]
		public async Task ItemsSourceGroupedClearDoestCrash()
		{
			SetupBuilder();

			var data = new List<string> { "test 1", "test 2", "test 3" };
			var groupData = new ObservableCollection<CollectionViewStringGroup>
				{
					new ("Header 1", data),
					new ("Header 2", data),
					new ("Header 3", data)
				};

			var collectionView = new CollectionView
			{
				IsGrouped = true,
				ItemsSource = groupData,
				ItemTemplate = new DataTemplate(() => new Label())
			};

			await CreateHandlerAndAddToWindow<CollectionViewHandler>(collectionView, async handler =>
			{
				await Task.Delay(1000);
				groupData.Clear();
				groupData.Add(new("Header 1", new string[] { "oi" }));
			});
		}

		class CollectionViewStringGroup : List<string>
		{
			public string GroupHeader { get; private set; }
			public CollectionViewStringGroup(string header, IEnumerable<string> data) : base(data)
			{
				GroupHeader = header;
			}
		}

		[Fact]
		public async Task CollectionViewContentRespectsMargin()
		{
			SetupBuilder();

			// We'll use an EmptyView to assess whether the CollectionView's content 
			// is being properly offset by the margin
			var emptyView = new VerticalStackLayout();
			var emptyViewContent = new Label { Text = "test" };
			emptyView.Add(emptyViewContent);

			double margin = 2;

			var collectionView = new CollectionView
			{
				Margin = new Thickness(margin),
				EmptyView = emptyView,
			};

			var frame = collectionView.Frame;

			await CreateHandlerAndAddToWindow<CollectionViewHandler>(collectionView, async handler =>
			{
				await WaitForUIUpdate(frame, collectionView);

				if (emptyViewContent.Handler.PlatformView is not UIView nativeLabel)
				{
					throw new XunitException("EmptyView Content is not a UIView");
				}

				var point = new CGPoint(nativeLabel.Frame.Left, nativeLabel.Frame.Top);

				// Convert the local point to an absolute point in the window 
				var absPoint = nativeLabel.ConvertPointToView(point, null);

				Assert.Equal(margin, absPoint.X);
			});
		}

		[Fact("Cells Do Not Leak")]
		public async Task CellsDoNotLeak()
		{
			SetupBuilder();

			var labels = new List<WeakReference>();
			VerticalCell cell = null;

			{
				var bindingContext = "foo";
				var collectionView = new MyUserControl
				{
					Labels = labels
				};
				collectionView.ItemTemplate = new DataTemplate(collectionView.LoadDataTemplate);

				var handler = await CreateHandlerAsync(collectionView);

				await InvokeOnMainThreadAsync(() =>
				{
					cell = new VerticalCell(CGRect.Empty);
					cell.Bind(collectionView.ItemTemplate, bindingContext, collectionView);
				});

				Assert.NotNull(cell);
			}

			// HACK: test passes running individually, but fails when running entire suite.
			// Skip the assertion on Catalyst for now.
#if !MACCATALYST
			await AssertionExtensions.WaitForGC(labels.ToArray());
#endif
		}

		/// <summary>
		/// Simulates what a developer might do with a Page/View
		/// </summary>
		class MyUserControl : CollectionView
		{
			public List<WeakReference> Labels { get; set; }

			/// <summary>
			/// Used for reproducing a leak w/ instance methods on ItemsView.ItemTemplate
			/// </summary>
			public object LoadDataTemplate()
			{
				var label = new Label();
				Labels.Add(new(label));
				return label;
			}
		}

		[Fact(DisplayName = "IndexPath Range Generation Is Correct")]
		public async Task GenerateIndexPathRange()
		{
			SetupBuilder();
			
			var result = await InvokeOnMainThreadAsync(() => 
        			IndexPathHelpers.GenerateIndexPathRange(0, 0, 5));
			
			Assert.Equal(5, result.Length);
			
			Assert.Equal(0, result[0].Section);
			Assert.Equal(0, (int)result[0].Item);
			
			Assert.Equal(0, result[4].Section);
			Assert.Equal(4, (int)result[4].Item);
		}

		[Fact(DisplayName = "IndexPath Range Generation For Loops Is Correct")]
		public async Task GenerateIndexPathRangeForLoop()
		{
			SetupBuilder();
			
			var result = await InvokeOnMainThreadAsync(() => 
					IndexPathHelpers.GenerateLoopedIndexPathRange(0, 15, 3, 2, 3));
			
			Assert.Equal(9, result.Length);
			
			for (int i = 0; i < result.Length; i++)
			{
				Assert.Equal(0, result[i].Section);
			}
			
			Assert.Equal(2, (int)result[0].Item);
			Assert.Equal(3, (int)result[1].Item);
			Assert.Equal(4, (int)result[2].Item);
			
			Assert.Equal(7, (int)result[3].Item);
			Assert.Equal(8, (int)result[4].Item);
			Assert.Equal(9, (int)result[5].Item);
			
			Assert.Equal(12, (int)result[6].Item);
			Assert.Equal(13, (int)result[7].Item);
			Assert.Equal(14, (int)result[8].Item);
		}

		[Fact(DisplayName = "IndexPath Validity Check Is Correct")]
		public async Task IndexPathValidTest()
		{
			SetupBuilder();

			var list = new List<string> { "one", "two", "three" };
			var collectionView = new CollectionView
			{
				ItemsSource = list,
				ItemTemplate = new DataTemplate(() => new Label{})
			};

			var contentPage = new ContentPage { Content = collectionView };

			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(1000);

				await InvokeOnMainThreadAsync(() =>
				{
					Assert.NotNull(collectionView.Handler);

					var validPath = NSIndexPath.FromItemSection(2, 0);
					var invalidItemPath = NSIndexPath.FromItemSection(7, 0);
					var invalidSectionPath = NSIndexPath.FromItemSection(1, 9);
					
					var source = new ListSource((IEnumerable<object>)list);
					
					Assert.True(IndexPathHelpers.IsIndexPathValid(source, validPath));
					Assert.False(IndexPathHelpers.IsIndexPathValid(source, invalidItemPath));
					Assert.False(IndexPathHelpers.IsIndexPathValid(source, invalidSectionPath)); 
				});
			});
		}
		 
		Rect GetCollectionViewCellBounds(IView cellContent)
		{
			if (!cellContent.ToPlatform().IsLoaded())
			{
				throw new System.Exception("The cell is not in the visual tree");
			}

			return cellContent.ToPlatform().GetParentOfType<UIKit.UICollectionViewCell>().GetBoundingBox();
		}
	}
}