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
			ProgressBar = new Microsoft.Maui.Controls.ProgressBar
			{
				Progress = 0.5,
				ProgressColor = Colors.Blue
			};

			// Initialize properties from ProgressBar
			_progress = ProgressBar.Progress;
			_progressColor = ProgressBar.ProgressColor;
			_backgroundColor = Colors.Transparent;

			ChangeProgressCommand = new Command(ChangeProgress);
		}

		public Microsoft.Maui.Controls.ProgressBar ProgressBar { get; }

		public ICommand ChangeProgressCommand { get; }

		public double Progress
		{
			get => _progress;
			set
			{
				if (_progress != value)
				{
					_progress = value;
					ProgressBar.Progress = value;
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
					ProgressBar.ProgressColor = value;
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
					ProgressBar.BackgroundColor = value;
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
					ProgressBar.IsVisible = value;
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
					ProgressBar.IsEnabled = value;
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
					ProgressBar.FlowDirection = value;
					OnPropertyChanged();
				}
			}
		}

		void ChangeProgress()
		{
			// Toggle between 0.25 and 0.75
			Progress = Progress < 0.5 ? 0.75 : 0.25;
		}

		public void ResetProgressBar()
		{
			Progress = 0.5;
			ProgressColor = Colors.Blue;
			BackgroundColor = Colors.Transparent;
			IsVisible = true;
			IsEnabled = true;
			FlowDirection = FlowDirection.LeftToRight;
		}
	}
}
