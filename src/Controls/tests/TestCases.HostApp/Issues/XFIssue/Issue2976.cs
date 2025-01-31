using Microsoft.Maui.Handlers;
using TextAlignment = Microsoft.Maui.TextAlignment;
using View = Microsoft.Maui.Controls.View;
#if IOS || MACCATALYST
using UIKit;
using Foundation;
#elif ANDROID
using Android.Views;
using Android.Widget;
using Android.Content;
#endif

namespace Maui.Controls.Sample.Issues;


[Issue(IssueTracker.Github, 2976, "Sample 'WorkingWithListviewNative' throw Exception on Xam.Android project.", PlatformAffected.Android)]
public class Issue2976 : TestTabbedPage
{
	protected override void Init()
	{

		// built-in Xamarin.Forms controls
		Children.Add(new XamarinFormsPage { Title = "DEMOA", IconImageSource = "bank.png" });

		// custom renderer for the list, using a native built-in cell type
		Children.Add(new NativeListPage { Title = "DEMOB", IconImageSource = "bank.png" });

		// built in Xamarin.Forms list, but with a native cell custom-renderer
		Children.Add(new XamarinFormsNativeCellPage { Title = "DEMOC", IconImageSource = "bank.png" });

		// custom renderer for the list, using a native cell that has been custom-defined in native code
		Children.Add(new NativeListViewPage2 { Title = "DEMOD", IconImageSource = "bank.png" });
	}
}

/// <summary>
/// This page uses a custom renderer that wraps native list controls:
///    iOS :           UITableView
///    Android :       ListView   (do not confuse with Xamarin.Forms ListView)
///    Windows Phone : ?
/// 
/// It uses a built-in row/cell class provided by the native platform
/// and is therefore faster than building a custom ViewCell in Microsoft.Maui.Controls.
/// </summary>

public class NativeListPage : ContentPage
{
	public NativeListPage()
	{
		var tableItems = new List<string>();
		for (var i = 0; i < 100; i++)
		{
			tableItems.Add(i + " row ");
		}


		var fasterListView = new NativeListView(); // CUSTOM RENDERER using a native control
#pragma warning disable CS0618 // Type or member is obsolete
		fasterListView.VerticalOptions = LayoutOptions.FillAndExpand; // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.
#pragma warning restore CS0618 // Type or member is obsolete
		fasterListView.Items = tableItems;
		fasterListView.ItemSelected += async (sender, e) =>
		{
			await Navigation.PushModalAsync(new DetailPage(e.SelectedItem));
		};

		// The root page of your application
		Content = new StackLayout
		{
			Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(0, 20, 0, 0) : new Thickness(0),
			Children = {
				new Label {
					HorizontalTextAlignment = TextAlignment.Center,
					Text = DeviceInfo.Platform == DevicePlatform.iOS ? "Custom renderer UITableView" : DeviceInfo.Platform == DevicePlatform.Android ? "Custom renderer ListView" : "Custom renderer ListView"
				},
				fasterListView
			}
		};
	}
}

/// <summary>
/// Xamarin.Forms representation for a custom-renderer that uses 
/// the native list control on each platform.
/// </summary>
public class NativeListView : View
{
	public static readonly BindableProperty ItemsProperty =
		BindableProperty.Create(nameof(Items), typeof(IEnumerable<string>), typeof(NativeListView), new List<string>());

	public IEnumerable<string> Items
	{
		get { return (IEnumerable<string>)GetValue(ItemsProperty); }
		set { SetValue(ItemsProperty, value); }
	}

	public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

	public void NotifyItemSelected(object item)
	{

		if (ItemSelected != null)
			ItemSelected(this, new SelectedItemChangedEventArgs(item, Items?.ToList().IndexOf($"{item}") ?? -1));
	}

