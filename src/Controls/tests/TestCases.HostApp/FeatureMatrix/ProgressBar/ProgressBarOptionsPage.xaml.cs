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
			if (button.Text == "Red")
				_viewModel.BackgroundColor = Colors.Red;
			else if (button.Text == "Light Blue")
				_viewModel.BackgroundColor = Colors.LightBlue;
		}

		private void OnFlowDirectionChanged(object sender, CheckedChangedEventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton != null && radioButton.IsChecked)
			{
				_viewModel.FlowDirection = radioButton.Content.ToString() == "LeftToRight" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
			}
		}

		private void OnIsVisibleRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton != null && radioButton.IsChecked)
			{
				_viewModel.IsVisible = radioButton.Content.ToString() == "True";
			}
		}

		private void OnShadowRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton.IsChecked)
			{
				_viewModel.ShadowOpacity = radioButton.Value.ToString() == "1" ? 1f : 0f;
			}
		}
	}
}
