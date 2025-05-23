using Maui.Controls.Sample;

namespace Maui.Controls.Sample;

public partial class SwitchOptionsPage : ContentPage
{
	private SwitchViewModal _viewModel;
	public SwitchOptionsPage(SwitchViewModal viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}
	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}
	private void OnBackgroundColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.BackgroundColor = radioButton.Content.ToString() == "Blue" ? Colors.Blue : Colors.Orange;
		}
	}
	private void OnFlowDirectionRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FlowDirection = radioButton.Content.ToString() == "LeftToRight" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
		}
	}
	private void OnEnabledRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsEnabled = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnVisibleRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsVisible = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnToggledRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsToggled = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnOnColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.OnColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}
	private void OnThumbColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.ThumbColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}
}