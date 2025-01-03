#if IOS
using Microsoft.Maui.Handlers;
using UIKit;
using Foundation;
using CoreGraphics;
namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 21177, "Using a UICollectionView in a ViewRenderer results in issues with selection")]
	public class Bugzilla21177 : TestContentPage
	{
		public class CollectionView : View
		{
			public event EventHandler<int> ItemSelected;
			public void InvokeItemSelected(int index)
			{
				ItemSelected?.Invoke(this, index);
			}
		}
		protected override void Init()
		{
			var view = new CollectionView() { AutomationId = "view" };
			view.ItemSelected += View_ItemSelected;
			Content = view;
		}
		private void View_ItemSelected(object sender, int e)
		{
			DisplayAlert("Success", "Success", "Cancel");
		}
	}
	public class CustomCollectionViewHandler : ViewHandler<Bugzilla21177.CollectionView, UICollectionView>
	{
		public static IPropertyMapper<Bugzilla21177.CollectionView, CustomCollectionViewHandler> Mapper = new PropertyMapper<Bugzilla21177.CollectionView, CustomCollectionViewHandler>(ViewHandler.ViewMapper);

		UICollectionView uiCollectionView;
		CollectionViewController _controller;
		public CustomCollectionViewHandler() : base(Mapper)
		{

		}
		protected override UICollectionView CreatePlatformView()
		{
			var flowLayout = new UICollectionViewFlowLayout
			{
				SectionInset = new UIEdgeInsets(20, 20, 20, 20),
				ScrollDirection = UICollectionViewScrollDirection.Vertical,
				MinimumInteritemSpacing = 10,
				MinimumLineSpacing = 10,
				ItemSize = new CGSize(80, 80)
			};
			_controller = new CollectionViewController(flowLayout, ItemSelected);
			uiCollectionView = _controller.CollectionView;
			return uiCollectionView;
		}
		public void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			VirtualView.InvokeItemSelected(indexPath.Row);
				
		}
		protected override void ConnectHandler(UICollectionView platformView)
		{
			base.ConnectHandler(platformView);
			_controller.ViewDidLoad(); 
		}
		protected override void DisconnectHandler(UICollectionView platformView)
		{
			if (platformView != null)
			{
				_controller = null;
			}
			base.DisconnectHandler(platformView);
		}
	}
	public class CollectionViewController : UICollectionViewController
	{
		readonly OnItemSelected _onItemSelected;
		static NSString cellId = new NSString("CollectionViewCell");
		List<string> items;
		public delegate void OnItemSelected(UICollectionView collectionView, NSIndexPath indexPath);
		public CollectionViewController(UICollectionViewLayout layout, OnItemSelected onItemSelected) : base(layout)
		{
			items = new List<string>();
			items = Enumerable.Range(0, 20).Select(i => $"#{i}").ToList();
			_onItemSelected = onItemSelected;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			CollectionView.RegisterClassForCell(typeof(CollectionViewCell), cellId);
		}
		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}
		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return items.Count;
		}
		public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (CollectionViewCell)collectionView.DequeueReusableCell(cellId, indexPath);
			cell.Label.Text = items[indexPath.Row];
			return cell;
		}
		public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
		{
			_onItemSelected(collectionView, indexPath);   
		}
	}
	public class CollectionViewCell : UICollectionViewCell
	{
		public UILabel Label { get; private set; }
		[Export("initWithFrame:")]
		public CollectionViewCell(CGRect frame) : base(frame)
		{
			var rand = new Random();
			BackgroundView = new UIView
			{
				BackgroundColor = UIColor.FromRGB(
					rand.Next(0, 256),
					rand.Next(0, 256),
					rand.Next(0, 256))
			};
			SelectedBackgroundView = new UIView
			{
				BackgroundColor = UIColor.Green
			};
			ContentView.Layer.BorderColor = UIColor.LightGray.CGColor;
			ContentView.Layer.BorderWidth = 2.0f;
			Label = new UILabel(frame);      
			Label.Center = ContentView.Center;
			ContentView.AddSubview(Label);
		}       
	}
}
#endif