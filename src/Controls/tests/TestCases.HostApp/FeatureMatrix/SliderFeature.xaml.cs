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
		public ICommand ValueChangedCommand { get; }

		public SliderFeature()
		{
			InitializeComponent();
			DragStartedCommand = new Command(OnDragStarted);
			DragCompletedCommand = new Command(OnDragCompleted);
			ValueChangedCommand = new Command(OnValueChanged);
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
			if (SliderControl.ThumbColor == Colors.Green)
				SliderControl.ThumbColor = Colors.Blue;
			else
				SliderControl.ThumbColor = Colors.Green;
		}


		private void OnMinTrackColorButtonClicked(object sender, EventArgs e)
		{
			if (SliderControl.MinimumTrackColor == Colors.Fuchsia)
				SliderControl.MinimumTrackColor = Colors.DarkBlue;
			else
				SliderControl.MinimumTrackColor = Colors.Fuchsia;
		}

		private void OnMaxTrackColorButtonClicked(object sender, EventArgs e)
		{
			if (SliderControl.MaximumTrackColor == Colors.Red)
				SliderControl.MaximumTrackColor = Colors.Purple;
			else
				SliderControl.MaximumTrackColor = Colors.Red;
		}

		private void OnBackgroundColorButtonClicked(object sender, EventArgs e)
		{
			if (SliderControl.BackgroundColor == Colors.Yellow)
				SliderControl.BackgroundColor = Colors.Pink;
			else
				SliderControl.BackgroundColor = Colors.Yellow;
		}


		private void OnThumbImageSourceButtonClicked(object sender, EventArgs e)
		{
			if (SliderControl.ThumbImageSource != null)
				SliderControl.ThumbImageSource = null;
			else
				SliderControl.ThumbImageSource = "coffee.png";
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

		private void OnValueChanged()
		{
			ValueChangedStatusLabel.Text = "Value Changed";
		}

		private void OnResetButtonClicked(object sender, EventArgs e)
		{

			sliderContainer.Children.Clear();

			SliderControl = new Slider() { WidthRequest = 300, HeightRequest = 50, AutomationId = "SliderControl" };
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
			SliderControl.DragStarted += (s, e) => viewModel.DragStartedCommand.Execute(null);
			SliderControl.DragCompleted += (s, e) => viewModel.DragCompletedCommand.Execute(null);
			SliderControl.ValueChanged += (s, e) => viewModel.ValueChangedCommand.Execute(null);
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
			viewModel.DragStartStatus = String.Empty;
			viewModel.DragCompletedStatus = String.Empty;
			viewModel.ValueChangedStatus = String.Empty;

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
		private string _valueChangedStatus;

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

		public string DragStartStatus
		{
			get => _dragStartStatus;
			set
			{
				if (_dragStartStatus != value)
				{
					_dragStartStatus = value;
					OnPropertyChanged();
					OnPropertyChanged(nameof(IsTriggeredEventVisible));
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
					OnPropertyChanged();
					OnPropertyChanged(nameof(IsTriggeredEventVisible));

				}
			}
		}

		public string ValueChangedStatus
		{
			get => _valueChangedStatus;
			set
			{
				if (_valueChangedStatus != value)
				{
					_valueChangedStatus = value;
					OnPropertyChanged();
					OnPropertyChanged(nameof(IsTriggeredEventVisible));

				}
			}

		}

		public bool IsTriggeredEventVisible => !string.IsNullOrWhiteSpace(DragStartStatus) ||
										   !string.IsNullOrWhiteSpace(DragCompletedStatus) ||
										   !string.IsNullOrWhiteSpace(ValueChangedStatus);

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

		private void OnValueChanged()
		{
			ValueChangedStatus = "Value Changed";
		}

		private Command _dragStartedCommand;
		private Command _dragCompletedCommand;

		private Command _valueChangedCommand;

		public Command DragStartedCommand =>
			_dragStartedCommand ??= new Command(OnDragStarted);

		public Command DragCompletedCommand =>
			_dragCompletedCommand ??= new Command(OnDragCompleted);

		public Command ValueChangedCommand =>
			_valueChangedCommand ??= new Command(OnValueChanged);

	}


}



