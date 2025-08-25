namespace Maui.Controls.Sample;

public partial class TabbedPageControlPage : TabbedPage
{
	private TabbedPageViewModel _viewModel;

	public TabbedPageControlPage()
	{
		InitializeComponent();
		_viewModel = new TabbedPageViewModel();
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new TabbedPageViewModel();
		await Navigation.PushModalAsync(new TabbedPageOptionsPage(_viewModel));
	}
}