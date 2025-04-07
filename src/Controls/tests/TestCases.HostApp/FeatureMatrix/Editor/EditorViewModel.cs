using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class EditorViewModel : INotifyPropertyChanged
{
    private EditorAutoSizeOption _autoSize = default;
    private double _characterSpacing = default;
    private FontAttributes _fontAttributes = default;
    private string _fontFamily = default;
    private double _fontSize = default;
    private TextAlignment _horizontalTextAlignment = default;
    private bool _isReadOnly = default;
    private bool _isSpellCheckEnabled = default;
    private bool _isTextPredictionEnabled = default;
    private Keyboard _keyboard = default;
    private int _maxLength = 1000;
    private string _placeholder = default;
    private Color _placeholderColor = default;
    private string _text = default;
    private Color _textColor = default;
    private TextTransform _textTransform = TextTransform.Default;
    private TextAlignment _verticalTextAlignment = default;

    public EditorAutoSizeOption AutoSize
    {
        get => _autoSize;
        set { _autoSize = value; OnPropertyChanged(); }
    }
    public double CharacterSpacing
    {
        get => _characterSpacing;
        set { _characterSpacing = value; OnPropertyChanged(); }
    }
    public FontAttributes FontAttributes
    {
        get => _fontAttributes;
        set { _fontAttributes = value; OnPropertyChanged(); }
    }
    public string FontFamily
    {
        get => _fontFamily;
        set { _fontFamily = value; OnPropertyChanged(); }
    }
    public double FontSize
    {
        get => _fontSize;
        set { _fontSize = value; OnPropertyChanged(); }
    }
    public TextAlignment HorizontalTextAlignment
    {
        get => _horizontalTextAlignment;
        set { _horizontalTextAlignment = value; OnPropertyChanged(); }
    }
    public bool IsReadOnly
    {
        get => _isReadOnly;
        set { _isReadOnly = value; OnPropertyChanged(); }
    }
    public bool IsSpellCheckEnabled
    {
        get => _isSpellCheckEnabled;
        set { _isSpellCheckEnabled = value; OnPropertyChanged(); }
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
    public int MaxLength
    {
        get => _maxLength;
        set { _maxLength = value; OnPropertyChanged(); }
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
    public TextTransform TextTransform
    {
        get => _textTransform;
        set { _textTransform = value; OnPropertyChanged(); }
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
}
