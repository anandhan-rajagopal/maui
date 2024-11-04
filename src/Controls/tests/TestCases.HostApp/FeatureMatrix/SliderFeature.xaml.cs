using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Graphics;

namespace Maui.Controls.Sample
{
	public partial class SliderFeature : ContentPage
	{
		private Slider SliderControl = new Slider();
		public ICommand DragStartedCommand { get; }
		public ICommand DragCompletedCommand { get; }

		public SliderFeature()
		{
			InitializeComponent();
			DragStartedCommand = new Command(OnDragStarted);
			DragCompletedCommand = new Command(OnDragCompleted);
		}

		private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			SliderControl.IsEnabled = IsEnabledTrueRadio.IsChecked;
		}

		private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			SliderControl.IsVisible = IsVisibleTrueRadio.IsChecked;
		}


		private void OnMinimumChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(MinimumEntry.Text, out double min))
			{
				viewModel.Minimum = min; 
			}
		}

		private void OnMaximumChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(MaximumEntry.Text, out double max))
			{
				viewModel.Maximum = max; 
			}
		}

		private void OnValueChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(ValueEntry.Text, out double value))
			{
				viewModel.Value = value;
			}
		}


		private void OnThumbColorButtonClicked(object sender, EventArgs e)
		{
			SliderControl.ThumbColor = Colors.Green;
		}


		private void OnMinTrackColorButtonClicked(object sender, EventArgs e)
		{
			SliderControl.MinimumTrackColor = Colors.Fuchsia;
		}

		private void OnMaxTrackColorButtonClicked(object sender, EventArgs e)
		{
			SliderControl.MaximumTrackColor = Colors.Red;
		}

		private void OnBackgroundColorButtonClicked(object sender, EventArgs e)
		{
			SliderControl.BackgroundColor = Colors.Yellow;
		}


		private void OnThumbImageSourceButtonClicked(object sender, EventArgs e)
		{
			SliderControl.ThumbImageSource = "image1.png";
		}

		private void OnFlowDirectionChanged(object sender, CheckedChangedEventArgs e)
		{
			SliderControl.FlowDirection = FlowDirectionLTR.IsChecked ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
		}

		private void OnDragStarted()
		{
			DragStartStatusLabel.Text = "Drag Started";
		}

		private void OnDragCompleted()
		{
			DragCompletedStatusLabel.Text = "Drag Completed";
		}
		private void OnResetButtonClicked(object sender, EventArgs e)
		{
			
			sliderContainer.Children.Clear();

			SliderControl = new Slider() { WidthRequest = 300, HeightRequest = 50 };
			SliderControl.SetBinding(Slider.MaximumProperty, nameof(SliderViewModel.Maximum));
			SliderControl.SetBinding(Slider.MinimumProperty, nameof(SliderViewModel.Minimum));
			SliderControl.SetBinding(Slider.ValueProperty, nameof(SliderViewModel.Value));
			SliderControl.SetBinding(Slider.IsEnabledProperty, nameof(SliderViewModel.IsEnabled));
			SliderControl.SetBinding(Slider.IsVisibleProperty, nameof(SliderViewModel.IsVisible));
			SliderControl.SetBinding(Slider.ThumbImageSourceProperty, nameof(SliderViewModel.ThumbImageSource));
			SliderControl.SetBinding(Slider.MinimumTrackColorProperty, nameof(SliderViewModel.MinimumTrackColor));
			SliderControl.SetBinding(Slider.MaximumTrackColorProperty, nameof(SliderViewModel.MaximumTrackColor));
			SliderControl.SetBinding(Slider.ThumbColorProperty, nameof(SliderViewModel.ThumbColor));
			SliderControl.SetBinding(Slider.BackgroundColorProperty, nameof(SliderViewModel.BackgroundColor));
			SliderControl.SetBinding(Slider.FlowDirectionProperty, nameof(SliderViewModel.FlowDirection));
			DragStartStatusLabel.SetBinding(Label.TextProperty, nameof(viewModel.DragStartStatus));
			DragCompletedStatusLabel.SetBinding(Label.TextProperty, nameof(viewModel.DragCompletedStatus));
			SliderControl.DragStarted += (s, e) => DragStartedCommand.Execute(null);
			SliderControl.DragCompleted += (s, e) => DragCompletedCommand.Execute(null);
			sliderContainer.Children.Add(SliderControl);
			viewModel.Minimum = 0;
			viewModel.Maximum = 1;
			viewModel.Value = 0;
			MinimumEntry.Text = String.Empty;
			MaximumEntry.Text = String.Empty;
			ValueEntry.Text = String.Empty;
			FlowDirectionLTR.IsChecked = true;
			IsEnabledTrueRadio.IsChecked = true;
			IsVisibleTrueRadio.IsChecked = true;
			DragStartStatusLabel.Text = String.Empty ;
			DragCompletedStatusLabel.Text = String.Empty;

		}
	}

	public class SliderViewModel : INotifyPropertyChanged
	{
		private double _maximum = 1;
		private double _minimum = 0;
		private double _value = 0;
		private bool _isEnabled = true;
		private bool _isVisible = true;
		private ImageSource _thumbImageSource;
		private Color _minimumTrackColor = null;
		private Color _maximumTrackColor = null;
		private Color _thumbColor = null;
		private Color _backgroundColor = null;
		private FlowDirection _flowDirection = FlowDirection.LeftToRight;
		private string _dragStartStatus;
		private string _dragCompletedStatus;

		public event PropertyChangedEventHandler PropertyChanged;

		public double Maximum
		{
			get => _maximum;
			set
			{
				if (_maximum != value)
				{
					_maximum = value;
					OnPropertyChanged();
				}
			}
		}

		public double Minimum
		{
			get => _minimum;
			set
			{
				if (_minimum != value)
				{
					_minimum = value;
					OnPropertyChanged();
				}
			}
		}

		public double Value
		{
			get => _value;
			set
			{
				if (_value != value)
				{
					_value = value;
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

		public ImageSource ThumbImageSource
		{
			get => _thumbImageSource;
			set
			{
				if (_thumbImageSource != value)
				{
					_thumbImageSource = value;
					OnPropertyChanged();
				}
			}
		}

		public Color MinimumTrackColor
		{
			get => _minimumTrackColor;
			set
			{
				if (_minimumTrackColor != value)
				{
					_minimumTrackColor = value;
					OnPropertyChanged();
				}
			}
		}

		public Color MaximumTrackColor
		{
			get => _maximumTrackColor;
			set
			{
				if (_maximumTrackColor != value)
				{
					_maximumTrackColor = value;
					OnPropertyChanged();
				}
			}
		}

		public Color ThumbColor
		{
			get => _thumbColor;
			set
			{
				if (_thumbColor != value)
				{
					_thumbColor = value;
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

		// Properties for data binding
		public string DragStartStatus
		{
			get => _dragStartStatus;
			set
			{
				if (_dragStartStatus != value)
				{
					_dragStartStatus = value;
					OnPropertyChanged(nameof(DragStartStatus));
				}
			}
		}

		public string DragCompletedStatus
		{
			get => _dragCompletedStatus;
			set
			{
				if (_dragCompletedStatus != value)
				{
					_dragCompletedStatus = value;
					OnPropertyChanged(nameof(DragCompletedStatus));
				}
			}
		}
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		private void OnDragStarted()
		{
			DragStartStatus = "Drag Started";
			DragCompletedStatus = string.Empty;  
		}

		private void OnDragCompleted()
		{
			DragCompletedStatus = "Drag Completed";
		}
		 
		private Command _dragStartedCommand;
		private Command _dragCompletedCommand;
 
		public Command DragStartedCommand =>
			_dragStartedCommand ??= new Command(OnDragStarted);

		public Command DragCompletedCommand =>
			_dragCompletedCommand ??= new Command(OnDragCompleted);
	 
	}


}



