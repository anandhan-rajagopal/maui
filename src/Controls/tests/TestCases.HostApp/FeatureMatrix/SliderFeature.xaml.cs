using System.Windows.Input;

namespace Maui.Controls.Sample
{
	public partial class SliderFeature : ContentPage 
	{
		public ICommand DragStartedCommand { get;  }
		public ICommand DragCompletedCommand { get; }

		public SliderFeature()
		{
			InitializeComponent();
			DragStartedCommand = new Command(OnDragStarted);
			DragCompletedCommand = new Command(OnDragCompleted);
			this.BindingContext = this;

		}

		private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			SliderControl.IsEnabled = IsEnabledTrueRadio.IsChecked;
		}

		private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			SliderControl.IsVisible = IsVisibleTrueRadio.IsChecked;
		}


		private void OnMinimumChanged(object sender, EventArgs e)
		{
			if (double.TryParse(MinimumEntry.Text, out double min))
			{
				SliderControl.Minimum = min;
			}
		}
		private void OnValueChanged(object sender, EventArgs e)
		{
			if (double.TryParse(ValueEntry.Text, out double value))
			{

				SliderControl.Value = value;

			}
		}

		private void OnMaximumChanged(object sender, EventArgs e)
		{
			if (double.TryParse(MaximumEntry.Text, out double max))
			{
				SliderControl.Maximum = max;
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
			SliderControl.Minimum = 0;
			SliderControl.Maximum = 1;
			SliderControl.Value = 0;
			MinimumEntry.Text = string.Empty;
			MaximumEntry.Text = string.Empty;
			ValueEntry.Text = string.Empty;
			FlowDirectionLTR.IsChecked = true;
			IsEnabledTrueRadio.IsChecked = true;
			IsVisibleTrueRadio.IsChecked = true;

			//When set the null value to the color properties 
			//the default color was not updated on other platforms expect windows
#if WINDOWS
			SliderControl.ThumbColor = null;
			SliderControl.MinimumTrackColor =  null;
			SliderControl.MaximumTrackColor = null;
			SliderControl.BackgroundColor =null;
#elif ANDROID
			SliderControl.ThumbColor = Color.FromRgba(1,122,255,255) ;
			SliderControl.MinimumTrackColor =  Color.FromRgba(1,122,255,255) ;
			SliderControl.MaximumTrackColor = Color.FromRgba(227,227,229,255); 
			SliderControl.BackgroundColor =Colors.Transparent;
#elif IOS || MACCATALYST
			SliderControl.ThumbColor = Color.FromRgba(255, 255, 255, 255);
			SliderControl.MinimumTrackColor = Color.FromRgba(1, 122, 255, 255);
			SliderControl.MaximumTrackColor = Color.FromRgba(227, 227, 229, 255);
			SliderControl.BackgroundColor = Colors.Transparent;
#endif
			SliderControl.ThumbImageSource = null;
			DragStartStatusLabel.Text = "StartedEvent";
			DragCompletedStatusLabel.Text = "CompletedEvent";

		}
	}
}



