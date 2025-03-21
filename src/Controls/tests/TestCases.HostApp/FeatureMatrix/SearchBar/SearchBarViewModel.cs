using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class SearchBarViewModel : INotifyPropertyChanged
{
    private Color _cancelButtonColor = Colors.Blue;
    private double _characterSpacing = 0;
    private int _cursorPosition = 0;
    private FontAttributes _fontAttributes = FontAttributes.None;
    private bool _fontAutoScalingEnabled = true;
    private string _fontFamily = string.Empty;
    private double _fontSize = 14;
    private TextAlignment _horizontalTextAlignment = TextAlignment.Start;
    private bool _isReadOnly = false;
    private bool _isSpellCheckEnabled = false;
    private bool _isTextPredictionEnabled = false;
    private int _maxLength = 100;
    private string _placeholder = string.Empty;
    private Color _placeholderColor = Colors.Gray;
    private int _selectionLength = 0;
    private string _text = string.Empty;
    private Color _textColor = Colors.Black;
    private TextTransform _textTransform = TextTransform.Default;
    private TextAlignment _verticalTextAlignment = TextAlignment.Center;


    public Color CancelButtonColor
    {
        get => _cancelButtonColor;
        set { _cancelButtonColor = value; OnPropertyChanged(); }
    }

    public double CharacterSpacing
    {
        get => _characterSpacing;
        set { _characterSpacing = value; OnPropertyChanged(); }
    }
    public int CursorPosition
    {
        get => _cursorPosition;
        set { _cursorPosition = value; OnPropertyChanged(); }
    }
    public FontAttributes FontAttributes
    {
        get => _fontAttributes;
        set { _fontAttributes = value; OnPropertyChanged(); }
    }
    public bool FontAutoScalingEnabled
    {
        get => _fontAutoScalingEnabled;
        set { _fontAutoScalingEnabled = value; OnPropertyChanged(); }
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
    public int SelectionLength
    {
        get => _selectionLength;
        set { _selectionLength = value; OnPropertyChanged(); }
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
