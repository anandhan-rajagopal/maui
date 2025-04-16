using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Maui.Controls.Sample;

public class TimePickerViewModal : INotifyPropertyChanged
{
    private double _characterSpacing;
    private FontAttributes _fontAttributes = default;
    private string _fontFamily = default;
    private double _fontSize = default;
    private string _format = "hh:mm:ss tt";
    private TimeSpan _time = new TimeSpan(10, 0, 0);
    private Color _textColor = Colors.Black;

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
    public string Format
    {
        get => _format;
        set
        {
            if (_format != value)
            {
                _format = value;
                OnPropertyChanged();
            }
        }
    }
    public TimeSpan Time
    {
        get => _time;
        set
        {
            if (_time != value)
            {
                _time = value;
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


    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
