using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	public partial class CollectionViewTests : ControlsHandlerTestBase
	{
		[Fact]
		public async Task PushAndPopPageWithCollectionView()
		{
			NavigationPage rootPage = new NavigationPage(new ContentPage());
			ContentPage modalPage = new ContentPage();

			var collectionView = new CollectionView
			{
				ItemsSource = new string[]
				{
				  "Item 1",
				  "Item 2",
				  "Item 3",
				}
			};

			modalPage.Content = collectionView;

			SetupBuilder();

			await CreateHandlerAndAddToWindow<IWindowHandler>(rootPage,
				async (_) =>
				{
					var currentPage = (rootPage as IPageContainer<Page>).CurrentPage;

					await currentPage.Navigation.PushModalAsync(modalPage);
					await OnLoadedAsync(modalPage);

					await currentPage.Navigation.PopModalAsync();
					await OnUnloadedAsync(modalPage);

					// Navigate a second time
					await currentPage.Navigation.PushModalAsync(modalPage);
					await OnLoadedAsync(modalPage);

					await currentPage.Navigation.PopModalAsync();
					await OnUnloadedAsync(modalPage);
				});


			// Without Exceptions here, the test has passed.
			Assert.Empty((rootPage as IPageContainer<Page>).CurrentPage.Navigation.ModalStack);
		}

		[Fact]
		public async Task NullItemsSourceDisplaysHeaderFooterAndEmptyView()
		{
			SetupBuilder();

			var emptyView = new Label { Text = "Empty" };
			var header = new Label { Text = "Header" };
			var footer = new Label { Text = "Footer" };

			var collectionView = new CollectionView
			{
				ItemsSource = null,
				EmptyView = emptyView,
				Header = header,
				Footer = footer
			};

			ContentPage contentPage = new ContentPage() { Content = collectionView };

			var frame = collectionView.Frame;

			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage,
				async (_) =>
				{
					await WaitForUIUpdate(frame, collectionView);

					Assert.True(emptyView.Height > 0, "EmptyView should be arranged");
					Assert.True(header.Height > 0, "Header should be arranged");
					Assert.True(footer.Height > 0, "Footer should be arranged");
				});
		}

		[Fact(DisplayName = "CollectionView with SnapPointsType set should not crash")]
		public async Task SnapPointsDoNotCrashOnOlderAPIs()
		{
			SetupBuilder();

			var collectionView = new CollectionView();
			var itemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical)
			{
				SnapPointsType = SnapPointsType.Mandatory
			};
			collectionView.ItemsLayout = itemsLayout;
			
			collectionView.ItemsSource = new string[]
			{
				"Item 1",
				"Item 2",
				"Item 3",
			};

			ContentPage contentPage = new ContentPage() { Content = collectionView };

			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(100);				
			});
			
			Assert.NotNull(collectionView.Handler);
		}

		[Fact(DisplayName = "ObservableCollection modifications are reflected after UI thread processes them")]
		public async Task ObservableSourceItemsCountConsistent()
		{
			SetupBuilder();
			
			var source = new ObservableCollection<string>
			{
				"Item 1",
				"Item 2"
			};

			var collectionView = new CollectionView
			{
				ItemsSource = source
			};
			
			ContentPage contentPage = new ContentPage() { Content = collectionView };
			
			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(100);
				
				Assert.Equal(2, collectionView.ItemsSource.Cast<object>().Count());				
				await Task.Run(() => source.Add("Item 3"));
				
				await Task.Delay(100);	

				Assert.Equal(3, collectionView.ItemsSource.Cast<object>().Count());
			});
			
			Assert.NotNull(collectionView.Handler);
		}

		[Fact(DisplayName = "Adding items is reflected after UI thread processes them")]
		public async Task AddItemCountConsistentOnUIThread()
		{
			SetupBuilder();
			
			var source = new ObservableCollection<string>();
			
			var collectionView = new CollectionView
			{
				ItemsSource = source
			};
			
			ContentPage contentPage = new ContentPage() { Content = collectionView };
			
			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(100);
				
				Assert.Empty(collectionView.ItemsSource.Cast<object>());
				
				var backgroundTask = Task.Run(() => source.Add("New Item"));

				await backgroundTask;
				
				await Task.Delay(100);
				
				Assert.Single(collectionView.ItemsSource.Cast<object>());
			});
		}

		[Fact(DisplayName = "Removing items is reflected after UI thread processes them")]
		public async Task RemoveItemCountConsistentOnUIThread()
		{
			SetupBuilder();
			
			var source = new ObservableCollection<string> { "Item to remove" };
			
			var collectionView = new CollectionView
			{
				ItemsSource = source
			};
			
			ContentPage contentPage = new ContentPage() { Content = collectionView };
			
			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(100);
				
				Assert.Single(collectionView.ItemsSource.Cast<object>());
				
				await Task.Run(() => source.RemoveAt(0));
				
				await Task.Delay(100);
				
				Assert.Empty(collectionView.ItemsSource.Cast<object>());
			});
		}

		[Fact(DisplayName = "Item positions are updated after UI thread processes changes")]
		public async Task GetPositionConsistentOnUIThread()
		{
			SetupBuilder();
			
			var source = new ObservableCollection<string> 
			{ 
				"one", 
				"two" 
			};
			
			var collectionView = new CollectionView
			{
				ItemsSource = source
			};
			
			ContentPage contentPage = new ContentPage() { Content = collectionView };
			
			await CreateHandlerAndAddToWindow<IWindowHandler>(contentPage, async (_) =>
			{
				await Task.Delay(100);
				
				Assert.Equal(0, ((ObservableCollection<string>)collectionView.ItemsSource).IndexOf("one"));
				
				await Task.Run(() => source.Insert(0, "zero"));
				
				await Task.Delay(100);
				
				Assert.Equal(1, ((ObservableCollection<string>)collectionView.ItemsSource).IndexOf("one"));
				Assert.Equal(0, ((ObservableCollection<string>)collectionView.ItemsSource).IndexOf("zero"));
			});
		}

		Rect GetCollectionViewCellBounds(IView cellContent)
		{
			if (!cellContent.ToPlatform().IsLoaded())
			{
				throw new System.Exception("The cell is not in the visual tree");
			}

			return cellContent.ToPlatform().GetParentOfType<ItemContentView>().GetBoundingBox();
		}
	}
}