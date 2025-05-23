namespace Maui.Controls.Sample;

public class SwitchControlPage : NavigationPage
{
	private SwitchViewModal _viewModel;
	public SwitchControlPage()
	{
		_viewModel = new SwitchViewModal();
		PushAsync(new SwitchControlMainPage(_viewModel));
	}
}

public partial class SwitchControlMainPage : ContentPage
{
	private SwitchViewModal _viewModel;

	public SwitchControlMainPage(SwitchViewModal viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new SwitchViewModal();
		await Navigation.PushAsync(new SwitchOptionsPage(_viewModel));
	}
}