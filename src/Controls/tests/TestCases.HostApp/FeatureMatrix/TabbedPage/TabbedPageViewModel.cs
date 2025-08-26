using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Maui.Controls.Sample;

public class TabbedPageViewModel : INotifyPropertyChanged
{
	private Brush _barBackground = new SolidColorBrush(Colors.Transparent);
	private Color _barTextColor = Colors.Red;
	private Color _selectedTabColor = Colors.Orange;
	private Color _unselectedTabColor = Colors.LightGray;
	private bool _isEnabled = true;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private ObservableCollection<TabbedPageItemSource> _itemsSource;
	private DataTemplate _itemTemplate;
	private object _selectedItem;
	public ObservableCollection<TabbedPageItemSource> ItemsSourceOne { get; } = new ObservableCollection<TabbedPageItemSource>
	{
		new TabbedPageItemSource { Name = "Tab 1", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 2", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 3", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 4", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 5", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 6", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 7", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 8", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 9", ImageUrl = "dotnet_bot.png" },
		new TabbedPageItemSource { Name = "Tab 10", ImageUrl = "dotnet_bot.png" }
	};
	public ObservableCollection<TabbedPageItemSource> ItemsSourceTwo { get; } = new ObservableCollection<TabbedPageItemSource>
	{
		new TabbedPageItemSource { Name = "Apple", ImageUrl = "apple.png" },
		new TabbedPageItemSource { Name = "Cherry", ImageUrl = "cherry.png" },
		new TabbedPageItemSource { Name = "Grape", ImageUrl = "grape.png" },
		new TabbedPageItemSource { Name = "Kiwi", ImageUrl = "kiwi.png" },
		new TabbedPageItemSource { Name = "Lemon", ImageUrl = "lemon.png" },
		new TabbedPageItemSource { Name = "Mango", ImageUrl = "mango.png" },
		new TabbedPageItemSource { Name = "Orange", ImageUrl = "orange.png" },
		new TabbedPageItemSource { Name = "Pineapple", ImageUrl = "pineapple.png" },
		new TabbedPageItemSource { Name = "Pomegranate", ImageUrl = "pomegranate.png" },
		new TabbedPageItemSource { Name = "Strawberry", ImageUrl = "strawberry.png" }
	};
	public event PropertyChangedEventHandler PropertyChanged;

	public TabbedPageViewModel()
	{
		ItemsSource = ItemsSourceOne;
		ItemTemplate = new DataTemplate(() =>
		{
			var label = new Label
			{
				FontAttributes = FontAttributes.Bold,
				FontSize = 18,
				HorizontalOptions = LayoutOptions.Center
			};
			label.SetBinding(Label.TextProperty, "Name");

			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 200,
				HeightRequest = 200
			};
			image.SetBinding(Image.SourceProperty, "ImageUrl");

			var page = new ContentPage
			{
				IconImageSource = "coffee.png",
				Content = new StackLayout
				{
					Padding = new Thickness(5, 25),
					Children =
					{
						new Label
						{
							Text = "Template One",
							FontAttributes = FontAttributes.Bold,
							FontSize = 18,
							HorizontalOptions = LayoutOptions.Center
						},
						label,
						image
					}
				}
			};
			page.SetBinding(ContentPage.TitleProperty, new Binding("Name"));
			return page;
		});
	}

	public ObservableCollection<TabbedPageItemSource> ItemsSource
	{
		get => _itemsSource;
		set
		{
			if (_itemsSource != value)
			{
				_itemsSource = value;
				OnPropertyChanged();
			}
		}
	}

	public DataTemplate ItemTemplate
	{
		get => _itemTemplate;
		set
		{
			if (_itemTemplate != value)
			{
				_itemTemplate = value;
				OnPropertyChanged();
			}
		}
	}

	public object SelectedItem
	{
		get => _selectedItem;
		set
		{
			if (_selectedItem != value)
			{
				_selectedItem = value;
				OnPropertyChanged();
			}
		}
	}

	public Brush BarBackground
	{
		get => _barBackground;
		set
		{
			if (_barBackground != value)
			{
				_barBackground = value;
				OnPropertyChanged();
			}
		}
	}

	public Color BarTextColor
	{
		get => _barTextColor;
		set
		{
			if (_barTextColor != value)
			{
				_barTextColor = value;
				OnPropertyChanged();
			}
		}
	}

	public Color SelectedTabColor
	{
		get => _selectedTabColor;
		set
		{
			if (_selectedTabColor != value)
			{
				_selectedTabColor = value;
				OnPropertyChanged();
			}
		}
	}

	public Color UnselectedTabColor
	{
		get => _unselectedTabColor;
		set
		{
			if (_unselectedTabColor != value)
			{
				_unselectedTabColor = value;
				OnPropertyChanged();
			}
		}
	}

	public bool IsEnabled
	{
		get => _isEnabled;
		set
		{
			if (_isEnabled != value)
			{
				_isEnabled = value;
				OnPropertyChanged();
			}
		}
	}

	public FlowDirection FlowDirection
	{
		get => _flowDirection;
		set
		{
			if (_flowDirection != value)
			{
				_flowDirection = value;
				OnPropertyChanged();
			}
		}
	}

	protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}

public class TabbedPageItemSource
{
	public string Name { get; set; }
	public string ImageUrl { get; set; }
}