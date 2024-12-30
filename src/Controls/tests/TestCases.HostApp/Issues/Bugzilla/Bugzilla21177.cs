#if IOS
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
using Foundation;
using CoreGraphics;
using Microsoft.Maui;
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
				if (ItemSelected != null)                
				{                    
					ItemSelected.Invoke(this, index);                
				}            
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
		public CustomCollectionViewHandler() : base(Mapper)        
		{        
		}
		UICollectionView uiCollectionView;        
		protected override UICollectionView CreatePlatformView()        
		{            
			var flowLayout = new UICollectionViewFlowLayout            
			{                
				ScrollDirection = UICollectionViewScrollDirection.Vertical,                
				MinimumInteritemSpacing = 0,                
				MinimumLineSpacing = 0            
			};            
			uiCollectionView = new UICollectionView(CGRect.Empty, flowLayout);  
			return uiCollectionView;        
		}        
		protected override void ConnectHandler(UICollectionView platformView)        
		{            
			base.ConnectHandler(platformView);                    
			platformView.RegisterClassForCell(typeof(UICollectionViewCell), "Cell");            
			platformView.Delegate = new CollectionViewDelegate(VirtualView);            
			platformView.DataSource = new CollectionViewDataSource();        
		}        
		protected override void DisconnectHandler(UICollectionView platformView)        
		{            
			if (platformView != null)            
			{                
				platformView.Delegate = null;                
				platformView.DataSource = null;            
			}            
			base.DisconnectHandler(platformView);       
		}        
		private class CollectionViewDelegate : UICollectionViewDelegate        
		{            
			private readonly Bugzilla21177.CollectionView _virtualView;            
			public CollectionViewDelegate(Bugzilla21177.CollectionView virtualView)            
			{                
				_virtualView = virtualView;            
			}            
			public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)            
			{                
				_virtualView.InvokeItemSelected(indexPath.Row);            
			}        
		}        
		private class CollectionViewDataSource : UICollectionViewDataSource        
		{            
			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)            
			{                
				var cell = (UICollectionViewCell)collectionView.DequeueReusableCell("Cell", indexPath);  
				cell.AccessibilityIdentifier = (indexPath.Row + 1).ToString();             
				return cell;            
			}            
			public override nint GetItemsCount(UICollectionView collectionView, nint section)            
			{                
				return 10;           
			}        
		}    
	}
}
#endif