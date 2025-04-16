namespace Maui.Controls.Sample;

public partial class TimePickerOptionsPage : ContentPage
{
	private TimePickerViewModal _viewModel;
	public TimePickerOptionsPage(TimePickerViewModal viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = viewModel;
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
	private void OnFontFamilyRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontFamily = radioButton.Content.ToString() == "Dokdo" ? "Dokdo" : "MontserratBold";
		}
	}
	public void SetFormatButton_Clicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(Format.Text))
		{
			_viewModel.Format = Format.Text;
		}
	}
	public void SetTimeButton_Clicked(object sender, EventArgs e)
	{
		if (TimeSpan.TryParse(Time.Text, out TimeSpan time))
		{
			_viewModel.Time = time;
		}
	}
	private void OnTextColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.TextColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}
}