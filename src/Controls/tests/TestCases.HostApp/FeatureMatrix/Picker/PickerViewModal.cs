using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class PickerViewModal : INotifyPropertyChanged
{
    private double _characterSpacing;
    private FontAttributes _fontAttributes = default;
    private bool _fontAutoScalingEnabled = default;
    private string _fontFamily = default;
    private double _fontSize = default;
    private TextAlignment _horizontalTextAlignment = default;
    private ObservableCollection<string> _itemsSource = new ObservableCollection<string>
            {
                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };
    // private ObservableCollection<ComplexItem> _itemsSource = new ObservableCollection<ComplexItem>
    // {
    //     new ComplexItem { Id = 1, Name = "Item 1", Description = "Description for Item 1" },
    //     new ComplexItem { Id = 2, Name = "Item 2", Description = "Description for Item 2" },
    //     new ComplexItem { Id = 3, Name = "Item 3", Description = "Description for Item 3" }
    // };

    private int _selectedIndex = default;
    private object _selectedItem = default;
    private BindingBase _itemDisplayBinding = new Binding(".");
    private Color _textColor = Colors.Black;
    // private TextTransform _textTransform = default;
    private string _title = "Picker Title";
    private Color _titleColor = Colors.Black;
    private TextAlignment _verticalTextAlignment = default;


    public double CharacterSpacing
    {
        get => _characterSpacing;
        set
        {
            if (_characterSpacing != value)
            {
                _characterSpacing = value;
                OnPropertyChanged();
            }
        }
    }
    public FontAttributes FontAttributes
    {
        get => _fontAttributes;
        set
        {
            if (_fontAttributes != value)
            {
                _fontAttributes = value;
                OnPropertyChanged();
            }
        }
    }
    public bool FontAutoScalingEnabled
    {
        get => _fontAutoScalingEnabled;
        set
        {
            if (_fontAutoScalingEnabled != value)
            {
                _fontAutoScalingEnabled = value;
                OnPropertyChanged();
            }
        }
    }
    public string FontFamily
    {
        get => _fontFamily;
        set
        {
            if (_fontFamily != value)
            {
                _fontFamily = value;
                OnPropertyChanged();
            }
        }
    }
    public double FontSize
    {
        get => _fontSize;
        set
        {
            if (_fontSize != value)
            {
                _fontSize = value;
                OnPropertyChanged();
            }
        }
    }
    public TextAlignment HorizontalTextAlignment
    {
        get => _horizontalTextAlignment;
        set
        {
            if (_horizontalTextAlignment != value)
            {
                _horizontalTextAlignment = value;
                OnPropertyChanged();
            }
        }
    }
    public ObservableCollection<string> ItemsSource
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
    public BindingBase ItemDisplayBinding
    {
        get => _itemDisplayBinding;
        set
        {
            if (_itemDisplayBinding != value)
            {
                _itemDisplayBinding = value;
                OnPropertyChanged();
            }
        }
    }
    public int SelectedIndex
    {
        get => _selectedIndex;
        set
        {
            if (_selectedIndex != value)
            {
                _selectedIndex = value;
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
    public Color TextColor
    {
        get => _textColor;
        set
        {
            if (_textColor != value)
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }
    }
    // public TextTransform TextTransform
    // {
    //     get => _textTransform;
    //     set
    //     {
    //         if (_textTransform != value)
    //         {
    //             _textTransform = value;
    //             OnPropertyChanged();
    //         }
    //     }
    // }
    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnPropertyChanged();
            }
        }
    }
    public Color TitleColor
    {
        get => _titleColor;
        set
        {
            if (_titleColor != value)
            {
                _titleColor = value;
                OnPropertyChanged();
            }
        }
    }
    public TextAlignment VerticalTextAlignment
    {
        get => _verticalTextAlignment;
        set { _verticalTextAlignment = value; OnPropertyChanged(); }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public class ComplexItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