	public NativeListView()
	{
	}
}
#if IOS || MACCATALYST
public class NativeListViewHandler : ViewHandler<NativeListView, UITableView>
{
	public static PropertyMapper<NativeListView, NativeListViewHandler> PropertyMapper = new PropertyMapper<NativeListView, NativeListViewHandler>(ViewHandler.ViewMapper)
	{
		[nameof(NativeListView.Items)] = MapItems
	};
	public NativeListViewHandler() : base(PropertyMapper)
	{
	}
	protected override UITableView CreatePlatformView()
	{
		var tableView = new UITableView();
		tableView.Source = new NativeListViewSource(VirtualView);
		return tableView;
	}
	private static void MapItems(NativeListViewHandler handler, NativeListView view)
	{
		((NativeListViewSource)handler.PlatformView.Source).Items = view.Items;
		handler.PlatformView.ReloadData();
	}
}
public class NativeListViewSource : UITableViewSource
{
	private readonly NativeListView _virtualView;
	private IEnumerable<string> _items;
	public IEnumerable<string> Items
	{
		get => _items;
		set => _items = value;
	}
	public NativeListViewSource(NativeListView virtualView)
	{
		_virtualView = virtualView;
	}
	public override nint RowsInSection(UITableView tableview, nint section)
	{
		return _items?.Count() ?? 0;
	}
	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	{
		const string cellIdentifier = "DefaultCell";
		var cell = tableView.DequeueReusableCell(cellIdentifier);
		if (cell == null)
		{
			cell = new UITableViewCell(UITableViewCellStyle.Default, cellIdentifier);
		}
		var content = UIListContentConfiguration.CellConfiguration;
		var item = _items.ElementAt(indexPath.Row);
		content.Text = item;
		cell.ContentConfiguration = content;
		return cell;
	}
	public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
	{
		var item = _items.ElementAt(indexPath.Row);
		_virtualView.NotifyItemSelected(item);
		tableView.DeselectRow(indexPath, true);
	}
}
#endif

#if ANDROID
    public class NativeListViewHandler : ViewHandler<NativeListView, Android.Widget.ListView>
    {
        private Android.Widget.ListView _listView;
        public static PropertyMapper<NativeListView, NativeListViewHandler> PropertyMapper = new PropertyMapper<NativeListView, NativeListViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(NativeListView.Items)] = MapItems
        };
        public NativeListViewHandler() : base(PropertyMapper)
        {
        }
        protected override Android.Widget.ListView CreatePlatformView()
        {
            _listView = new Android.Widget.ListView(Context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                   ViewGroup.LayoutParams.MatchParent,
                   ViewGroup.LayoutParams.MatchParent)
            };
            _listView.Adapter = new NativeListViewAdapter(Context, VirtualView);
            _listView.ItemClick += ListView_ItemClick;
            return _listView;
        }
        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var adapter = (NativeListViewAdapter)_listView.Adapter;
            var item = adapter.Items.ElementAt(e.Position);
            VirtualView.NotifyItemSelected(item.ToString());
        }
        
        private static void MapItems(NativeListViewHandler handler, NativeListView view)
        {
            if (handler.PlatformView.Adapter is NativeListViewAdapter adapter)
            {
                adapter.Items = view.Items;
                adapter.NotifyDataSetChanged();
            }
        }
    }
    public class NativeListViewAdapter : BaseAdapter<string>
    {
        private readonly Context _context;
        private readonly NativeListView _virtualView;
        private IEnumerable<string> _items;
        public IEnumerable<string> Items
        {
            get => _items;
            set => _items = value;
        }
        public NativeListViewAdapter(Context context, NativeListView virtualView)
        {
            _context = context;
            _virtualView = virtualView;
            _items = virtualView.Items;
        }
        public override long GetItemId(int position) => position;
        public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
        {
            TextView view = (TextView)convertView;
            if (view == null)
            {
                view = new TextView(_context)
                {
                    LayoutParameters = new ViewGroup.LayoutParams(
                       ViewGroup.LayoutParams.MatchParent,
                       ViewGroup.LayoutParams.WrapContent)
                };
                view.SetPadding(16, 16, 16, 16);
                view.TextSize = 16;
            }
            view.Text = _items.ElementAt(position);
            return view;
        }
        public override int Count => _items?.Count() ?? 0;
        public override string this[int position] => _items.ElementAt(position);
    }
