using System.Net;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public partial class WebViewOptionsPage : ContentPage
	{
		private WebViewViewModel _viewModel;

		public WebViewOptionsPage(WebViewViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;

			// Initialize form controls with current values
			UserAgentEntry.Text = _viewModel.UserAgent ?? "";
			IsEnabledTrueRadio.IsChecked = _viewModel.IsEnabled;
			IsEnabledFalseRadio.IsChecked = !_viewModel.IsEnabled;
			IsVisibleTrueRadio.IsChecked = _viewModel.IsVisible;
			IsVisibleFalseRadio.IsChecked = !_viewModel.IsVisible;
		}

		private async void ApplyButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private void OnSourceChanged(object sender, CheckedChangedEventArgs e)
		{
			if (!e.Value) return;

			var radioButton = sender as RadioButton;
			if (radioButton == HtmlSourceRadio)
			{
				_viewModel.Source = new HtmlWebViewSource
				{
					Html = "<html><body><h1>HTML WebView Source</h1><p>This content is loaded from HTML string.</p><button onclick=\"testAlert()\">Test Alert</button><script>function testAlert() { alert('Alert from HTML!'); }</script></body></html>"
				};
			}
			else if (radioButton == UrlSourceRadio)
			{
				_viewModel.Source = new UrlWebViewSource
				{
					Url = "https://www.microsoft.com"
				};
			}
			else if (radioButton == LocalFileSourceRadio)
			{
				_viewModel.Source = new HtmlWebViewSource
				{
					Html = "<html><body><h1>Local File Simulation</h1><p>This simulates local file content.</p></body></html>"
				};
			}
		}

		private void OnUserAgentChanged(object sender, TextChangedEventArgs e)
		{
			_viewModel.UserAgent = e.NewTextValue;
		}

		private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (!e.Value) return;

			var radioButton = sender as RadioButton;
			_viewModel.IsEnabled = radioButton == IsEnabledTrueRadio;
		}

		private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (!e.Value) return;

			var radioButton = sender as RadioButton;
			_viewModel.IsVisible = radioButton == IsVisibleTrueRadio;
		}

		private void LoadHtmlContent_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>Dynamic HTML Content</h1><p>This is dynamically loaded HTML content with <strong>formatted text</strong>.</p><button onclick=\"showMessage()\">Click Me</button><script>function showMessage() { document.body.innerHTML += '<p>Button clicked at ' + new Date() + '</p>'; }</script></body></html>"
			};
		}

		private void LoadRemoteUrl_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new UrlWebViewSource
			{
				Url = "https://github.com/dotnet/maui"
			};
		}

		private void LoadMultiplePages_Clicked(object sender, EventArgs e)
		{
			// Load first page that has navigation to create history
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>Page 1</h1><p>This is the first page.</p><a href=\"data:text/html,<html><body><h1>Page 2</h1><p>This is the second page.</p></body></html>\">Go to Page 2</a></body></html>"
			};
		}

		private void AddTestCookie_Clicked(object sender, EventArgs e)
		{
			var cookieContainer = new CookieContainer();
			var cookie = new Cookie("TestCookie", "TestValue", "/", "microsoft.com");
			cookieContainer.Add(cookie);
			_viewModel.Cookies = cookieContainer;
		}

		private void ClearCookies_Clicked(object sender, EventArgs e)
		{
			_viewModel.Cookies = new CookieContainer();
		}

		private void TestDocumentTitle_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><head><title>Test Page Title</title></head><body><h1>Page with Title</h1><p>This page has a title that can be retrieved via JavaScript.</p></body></html>"
			};
		}

		private void TestAlertFunction_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>Alert Test Page</h1><p>This page tests JavaScript alert functionality.</p><button onclick=\"alert('Test Alert')\">Test Alert</button><script>setTimeout(function() { console.log('Page loaded'); }, 1000);</script></body></html>"
			};
		}

		private void LoadPage1_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>Navigation Test - Page 1</h1><p>This is the first page for navigation testing.</p><a href=\"#page2\" onclick=\"loadPage2()\">Go to Page 2</a><script>function loadPage2() { window.location.href = 'data:text/html,<html><body><h1>Navigation Test - Page 2</h1><p>This is the second page.</p></body></html>'; }</script></body></html>"
			};
		}

		private void LoadPage2_Clicked(object sender, EventArgs e)
		{
			_viewModel.Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>Navigation Test - Page 2</h1><p>This is the second page for navigation testing.</p><button onclick=\"history.back()\">Go Back</button></body></html>"
			};
		}
	}
}