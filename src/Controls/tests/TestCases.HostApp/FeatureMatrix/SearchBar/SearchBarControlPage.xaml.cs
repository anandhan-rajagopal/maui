namespace Maui.Controls.Sample
{
	public class SearchBarControlPage : NavigationPage
	{
		public SearchBarControlPage()
		{
			PushAsync(new SearchBarControlMainPage());
		}
	}
	public partial class SearchBarControlMainPage : ContentPage
	{
		private SearchBarViewModel _viewModel;
		public SearchBarControlMainPage()
		{
			InitializeComponent();
			_viewModel = new SearchBarViewModel();
			BindingContext = _viewModel;
		}

		private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
		{
			BindingContext = _viewModel = new SearchBarViewModel();
			await Navigation.PushAsync(new SearchBarOptionsPage(_viewModel));
		}
	}
}