#endif

#if WINDOWS
  public class NativeListViewHandler : ViewHandler<NativeListView, Microsoft.UI.Xaml.Controls.ListView>
    {
        public static PropertyMapper<NativeListView, NativeListViewHandler> PropertyMapper = new PropertyMapper<NativeListView, NativeListViewHandler>(ViewHandler.ViewMapper)
        {
            [nameof(NativeListView.Items)] = MapItems
        };

        public NativeListViewHandler() : base(PropertyMapper)
        {
        }

        protected override Microsoft.UI.Xaml.Controls.ListView CreatePlatformView()
        {
            var listView = new Microsoft.UI.Xaml.Controls.ListView();
            listView.SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.Single;
            listView.SelectionChanged += ListView_SelectionChanged;
            return listView;
        }

        private void ListView_SelectionChanged(object sender, Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems.FirstOrDefault();
            if (selectedItem != null)
            {
                VirtualView.NotifyItemSelected(selectedItem);
            }
        }

        private static void MapItems(NativeListViewHandler handler, NativeListView view)
        {
            if (handler.PlatformView.ItemsSource is List<string> items)
            {
                items.Clear();
                items.AddRange(view.Items);
            }
            else
            {
                handler.PlatformView.ItemsSource = new List<string>(view.Items);
            }
        }
    }
#endif

/// <summary>
/// This page uses built-in Xamarin.Forms controls to display a fast-scrolling list.
/// 
/// It uses the built-in <c>TextCell</c> class which does not require special 'layout'
/// and is therefore faster than building a custom ViewCell in Microsoft.Maui.Controls.
/// </summary>

public class XamarinFormsPage : ContentPage
{
	public XamarinFormsPage()
	{
		var tableItems = new List<string>();
		for (var i = 0; i < 100; i++)
		{
			tableItems.Add(i + " row ");
		}

		var listView = new Microsoft.Maui.Controls.ListView();
		listView.ItemsSource = tableItems;
		listView.ItemTemplate = new DataTemplate(typeof(TextCell));
		listView.ItemTemplate.SetBinding(TextCell.TextProperty, ".");

		listView.ItemSelected += async (sender, e) =>
		{
			if (e.SelectedItem == null)
				return;
			listView.SelectedItem = null; // deselect row
			await Navigation.PushModalAsync(new DetailPage(e.SelectedItem));
		};

		Content = new StackLayout
		{
			Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(5, 20, 5, 0) : new Thickness(5, 0),
			Children = {
				new Label {
					HorizontalTextAlignment = TextAlignment.Center,
					Text = "Xamarin.Forms built-in ListView"
				},
				listView
			}
		};
	}
}

/// <summary>
/// This page uses built-in Xamarin.Forms controls to display a fast-scrolling list.
/// 
/// It uses the built-in <c>TextCell</c> class which does not require special 'layout'
/// and is therefore faster than building a custom ViewCell in Microsoft.Maui.Controls.
/// </summary>

public class XamarinFormsNativeCellPage : ContentPage
{
	public XamarinFormsNativeCellPage()
	{
		var listView = new Microsoft.Maui.Controls.ListView();
		listView.ItemsSource = DataSource.GetList();
		listView.ItemTemplate = new DataTemplate(typeof(NativeCell));

		listView.ItemTemplate.SetBinding(NativeCell.NameProperty, "Name");
		listView.ItemTemplate.SetBinding(NativeCell.CategoryProperty, "Category");
		listView.ItemTemplate.SetBinding(NativeCell.ImageFilenameProperty, "ImageFilename");

		listView.ItemSelected += async (sender, e) =>
		{
			if (e.SelectedItem == null)
				return;
			listView.SelectedItem = null; // deselect row

			await Navigation.PushModalAsync(new DetailPage(e.SelectedItem));
		};

		Content = new StackLayout
		{
			Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(0, 20, 0, 0) : new Thickness(0),
			Children = {
				new Label {
					HorizontalTextAlignment = TextAlignment.Center,
					Text = "Xamarin.Forms native Cell"
				},
				listView
			}
		};
	}
}


