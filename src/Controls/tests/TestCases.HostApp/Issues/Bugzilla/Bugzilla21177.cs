using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls;
#if IOS || MACCATALYST
using UIKit;
using Foundation;
using CoreGraphics;
#elif ANDROID
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Android.Widget;
#endif
namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Bugzilla, 21177, "Using a UICollectionView in a ViewRenderer results in issues with selection")]
	public class Bugzilla21177 : TestContentPage
	{
		public class CollectionView : Microsoft.Maui.Controls.View
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
#if IOS || MACCATALYST
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
#endif

#if ANDROID
    public class CustomCollectionViewHandler : ViewHandler<Bugzilla21177.CollectionView, RecyclerView>
    {
        public static IPropertyMapper<Bugzilla21177.CollectionView, CustomCollectionViewHandler> Mapper = 
            new PropertyMapper<Bugzilla21177.CollectionView, CustomCollectionViewHandler>(ViewHandler.ViewMapper);

        private CollectionAdapter _adapter;
        private RecyclerView _recyclerView;

        public CustomCollectionViewHandler() : base(Mapper)
        {
        }

        protected override RecyclerView CreatePlatformView()
        {
            _recyclerView = new RecyclerView(Context);
            _recyclerView.SetLayoutManager(new GridLayoutManager(Context, 3));
            
            _adapter = new CollectionAdapter(Context, ItemSelected);
            _recyclerView.SetAdapter(_adapter);

            return _recyclerView;
        }

        private void ItemSelected(int position)
        {
            VirtualView.InvokeItemSelected(position);
        }

        protected override void ConnectHandler(RecyclerView platformView)
        {
            base.ConnectHandler(platformView);
            _adapter.NotifyDataSetChanged();
        }

        protected override void DisconnectHandler(RecyclerView platformView)
        {
            if (platformView != null)
            {
                _adapter?.Dispose();
                _adapter = null;
            }
            base.DisconnectHandler(platformView);
        }
    }

    public class CollectionAdapter : RecyclerView.Adapter
    {
        private List<string> _items;
        private Android.Content.Context _context;
        private Action<int> _onItemSelected;
        private Random _random;

        public CollectionAdapter(Android.Content.Context context, Action<int> onItemSelected)
        {
            _context = context;
            _onItemSelected = onItemSelected;
            _random = new Random();
            _items = Enumerable.Range(0, 20).Select(i => $"#{i}").ToList();
        }

        public override int ItemCount => _items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as CollectionViewHolder;
            viewHolder.Label.Text = _items[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Create TextView programmatically
            var textView = new TextView(_context)
            {
                Gravity = GravityFlags.Center,
                TextSize = 16
            };

            // Create FrameLayout to hold the TextView
            var frameLayout = new FrameLayout(_context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                    240, // 80dp * density
                    240  // 80dp * density
                )
            };

            // Add padding/margin
            frameLayout.SetPadding(30, 30, 30, 30);

            // Add TextView to FrameLayout
            frameLayout.AddView(textView);

            return new CollectionViewHolder(frameLayout, textView, OnClick);
        }

        private void OnClick(int position)
        {
            _onItemSelected?.Invoke(position);
        }
    }

    public class CollectionViewHolder : RecyclerView.ViewHolder
    {
        public TextView Label { get; private set; }

        public CollectionViewHolder(Android.Views.View itemView, TextView label, Action<int> onClick) : base(itemView)
        {
            Label = label;
            
            // Create a random background color
            var random = new Random();
            var backgroundColor = new Android.Graphics.Color(
                random.Next(256),
                random.Next(256),
                random.Next(256));

            // Create a shape drawable for the background with border
            var shape = new Android.Graphics.Drawables.GradientDrawable();
            shape.SetColor(backgroundColor);
            shape.SetStroke(6, Android.Graphics.Color.LightGray); // 2dp border width
            shape.SetCornerRadius(8); // Optional: rounded corners

            // Set the background drawable
            itemView.Background = shape;

            // Handle click events
            itemView.Click += (sender, e) => onClick(AdapterPosition);
        }
    }
#endif
}