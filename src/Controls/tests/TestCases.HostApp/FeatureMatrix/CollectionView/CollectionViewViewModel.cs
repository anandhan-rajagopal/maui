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
        ListT,
        EmptyListT,
        ObservableCollectionT,
        GroupedListT,
        EmptyGroupedListT,
        IEnumerableT
    }

    public class CollectionViewViewModel : INotifyPropertyChanged
    {
        private object _emptyView;
        private DataTemplate _groupHeaderTemplate;
        private DataTemplate _itemTemplate;
        private ItemsSourceType _itemsSourceType = ItemsSourceType.ListT;
        private bool _isGrouped = false;
        private List<CollectionViewTestItem> _flatList;
        private List<CollectionViewTestItem> _emptyList;
        private ObservableCollection<CollectionViewTestItem> _observableCollection;
        private List<Grouping<string, CollectionViewTestItem>> _groupedList;
        private List<Grouping<string, CollectionViewTestItem>> _emptyGroupedList;
        private SelectionMode _selectionMode = SelectionMode.None;
        private CollectionViewTestItem _selectedItem;
        private ObservableCollection<CollectionViewTestItem> _selectedItems = new ObservableCollection<CollectionViewTestItem>();
        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionViewViewModel()
        {
            LoadItems();
            ItemTemplate = ExampleTemplates.PhotoTemplate();
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

            SelectionMode = SelectionMode.Single;
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
                if (IsGrouped)
                {
                    return ItemsSourceType switch
                    {
                        ItemsSourceType.GroupedListT => _groupedList ?? new List<Grouping<string, CollectionViewTestItem>>(),
                        ItemsSourceType.EmptyGroupedListT => _emptyGroupedList ?? new List<Grouping<string, CollectionViewTestItem>>(),
                        _ => new List<Grouping<string, CollectionViewTestItem>>()
                    };
                }
                else
                {
                    return ItemsSourceType switch
                    {
                        ItemsSourceType.ListT => _flatList,
                        ItemsSourceType.EmptyListT => _emptyList,
                        ItemsSourceType.ObservableCollectionT => _observableCollection,
                        ItemsSourceType.IEnumerableT => _flatList.AsEnumerable(),
                        ItemsSourceType.None => null,
                        _ => null
                    };
                }
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
                    SelectedItem = null;
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
                }
            }
        }

        public ObservableCollection<CollectionViewTestItem> SelectedItems
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

        public string SelectedItemsCount => SelectedItems.Count.ToString() ?? "0";
        public string SelectedItemText => SelectedItem?.Caption ?? "No item selected";

        private void LoadItems()
        {
            // Initialize non-grouped lists
            _flatList = new List<CollectionViewTestItem>();
            AddItems(_flatList, 3);

            _emptyList = new List<CollectionViewTestItem>();
            _observableCollection = new ObservableCollection<CollectionViewTestItem>(_flatList);

            // Initialize grouped lists
            _groupedList = new List<Grouping<string, CollectionViewTestItem>>
            {
                new Grouping<string, CollectionViewTestItem>("Group A", new List<CollectionViewTestItem>()),
                new Grouping<string, CollectionViewTestItem>("Group B", new List<CollectionViewTestItem>()),
            };
            AddItems(_groupedList[0], 2);
            AddItems(_groupedList[1], 2);

            _emptyGroupedList = new List<Grouping<string, CollectionViewTestItem>>();
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
                    $"{images[n % images.Length]}, {n}", images[n % images.Length], n));
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
            public string Image { get; set; }
            public int Index { get; set; }

            public CollectionViewTestItem(string caption, string image, int index)
            {
                Caption = caption;
                Image = image;
                Index = index;
            }
        }
    }
}