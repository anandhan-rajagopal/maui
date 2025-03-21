using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
    public class Grouping<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { get; }

        public Grouping(TKey key, IEnumerable<TItem> items) : base(items)
        {
            Key = key;
        }
    }

    public enum ItemsSourceType
    {
        None,
        ListT,
        EmptyListT,
        ObservableCollectionT,
        GroupedListT,
    }

    public class CollectionViewTestItem
    {
        public string Caption { get; set; }
        public string Image { get; set; }
        public int Index { get; set; }

        public CollectionViewTestItem(string caption, string image, int index)
        {
            Caption = caption;
            Image = image;
            Index = index;
        }
    }

    public class CollectionViewViewModel : INotifyPropertyChanged
    {
        private ItemsSourceType _itemsSourceType = ItemsSourceType.ListT;
        private bool _isGrouped;
        private object _emptyView;
        private DataTemplate _itemTemplate;
        private DataTemplate _groupHeaderTemplate;
        private List<CollectionViewTestItem> _flatList;
        private List<CollectionViewTestItem> _emptyList;
        private ObservableCollection<CollectionViewTestItem> _observableCollection;
        private List<Grouping<string, CollectionViewTestItem>> _groupedList;

        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewViewModel()
        {
            LoadItems();
            ItemTemplate = ExampleTemplates.PhotoTemplate();
            GroupHeaderTemplate = new DataTemplate(() =>
            {
                var label = new Label
                {
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.Fill,
                    HorizontalTextAlignment = TextAlignment.Center,
                    BackgroundColor = Colors.LightGray,
                    Margin = new Thickness(2, 0, 2, 2),
                    AutomationId = "GroupHeaderLabel"
                };
                label.SetBinding(Label.TextProperty, new Binding("Key"));
                return label;
            });

            // Default Selection Mode
            SelectionMode = SelectionMode.None;
        }

        public object EmptyView
        {
            get => _emptyView;
            set { _emptyView = value; OnPropertyChanged(); }
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

        public DataTemplate GroupHeaderTemplate
        {
            get => _groupHeaderTemplate;
            set { _groupHeaderTemplate = value; OnPropertyChanged(); }
        }

        public ItemsSourceType ItemsSourceType
        {
            get => _itemsSourceType;
            set
            {
                if (_itemsSourceType != value)
                {
                    _itemsSourceType = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ItemsSource));
                }
            }
        }

        public bool IsGrouped
        {
            get => _isGrouped;
            set
            {
                if (_isGrouped != value)
                {
                    _isGrouped = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ItemsSource));
                }
            }
        }

        public object ItemsSource
        {
            get
            {
                if (IsGrouped)
                {
                    return ItemsSourceType switch
                    {
                        ItemsSourceType.GroupedListT => _groupedList,
                        _ => _groupedList
                    };
                }
                else
                {
                    return ItemsSourceType switch
                    {
                        ItemsSourceType.ListT => _flatList,
                        ItemsSourceType.EmptyListT => _emptyList,
                        ItemsSourceType.ObservableCollectionT => _observableCollection,
                        ItemsSourceType.None => null,
                        _ => _flatList
                    };
                }
            }
        }

        private SelectionMode _selectionMode = SelectionMode.None;
        public SelectionMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                if (_selectionMode != value)
                {
                    _selectionMode = value;
                    OnPropertyChanged();
                    SelectedItem = null;
                    SelectedItems.Clear();

                    OnPropertyChanged(nameof(SelectedItemsCount));
                }
            }
        }

        private CollectionViewTestItem _selectedItem;
        public CollectionViewTestItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedItemsCount));
                }
            }
        }

        private ObservableCollection<CollectionViewTestItem> _selectedItems = new ObservableCollection<CollectionViewTestItem>();
        public ObservableCollection<CollectionViewTestItem> SelectedItems
        {
            get => _selectedItems;
            set
            {
                if (_selectedItems != value)
                {
                    _selectedItems = value;
                    _selectedItems.CollectionChanged += (s, e) => OnPropertyChanged(nameof(SelectedItemsCount));
                    OnPropertyChanged();
                }
            }
        }

        public int SelectedItemsCount => SelectedItems.Count;

        private void LoadItems()
        {
            _flatList = new List<CollectionViewTestItem>();
            AddItems(_flatList, 4);

            _emptyList = new List<CollectionViewTestItem>();
            _observableCollection = new ObservableCollection<CollectionViewTestItem>(_flatList);

            _groupedList = new List<Grouping<string, CollectionViewTestItem>>
            {
                new Grouping<string, CollectionViewTestItem>("Group A", new List<CollectionViewTestItem>()),
                new Grouping<string, CollectionViewTestItem>("Group B", new List<CollectionViewTestItem>())
            };
            AddItems(_groupedList[0], 2);
            AddItems(_groupedList[1], 2);
        }

        private void AddItems(IList<CollectionViewTestItem> list, int count)
        {
            string[] images =
            {
                 "cover1.jpg",
                "oasis.jpg",
                "photo.jpg",
                "Vegetables.jpg",
                "Fruits.jpg",
                "FlowerBuds.jpg",
                "Legumes.jpg"
            };

            for (int n = 0; n < count; n++)
            {
                list.Add(new CollectionViewTestItem(
                    $"Item {n + 1}", images[n % images.Length], n));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    internal class ExampleTemplates
    {
        public static DataTemplate PhotoTemplate()
        {
            return new DataTemplate(() =>
            {
                var templateLayout = new Grid
                {
                    RowDefinitions = new RowDefinitionCollection { new RowDefinition(), new RowDefinition() },
                    WidthRequest = 200,
                    HeightRequest = 100,
                };

                var image = new Image
                {
                    WidthRequest = 100,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Margin = new Thickness(2, 5, 2, 2),
                    AutomationId = "photo"
                };
                image.SetBinding(Image.SourceProperty, new Binding("Image"));

                var caption = new Label
                {
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.Fill,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(2, 0, 2, 2),
                    BackgroundColor = Colors.Blue
                };
                caption.SetBinding(Label.TextProperty, new Binding("Caption"));

                templateLayout.Children.Add(image);
                templateLayout.Children.Add(caption);
                Grid.SetRow(caption, 1);

                return templateLayout;
            });
        }
    }
}