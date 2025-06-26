using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public partial class WebViewControlPage : ContentPage
	{
		private WebViewViewModel _viewModel;

		public WebViewControlPage()
		{
			InitializeComponent();
			_viewModel = new WebViewViewModel();
			BindingContext = _viewModel;
			
			// Set the WebView reference in the ViewModel so it can call methods
			_viewModel.WebViewReference = MainWebView;
		}

		private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
		{
			var optionsPage = new WebViewOptionsPage(_viewModel);
			await Navigation.PushAsync(optionsPage);
		}

		private void OnWebViewNavigating(object sender, WebNavigatingEventArgs e)
		{
			_viewModel.OnNavigating(sender, e);
		}

		private void OnWebViewNavigated(object sender, WebNavigatedEventArgs e)
		{
			_viewModel.OnNavigated(sender, e);
		}

		private void OnWebViewProcessTerminated(object sender, EventArgs e)
		{
			_viewModel.OnProcessTerminated(sender, e);
		}
	}
}