public class NativeCell : ViewCell
{
	public NativeCell()
	{
		var nameLabel = new Label();
		nameLabel.SetBinding(Label.TextProperty, new Binding("Name"));

		var categoryLabel = new Label();
		categoryLabel.SetBinding(Label.TextProperty, new Binding("Category"));

		var image = new Image();
		image.SetBinding(Image.SourceProperty, new Binding("ImageFilename"));

		View = new StackLayout
		{
			Padding = new Thickness(5),
			Children = { nameLabel, categoryLabel, image }
		};
	}

	public static readonly BindableProperty NameProperty =
		BindableProperty.Create("Name", typeof(string), typeof(NativeCell), "");
	public string Name
	{
		get { return (string)GetValue(NameProperty); }
		set { SetValue(NameProperty, value); }
	}


	public static readonly BindableProperty CategoryProperty =
		BindableProperty.Create("Category", typeof(string), typeof(NativeCell), "");
	public string Category
	{
		get { return (string)GetValue(CategoryProperty); }
		set { SetValue(CategoryProperty, value); }
	}


	public static readonly BindableProperty ImageFilenameProperty =
		BindableProperty.Create("ImageFilename", typeof(string), typeof(NativeCell), "");
	public string ImageFilename
	{
		get { return (string)GetValue(ImageFilenameProperty); }
		set { SetValue(ImageFilenameProperty, value); }
	}

}

public class DetailPage : ContentPage
{
	public DetailPage(object detail)
	{
		var l = new Label { Text = "Xamarin.Forms Detail Page" };

		var t = new Label();

		if (detail is string)
		{
			t.Text = (string)detail;
		}
		else if (detail is DataSource)
		{
			t.Text = ((DataSource)detail).Name;
		}

		var b = new Microsoft.Maui.Controls.Button { Text = "Dismiss" };
		b.Clicked += (sender, e) => Navigation.PopModalAsync();

		Content = new StackLayout
		{
			Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(0, 20, 0, 0) : new Thickness(0),
			HorizontalOptions = LayoutOptions.Center,
			VerticalOptions = LayoutOptions.Center,
			Children = {
				l,
				t,
				b
			}
		};
	}
}

/// <summary>
/// This page uses a custom renderer that wraps native list controls:
///    iOS :           UITableView
///    Android :       ListView   (do not confuse with Xamarin.Forms ListView)
///    Windows Phone : ?
/// 
/// It uses a CUSTOM row/cell class that is defined natively which 
/// is still faster than a Xamarin.Forms-defined ViewCell subclass.
/// </summary>

public class NativeListViewPage2 : ContentPage
{
	public NativeListViewPage2()
	{
		var nativeListView2 = new NativeListView2(); // CUSTOM RENDERER using a native control

#pragma warning disable CS0618 // Type or member is obsolete
		nativeListView2.VerticalOptions = LayoutOptions.FillAndExpand; // REQUIRED: To share a scrollable view with other views in a StackLayout, it should have a VerticalOptions of FillAndExpand.
#pragma warning restore CS0618 // Type or member is obsolete

		nativeListView2.Items = DataSource.GetList();

		nativeListView2.ItemSelected += async (sender, e) =>
		{
			//await Navigation.PushModalAsync (new DetailPage(e.SelectedItem));
			await DisplayAlert("clicked", "one of the rows was clicked", "ok");
		};

		// The root page of your application
		Content = new StackLayout
		{
			Padding = DeviceInfo.Platform == DevicePlatform.iOS ? new Thickness(0, 20, 0, 0) : new Thickness(0),
			Children = {
				new Label {
					HorizontalTextAlignment = TextAlignment.Center,
					Text = DeviceInfo.Platform == DevicePlatform.iOS ? "Custom UITableView+UICell" : DeviceInfo.Platform == DevicePlatform.Android ? "Custom ListView+Cell" : "Custom ListView + Grid Cell"
				},
				nativeListView2
			}
		};
	}
}

