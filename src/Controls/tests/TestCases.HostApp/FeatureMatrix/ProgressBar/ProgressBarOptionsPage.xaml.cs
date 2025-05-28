using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Controls.Sample
{
	public partial class ProgressBarOptionsPage : ContentPage
	{
		private ProgressBarViewModel _viewModel;

		public ProgressBarOptionsPage(ProgressBarViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}

		private void ApplyButton_Clicked(object sender, EventArgs e)
		{
			Navigation.PopAsync();
		}

		private void OnProgressChanged(object sender, TextChangedEventArgs e)
		{
			if (double.TryParse(ProgressEntry.Text, out double progress))
			{
				_viewModel.Progress = progress;
			}
		}

		private void ProgressColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Blue")
				_viewModel.ProgressColor = Colors.Blue;
			else if (button.Text == "Green")
				_viewModel.ProgressColor = Colors.Green;
		}

		private void BackgroundColorButton_Clicked(object sender, EventArgs e)
		{
			var button = (Button)sender;
			if (button.Text == "Gray")
				_viewModel.BackgroundColor = Colors.Gray;
			else if (button.Text == "Light Blue")
				_viewModel.BackgroundColor = Colors.LightBlue;
		}

		private void OnFlowDirectionChanged(object sender, EventArgs e)
		{
			_viewModel.FlowDirection = FlowDirectionLTR.IsChecked ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
		}

		private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			_viewModel.IsEnabled = IsEnabledTrueRadio.IsChecked;
		}

		private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			_viewModel.IsVisible = IsVisibleTrueRadio.IsChecked;
		}
	}
}
