using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class EditorViewModel : INotifyPropertyChanged
{
	private string _text = "";
	private double _characterSpacing = 0.0;
	private FontAttributes _fontAttributes = FontAttributes.None;
	private string _fontFamily = "";
	private double _fontSize = 14.0;
	private Color _textColor = Colors.Black;
	private string _placeholder = "";
	private Color _placeholderColor = Colors.Gray;
	private int _maxLength = -1;
	private bool _isReadOnly = false;
	private bool _isTextPredictionEnabled = true;
	private Keyboard _keyboard = Keyboard.Default;
	private EditorAutoSizeOption _autoSize = EditorAutoSizeOption.Disabled;
	private bool _isEnabled = true;
	private bool _isVisible = true;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;
	private string _textChangedEventText = "";

	public string Text
	{
		get => _text;
		set => SetProperty(ref _text, value);
	}

	public double CharacterSpacing
	{
		get => _characterSpacing;
		set => SetProperty(ref _characterSpacing, value);
	}

	public FontAttributes FontAttributes
	{
		get => _fontAttributes;
		set => SetProperty(ref _fontAttributes, value);
	}

	public string FontFamily
	{
		get => _fontFamily;
		set => SetProperty(ref _fontFamily, value);
	}

	public double FontSize
	{
		get => _fontSize;
		set => SetProperty(ref _fontSize, value);
	}

	public Color TextColor
	{
		get => _textColor;
		set => SetProperty(ref _textColor, value);
	}

	public string Placeholder
	{
		get => _placeholder;
		set => SetProperty(ref _placeholder, value);
	}

	public Color PlaceholderColor
	{
		get => _placeholderColor;
		set => SetProperty(ref _placeholderColor, value);
	}

	public int MaxLength
	{
		get => _maxLength;
		set => SetProperty(ref _maxLength, value);
	}

	public bool IsReadOnly
	{
		get => _isReadOnly;
		set => SetProperty(ref _isReadOnly, value);
	}

	public bool IsTextPredictionEnabled
	{
		get => _isTextPredictionEnabled;
		set => SetProperty(ref _isTextPredictionEnabled, value);
	}

	public Keyboard Keyboard
	{
		get => _keyboard;
		set => SetProperty(ref _keyboard, value);
	}

	public EditorAutoSizeOption AutoSize
	{
		get => _autoSize;
		set => SetProperty(ref _autoSize, value);
	}

	public bool IsEnabled
	{
		get => _isEnabled;
		set => SetProperty(ref _isEnabled, value);
	}

	public bool IsVisible
	{
		get => _isVisible;
		set => SetProperty(ref _isVisible, value);
	}

	public FlowDirection FlowDirection
	{
		get => _flowDirection;
		set => SetProperty(ref _flowDirection, value);
	}

	public string TextChangedEventText
	{
		get => _textChangedEventText;
		set => SetProperty(ref _textChangedEventText, value);
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
	{
		if (EqualityComparer<T>.Default.Equals(backingStore, value))
			return;

		backingStore = value;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}