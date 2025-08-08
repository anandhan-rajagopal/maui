using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample;

public class TabbedPageViewModel : INotifyPropertyChanged
{
	private Brush _barBackground = null;
	private Color _barBackgroundColor = Colors.Transparent;
	private Color _barTextColor = Colors.White;
	private Color _selectedTabColor = Colors.Orange;
	private Color _unselectedTabColor = Colors.LightGray;
	private bool _isVisible = true;
	private bool _isEnabled = true;
	private FlowDirection _flowDirection = FlowDirection.LeftToRight;

	public event PropertyChangedEventHandler PropertyChanged;

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

	public Color BarBackgroundColor
	{
		get => _barBackgroundColor;
		set
		{
			if (_barBackgroundColor != value)
			{
				_barBackgroundColor = value;
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

	public bool IsVisible
	{
		get => _isVisible;
		set
		{
			if (_isVisible != value)
			{
				_isVisible = value;
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
