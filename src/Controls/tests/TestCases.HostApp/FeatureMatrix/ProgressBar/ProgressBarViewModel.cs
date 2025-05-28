using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample
{
	public class ProgressBarViewModel : INotifyPropertyChanged
	{
		private Color _progressColor;
		private Color _backgroundColor;
		private double _progress;
		private bool _isVisible = true;
		private bool _isEnabled = true;
		private FlowDirection _flowDirection = FlowDirection.LeftToRight;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public ProgressBarViewModel()
		{
			_progressColor = Colors.Blue;
			_backgroundColor = Colors.LightGray;
			_progress = 0.5;
			ChangeProgressCommand = new Command(ChangeProgress);
		}

		public ICommand ChangeProgressCommand { get; }

		public double Progress
		{
			get => _progress;
			set
			{
				if (_progress != value)
				{
					_progress = value;
					OnPropertyChanged();
				}
			}
		}

		public Color ProgressColor
		{
			get => _progressColor;
			set
			{
				if (_progressColor != value)
				{
					_progressColor = value;
					OnPropertyChanged();
				}
			}
		}

		public Color BackgroundColor
		{
			get => _backgroundColor;
			set
			{
				if (_backgroundColor != value)
				{
					_backgroundColor = value;
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

		void ChangeProgress()
		{
			Progress = Progress < 0.5 ? 0.75 : 0.25;
		}
	}
}
