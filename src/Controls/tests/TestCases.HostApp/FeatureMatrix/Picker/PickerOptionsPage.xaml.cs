namespace Maui.Controls.Sample;

public partial class PickerOptionsPage : ContentPage
{
	private readonly PickerViewModal _viewModel;
	public PickerOptionsPage(PickerViewModal viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
	}
	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnFontAttributesRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontAttributes = radioButton.Content.ToString() == "Italic" ? FontAttributes.Italic : radioButton.Content.ToString() == "Bold" ? FontAttributes.Bold : FontAttributes.None;
		}
	}
	private void OnFontAutoScalingEnabledRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontAutoScalingEnabled = radioButton.Content.ToString() == "True";
		}
	}
	private void OnFontFamilyRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontFamily = radioButton.Content.ToString() == "Dokdo" ? "Dokdo" : "MontserratBold";
		}
	}
	private void OnHorizontalTextAlignmentRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.HorizontalTextAlignment = radioButton.Content.ToString() == "Center"
				? TextAlignment.Center
				: TextAlignment.End;
		}
	}
	private void OnItemDisplayBindingRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.ItemDisplayBinding = radioButton.Content.ToString() == "Description" ? new Binding("Description") : radioButton.Content.ToString() == "Id" ? new Binding("Id") : radioButton.Content.ToString() == "Name" ? new Binding("Name") : new Binding("");
		}
	}
	// private void OnItemSourceRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	// {
	// 	var radioButton = sender as RadioButton;
	// 	if (radioButton.IsChecked)
	// 	{
	// 		_viewModel.ItemSource = radioButton.Content.ToString() == "Countries" ? "Countries" : "States";
	// 	}
	// }
	private void OnTextColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.TextColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}

	private void OnTitleColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.TitleColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}

	private void OnVerticalTextAlignmentRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.VerticalTextAlignment = radioButton.Content.ToString() == "Center"
				? TextAlignment.Center
				: TextAlignment.End;
		}
	}
}