/// <summary>
/// Xamarin.Forms representation for a custom-renderer that uses 
/// the native list control on each platform.
/// </summary>
public class NativeListView2 : View
{
	public static readonly BindableProperty ItemsProperty =
		BindableProperty.Create(nameof(Items), typeof(IEnumerable<DataSource>), typeof(NativeListView2), new List<DataSource>());

	public IEnumerable<DataSource> Items
	{
		get { return (IEnumerable<DataSource>)GetValue(ItemsProperty); }
		set { SetValue(ItemsProperty, value); }
	}

	public event EventHandler<SelectedItemChangedEventArgs> ItemSelected;

	public void NotifyItemSelected(object item)
	{

		if (ItemSelected != null)
			ItemSelected(this, new SelectedItemChangedEventArgs(item, Items?.ToList().IndexOf((DataSource)item) ?? -1));
	}

	public NativeListView2()
	{
	}
}
#if IOS || MACCATALYST
public class NativeListView2Handler : ViewHandler<NativeListView2, UITableView>
{
	public static PropertyMapper<NativeListView2, NativeListView2Handler> PropertyMapper = new PropertyMapper<NativeListView2, NativeListView2Handler>(ViewHandler.ViewMapper)
	{
		[nameof(NativeListView2.Items)] = MapItems
	};
	public NativeListView2Handler() : base(PropertyMapper)
	{
	}
	protected override UITableView CreatePlatformView()
	{
		var tableView = new UITableView();
		tableView.Source = new NativeListView2Source(VirtualView);
		return tableView;
	}
	private static void MapItems(NativeListView2Handler handler, NativeListView2 view)
	{
		((NativeListView2Source)handler.PlatformView.Source).Items = view.Items;
		handler.PlatformView.ReloadData();
	}
}
public class NativeListView2Source : UITableViewSource
{
	private readonly NativeListView2 _virtualView;
	private IEnumerable<DataSource> _items;
	public IEnumerable<DataSource> Items
	{
		get => _items;
		set => _items = value;
	}
	public NativeListView2Source(NativeListView2 virtualView)
	{
		_virtualView = virtualView;
	}
	public override nint RowsInSection(UITableView tableview, nint section)
	{
		return _items?.Count() ?? 0;
	}
	public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
	{
		const string cellIdentifier = "CustomCell";
		var cell = tableView.DequeueReusableCell(cellIdentifier);
		if (cell == null)
		{
			cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
		}
		var item = _items.ElementAt(indexPath.Row);
		var content = UIListContentConfiguration.SubtitleCellConfiguration;
		content.Text = item.Name;
		content.SecondaryText = item.Category;
		cell.ContentConfiguration = content;
		return cell;
	}
	public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
	{
		var item = _items.ElementAt(indexPath.Row);
		_virtualView.NotifyItemSelected(item);
		tableView.DeselectRow(indexPath, true);
	}
}
#endif

