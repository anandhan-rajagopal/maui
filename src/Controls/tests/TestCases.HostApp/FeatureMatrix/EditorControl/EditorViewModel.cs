using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Maui.Controls.Sample;

public class EditorViewModel : INotifyPropertyChanged
{
    private string _text = "Test Editor";
    private Color _textColor = Colors.Black;
    private string _placeholder = "Enter text here";
    private Color _placeholderColor = Colors.Gray;
    private double _fontSize = 14;
    private double _characterSpacing = 0;
    private int _maxLength = -1;
    private bool _isReadOnly = false;
    private bool _isTextPredictionEnabled = false;
    private Keyboard _keyboard = Keyboard.Default;
    private string _fontFamily = null;
    private bool _isVisible = true;
    private bool _isEnabled = true;
    private FlowDirection _flowDirection = FlowDirection.LeftToRight;
    private FontAttributes _fontAttributes = FontAttributes.None;
    private EditorAutoSizeOption _autoSize = EditorAutoSizeOption.Disabled;
    private string _textChangedText = "TextChanged: Old='', New='Test Editor'";

    public event PropertyChangedEventHandler PropertyChanged;

    public EditorViewModel()
    {
    }

    public string Text
    {
        get => _text;
        set { _text = value; OnPropertyChanged(); }
    }

    public Color TextColor
    {
        get => _textColor;
        set { _textColor = value; OnPropertyChanged(); }
    }

    public string Placeholder
    {
        get => _placeholder;
        set { _placeholder = value; OnPropertyChanged(); }
    }

    public Color PlaceholderColor
    {
        get => _placeholderColor;
        set { _placeholderColor = value; OnPropertyChanged(); }
    }

    public double FontSize
    {
        get => _fontSize;
        set { _fontSize = value; OnPropertyChanged(); }
    }

    public double CharacterSpacing
    {
        get => _characterSpacing;
        set { _characterSpacing = value; OnPropertyChanged(); }
    }

    public int MaxLength
    {
        get => _maxLength;
        set { _maxLength = value; OnPropertyChanged(); }
    }

    public bool IsReadOnly
    {
        get => _isReadOnly;
        set { _isReadOnly = value; OnPropertyChanged(); }
    }

    public bool IsTextPredictionEnabled
    {
        get => _isTextPredictionEnabled;
        set { _isTextPredictionEnabled = value; OnPropertyChanged(); }
    }

    public Keyboard Keyboard
    {
        get => _keyboard;
        set { _keyboard = value; OnPropertyChanged(); }
    }

    public string FontFamily
    {
        get => _fontFamily;
        set { _fontFamily = value; OnPropertyChanged(); }
    }

    public bool IsVisible
    {
        get => _isVisible;
        set { _isVisible = value; OnPropertyChanged(); }
    }

    public bool IsEnabled
    {
        get => _isEnabled;
        set { _isEnabled = value; OnPropertyChanged(); }
    }

    public FlowDirection FlowDirection
    {
        get => _flowDirection;
        set { _flowDirection = value; OnPropertyChanged(); }
    }

    public FontAttributes FontAttributes
    {
        get => _fontAttributes;
        set { _fontAttributes = value; OnPropertyChanged(); }
    }

    public EditorAutoSizeOption AutoSize
    {
        get => _autoSize;
        set { _autoSize = value; OnPropertyChanged(); }
    }

    public string TextChangedText
    {
        get => _textChangedText;
        set { _textChangedText = value; OnPropertyChanged(); }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}