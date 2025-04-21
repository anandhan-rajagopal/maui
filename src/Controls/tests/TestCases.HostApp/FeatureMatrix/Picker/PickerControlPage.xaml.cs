namespace Maui.Controls.Sample;

public class PickerControlPage : NavigationPage
{
	public PickerControlPage()
	{
		PushAsync(new PickerControlMainPage());
	}
}

public partial class PickerControlMainPage : ContentPage
{
	private PickerViewModal _viewModel;

	public PickerControlMainPage()
	{
		InitializeComponent();
		_viewModel = new PickerViewModal();
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		this.BindingContext = _viewModel = new PickerViewModal();
		await Navigation.PushAsync(new PickerOptionsPage(_viewModel));
	}
}