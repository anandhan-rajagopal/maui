namespace Maui.Controls.Sample;

public partial class EditorControlPage : NavigationPage
{
	public EditorControlPage()
	{
		PushAsync(new EditorControlMainPage());
	}
}
public partial class EditorControlMainPage : ContentPage
{
	private EditorViewModel _viewModel;

	public EditorControlMainPage()
	{
		InitializeComponent();
		_viewModel = new EditorViewModel();
		BindingContext = _viewModel;
	}
	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new EditorViewModel();
		await Navigation.PushAsync(new EditorOptionsPage(_viewModel));
	}
}