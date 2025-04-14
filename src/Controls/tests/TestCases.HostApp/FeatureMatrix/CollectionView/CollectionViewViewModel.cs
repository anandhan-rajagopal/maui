using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Maui.Controls.Sample.CollectionViewGalleries;

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
        ObservableCollection25T,
        ObservableCollection5T,
        GroupedListT,
        EmptyGroupedListT,
        EmptyObservableCollectionT
    }

    public class CollectionViewViewModel : INotifyPropertyChanged
    {
        private object _emptyView;
        private DataTemplate _groupHeaderTemplate;
        private DataTemplate _itemTemplate;
        private ItemsSourceType _itemsSourceType = ItemsSourceType.None;
        private bool _isGrouped = false;
        private ObservableCollection<CollectionViewTestItem> _observableCollection25;
        private ObservableCollection<CollectionViewTestItem> _observableCollection5;
        private ObservableCollection<CollectionViewTestItem> _emptyObservableCollection;
        private List<Grouping<string, CollectionViewTestItem>> _groupedList;
        private List<Grouping<string, CollectionViewTestItem>> _emptyGroupedList;
        private SelectionMode _selectionMode = SelectionMode.None;
        private CollectionViewTestItem _selectedItem;
        private ObservableCollection<object> _selectedItems = new ObservableCollection<object>();
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewViewModel()
        {
            LoadItems();
            ItemTemplate = new DataTemplate(() =>
           {
               var stackLayout = new StackLayout
               {
                   Padding = new Thickness(10),
                   HorizontalOptions = LayoutOptions.Center,
                   VerticalOptions = LayoutOptions.Center
               };

               var label = new Label
               {
                   VerticalOptions = LayoutOptions.Center,
                   HorizontalOptions = LayoutOptions.Center
               };
               label.SetBinding(Label.TextProperty, "Caption");
               stackLayout.Children.Add(label);
               return stackLayout;
           });

            GroupHeaderTemplate = new DataTemplate(() =>
            {
                var stackLayout = new StackLayout
                {
                    BackgroundColor = Colors.LightGray
                };
                var label = new Label
                {
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 18
                };
                label.SetBinding(Label.TextProperty, "Key");
                stackLayout.Children.Add(label);
                return stackLayout;
            });
        }
        public object EmptyView
        {
            get => _emptyView;
            set { _emptyView = value; OnPropertyChanged(); }
        }

        public DataTemplate GroupHeaderTemplate
        {
            get => _groupHeaderTemplate;
            set { _groupHeaderTemplate = value; OnPropertyChanged(); }
        }

        public DataTemplate ItemTemplate
        {
            get => _itemTemplate;
            set { _itemTemplate = value; OnPropertyChanged(); }
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
                }
            }
        }

         public object ItemsSource
        {
            get
            {
                return ItemsSourceType switch
                {
                    ItemsSourceType.ObservableCollection25T => _observableCollection25,
                    ItemsSourceType.ObservableCollection5T => _observableCollection5,
                    ItemsSourceType.GroupedListT => _groupedList,
                    ItemsSourceType.EmptyGroupedListT => _emptyGroupedList,
                    ItemsSourceType.EmptyObservableCollectionT => _emptyObservableCollection,
                    ItemsSourceType.None => null,
                    _ => null
                };
            }
        }

        public SelectionMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                if (_selectionMode != value)
                {
                    _selectionMode = value;
                    OnPropertyChanged();
                    // SelectedItem = null;
                    SelectedItems.Clear();

                    OnPropertyChanged(nameof(SelectedItemsCount));
                }
            }
        }

        public CollectionViewTestItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedItemText));
                    OnPropertyChanged(nameof(SelectedItemsCount));
                }
            }
        }

        public ObservableCollection<object> SelectedItems
        {
            get => _selectedItems;
            set
            {
                if (_selectedItems != value)
                {
                    if (_selectedItems != null)
                        _selectedItems.CollectionChanged -= SelectedItems_CollectionChanged;

                    _selectedItems = value;

                    if (_selectedItems != null)
                        _selectedItems.CollectionChanged += SelectedItems_CollectionChanged;

                    OnPropertyChanged();
                    OnPropertyChanged(nameof(SelectedItemsCount));
                }
            }
        }

        public int SelectedItemsCount => SelectedItems?.Count ?? 0;
        public string SelectedItemText => SelectedItem?.Caption ?? "No item selected";

        private void LoadItems()
        {
            _observableCollection25 = new ObservableCollection<CollectionViewTestItem>();
            _observableCollection5 = new ObservableCollection<CollectionViewTestItem>();
            AddItems(_observableCollection5, 5, "Fruits");
            AddItems(_observableCollection25, 10, "Fruits");
            AddItems(_observableCollection25, 10, "Vegetables");

            _emptyObservableCollection = new ObservableCollection<CollectionViewTestItem>();

            _groupedList = new List<Grouping<string, CollectionViewTestItem>>
            {
                new Grouping<string, CollectionViewTestItem>("Fruits", new List<CollectionViewTestItem>()),
                new Grouping<string, CollectionViewTestItem>("Vegetables", new List<CollectionViewTestItem>())
            };

            AddItems(_groupedList[0], 4, "Fruits");
            AddItems(_groupedList[1], 4, "Vegetables");

            _emptyGroupedList = new List<Grouping<string, CollectionViewTestItem>>();
        }

         private void AddItems(IList<CollectionViewTestItem> list, int count, string category)
        {
            string[] fruits =
            {
              "Apple", "Banana", "Orange", "Grapes", "Mango",
              "Pineapple", "Strawberry", "Blueberry", "Peach", "Cherry",
              "Watermelon", "Papaya", "Kiwi", "Pear", "Plum",
              "Avocado", "Fig", "Guava", "Lychee", "Pomegranate",
              "Lime", "Lemon", "Coconut", "Apricot", "Blackberry"
            };

            string[] vegetables =
            {
               "Carrot", "Broccoli", "Spinach", "Potato", "Tomato",
               "Cucumber", "Lettuce", "Onion", "Garlic", "Pepper",
               "Zucchini", "Pumpkin", "Radish", "Beetroot", "Cabbage",
               "Sweet Potato", "Turnip", "Cauliflower", "Celery", "Asparagus",
               "Eggplant", "Chili", "Corn", "Peas", "Mushroom"
           };

            string[] items = category == "Fruits" ? fruits : vegetables;

            for (int n = 0; n < count; n++)
            {
                list.Add(new CollectionViewTestItem(items[n % items.Length], n)); // Pass the index
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == nameof(IsGrouped))
            {
                OnPropertyChanged(nameof(ItemsSource));
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SelectedItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedItemsCount));
        }

        public class CollectionViewTestItem
        {
            public string Caption { get; set; }
            public int Index { get; set; }

            public CollectionViewTestItem(string caption, int index)
            {
                Caption = caption;
                Index = index;
            }
        }
    }
}