namespace Maui.Controls.Sample;

public class TimePickerControlPage : NavigationPage
{
	private TimePickerViewModal _viewModel;

	public TimePickerControlPage()
	{
		_viewModel = new TimePickerViewModal();
		PushAsync(new TimePickerControlMainPage(_viewModel));
	}
}

public partial class TimePickerControlMainPage : ContentPage
{
	private TimePickerViewModal _viewModel;

	public TimePickerControlMainPage(TimePickerViewModal viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new TimePickerViewModal();
		await Navigation.PushAsync(new TimePickerOptionsPage(_viewModel));
	}
}