#if ANDROID
public class NativeListView2Handler : ViewHandler<NativeListView2, Android.Widget.ListView>
{
    private Android.Widget.ListView _listView;
    public static PropertyMapper<NativeListView2, NativeListView2Handler> PropertyMapper = new PropertyMapper<NativeListView2, NativeListView2Handler>(ViewHandler.ViewMapper)
    {
        [nameof(NativeListView2.Items)] = MapItems
    };
    public NativeListView2Handler() : base(PropertyMapper)
    {
    }
    protected override Android.Widget.ListView CreatePlatformView()
    {
        _listView = new Android.Widget.ListView(Context)
        {
            LayoutParameters = new ViewGroup.LayoutParams(
               ViewGroup.LayoutParams.MatchParent,
               ViewGroup.LayoutParams.MatchParent)
        };
        _listView.Adapter = new NativeListView2Adapter(Context, VirtualView);
        _listView.ItemClick += ListView_ItemClick;
        return _listView;
    }
    private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
            var adapter = (NativeListView2Adapter)_listView.Adapter;
            var item = adapter.Items.ElementAt(e.Position);
            VirtualView.NotifyItemSelected(item);
    }
    private static void MapItems(NativeListView2Handler handler, NativeListView2 view)
    {
        if (handler.PlatformView.Adapter is NativeListView2Adapter adapter)
        {
            adapter.Items = view.Items;
            adapter.NotifyDataSetChanged();
        }
    }
}
public class NativeListView2Adapter : BaseAdapter<DataSource>
{
    private readonly Context _context;
    private readonly NativeListView2 _virtualView;
    private IEnumerable<DataSource> _items;
    public IEnumerable<DataSource> Items
    {
        get => _items;
        set => _items = value;
    }
    public NativeListView2Adapter(Context context, NativeListView2 virtualView)
    {
        _context = context;
        _virtualView = virtualView;
        _items = virtualView.Items;
    }
    public override long GetItemId(int position)
    {
        return position;
    }
    public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
    {
        Android.Views.View view = convertView;
        if (view == null)
        {
            view = LayoutInflater.From(_context).Inflate(Android.Resource.Layout.SimpleListItem2, null);
        }
        var item = _items.ElementAt(position);
        var text1 = view.FindViewById<TextView>(Android.Resource.Id.Text1);
        var text2 = view.FindViewById<TextView>(Android.Resource.Id.Text2);
        text1.Text = item.Name;
        text2.Text = item.Category;
        return view;
    }
    public override int Count => _items?.Count() ?? 0;
    public override DataSource this[int position] => _items.ElementAt(position);
}
#endif

#if WINDOWS
public class NativeListView2Handler : ViewHandler<NativeListView2, Microsoft.UI.Xaml.Controls.ListView>
{
    public static PropertyMapper<NativeListView2, NativeListView2Handler> PropertyMapper = new PropertyMapper<NativeListView2, NativeListView2Handler>(ViewHandler.ViewMapper)
    {
        [nameof(NativeListView2.Items)] = MapItems
    };

    public NativeListView2Handler() : base(PropertyMapper)
    {
    }

    protected override Microsoft.UI.Xaml.Controls.ListView CreatePlatformView()
    {
        var listView = new Microsoft.UI.Xaml.Controls.ListView();
		listView.SelectionMode = Microsoft.UI.Xaml.Controls.ListViewSelectionMode.Single;    
		listView.IsItemClickEnabled = true;
		listView.ItemClick += ListView_ItemClick;
        return listView;
    }

    private void ListView_ItemClick(object sender, Microsoft.UI.Xaml.Controls.ItemClickEventArgs e)
    {
        var item = e.ClickedItem as DataSource;
        VirtualView.NotifyItemSelected(item);
    }

    private static void MapItems(NativeListView2Handler handler, NativeListView2 view)
    {
        if (view.Items != null)
        {
            var listView = handler.PlatformView;
            listView.Items.Clear();  

            foreach (var dataItem in view.Items)
            {
                var listViewItem = new Microsoft.UI.Xaml.Controls.ListViewItem();
                var grid = new Microsoft.UI.Xaml.Controls.Grid();
				grid.RowDefinitions.Add(new Microsoft.UI.Xaml.Controls.RowDefinition());
                grid.RowDefinitions.Add(new Microsoft.UI.Xaml.Controls.RowDefinition());
                var textBlock1 = new Microsoft.UI.Xaml.Controls.TextBlock { Text = dataItem.Name };
                Microsoft.UI.Xaml.Controls.Grid.SetRow(textBlock1, 0);
				var textBlock2 = new Microsoft.UI.Xaml.Controls.TextBlock { Text = dataItem.Category };
				Microsoft.UI.Xaml.Controls.Grid.SetRow(textBlock2, 1);
                grid.Children.Add(textBlock1);
                grid.Children.Add(textBlock2);
                listViewItem.Content = grid;
                listView.Items.Add(listViewItem);
            }
        }
    }
}
#endif

public class DataSource
{
	public string Name { get; set; }
	public string Category { get; set; }
	public string ImageFilename { get; set; }

	public DataSource()
	{
	}

	public DataSource(string name, string category, string imageFilename)
	{
		Name = name;
		Category = category;
		ImageFilename = imageFilename;
	}

	public static List<DataSource> GetList()
	{
		var l = new List<DataSource>();


		l.Add(new DataSource("Asparagus", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Avocados", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Beetroots", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Capsicum", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Broccoli", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Brussel sprouts", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Cabbage", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Carrots", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Cauliflower", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Celery", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Corn", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Cucumbers", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Eggplant", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Fennel", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Garlic", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Beans", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Peas", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Kale", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Leeks", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Mushrooms", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Olives", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Onions", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Potatoes", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Lettuce", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Spinach", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Squash", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Sweet potatoes", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Tomatoes", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Turnips", "Vegetables", "Vegetables"));
		l.Add(new DataSource("Apples", "Fruits", "Fruits"));
		l.Add(new DataSource("Apricots", "Fruits", "Fruits"));
		l.Add(new DataSource("Bananas", "Fruits", "Fruits"));
		l.Add(new DataSource("Blueberries", "Fruits", "Fruits"));
		l.Add(new DataSource("Rockmelon", "Fruits", "Fruits"));
		l.Add(new DataSource("Figs", "Fruits", "Fruits"));
		l.Add(new DataSource("Grapefruit", "Fruits", "Fruits"));
		l.Add(new DataSource("Grapes", "Fruits", "Fruits"));
		l.Add(new DataSource("Honeydew Melon", "Fruits", "Fruits"));
		l.Add(new DataSource("Kiwifruit", "Fruits", "Fruits"));
		l.Add(new DataSource("Lemons", "Fruits", "Fruits"));
		l.Add(new DataSource("Oranges", "Fruits", "Fruits"));
		l.Add(new DataSource("Pears", "Fruits", "Fruits"));
		l.Add(new DataSource("Pineapple", "Fruits", "Fruits"));
		l.Add(new DataSource("Plums", "Fruits", "Fruits"));
		l.Add(new DataSource("Raspberries", "Fruits", "Fruits"));
		l.Add(new DataSource("Strawberries", "Fruits", "Fruits"));
		l.Add(new DataSource("Watermelon", "Fruits", "Fruits"));
		l.Add(new DataSource("Balmain Bugs", "Seafood", ""));
		l.Add(new DataSource("Calamari", "Seafood", ""));
		l.Add(new DataSource("Cod", "Seafood", ""));
		l.Add(new DataSource("Prawns", "Seafood", ""));
		l.Add(new DataSource("Lobster", "Seafood", ""));
		l.Add(new DataSource("Salmon", "Seafood", ""));
		l.Add(new DataSource("Scallops", "Seafood", ""));
		l.Add(new DataSource("Shrimp", "Seafood", ""));
		l.Add(new DataSource("Tuna", "Seafood", ""));
		l.Add(new DataSource("Almonds", "Nuts", ""));
		l.Add(new DataSource("Cashews", "Nuts", ""));
		l.Add(new DataSource("Peanuts", "Nuts", ""));
		l.Add(new DataSource("Walnuts", "Nuts", ""));
		l.Add(new DataSource("Black beans", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Dried peas", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Kidney beans", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Lentils", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Lima beans", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Miso", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Soybeans", "Beans & Legumes", "Legumes"));
		l.Add(new DataSource("Beef", "Meat", ""));
		l.Add(new DataSource("Buffalo", "Meat", ""));
		l.Add(new DataSource("Chicken", "Meat", ""));
		l.Add(new DataSource("Lamb", "Meat", ""));
		l.Add(new DataSource("Cheese", "Dairy", ""));
		l.Add(new DataSource("Milk", "Dairy", ""));
		l.Add(new DataSource("Eggs", "Dairy", ""));
		l.Add(new DataSource("Basil", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Black pepper", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Chili pepper, dried", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Cinnamon", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Cloves", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Cumin", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Dill", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Ginger", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Mustard", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Oregano", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Parsley", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Peppermint", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Rosemary", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Sage", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Thyme", "Herbs & Spices", "FlowerBuds"));
		l.Add(new DataSource("Turmeric", "Herbs & Spices", "FlowerBuds"));


		return l;
	}
}