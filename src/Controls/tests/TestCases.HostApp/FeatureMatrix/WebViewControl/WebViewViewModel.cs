using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public class WebViewViewModel : INotifyPropertyChanged
	{
		private WebViewSource _source;
		private string _userAgent;
		private CookieContainer _cookies;
		private bool _canGoBack;
		private bool _canGoForward;
		private bool _isEnabled = true;
		private bool _isVisible = true;
		private string _navigatingStatus;
		private string _navigatedStatus;
		private string _processTerminatedStatus;
		private string _jsEvaluationResult;
		private bool _isEventStatusLabelVisible = false;

		public event PropertyChangedEventHandler PropertyChanged;

		public WebViewViewModel()
		{
			// Initialize with a simple HTML page
			Source = new HtmlWebViewSource
			{
				Html = "<html><body><h1>WebView Feature Matrix Test</h1><p>Initial content loaded.</p><button onclick=\"testFunction()\">Test Button</button><script>function testFunction() { alert('Button clicked!'); }</script></body></html>"
			};

			GoBackCommand = new Command(OnGoBack, () => CanGoBack);
			GoForwardCommand = new Command(OnGoForward, () => CanGoForward);
			ReloadCommand = new Command(OnReload);
			EvaluateJavaScriptCommand = new Command(OnEvaluateJavaScript);
		}

		public WebViewSource Source
		{
			get => _source;
			set
			{
				if (_source != value)
				{
					_source = value;
					OnPropertyChanged();
				}
			}
		}

		public string UserAgent
		{
			get => _userAgent;
			set
			{
				if (_userAgent != value)
				{
					_userAgent = value;
					OnPropertyChanged();
				}
			}
		}

		public CookieContainer Cookies
		{
			get => _cookies;
			set
			{
				if (_cookies != value)
				{
					_cookies = value;
					OnPropertyChanged();
				}
			}
		}

		public bool CanGoBack
		{
			get => _canGoBack;
			set
			{
				if (_canGoBack != value)
				{
					_canGoBack = value;
					OnPropertyChanged();
					((Command)GoBackCommand).ChangeCanExecute();
				}
			}
		}

		public bool CanGoForward
		{
			get => _canGoForward;
			set
			{
				if (_canGoForward != value)
				{
					_canGoForward = value;
					OnPropertyChanged();
					((Command)GoForwardCommand).ChangeCanExecute();
				}
			}
		}

		public bool IsEnabled
		{
			get => _isEnabled;
			set
			{
				if (_isEnabled != value)
				{
					_isEnabled = value;
					OnPropertyChanged();
				}
			}
		}

		public bool IsVisible
		{
			get => _isVisible;
			set
			{
				if (_isVisible != value)
				{
					_isVisible = value;
					OnPropertyChanged();
				}
			}
		}

		public string NavigatingStatus
		{
			get => _navigatingStatus;
			set
			{
				if (_navigatingStatus != value)
				{
					if (!string.IsNullOrEmpty(value))
					{
						IsEventStatusLabelVisible = true;
					}
					_navigatingStatus = value;
					OnPropertyChanged();
				}
			}
		}

		public string NavigatedStatus
		{
			get => _navigatedStatus;
			set
			{
				if (_navigatedStatus != value)
				{
					if (!string.IsNullOrEmpty(value))
					{
						IsEventStatusLabelVisible = true;
					}
					_navigatedStatus = value;
					OnPropertyChanged();
				}
			}
		}

		public string ProcessTerminatedStatus
		{
			get => _processTerminatedStatus;
			set
			{
				if (_processTerminatedStatus != value)
				{
					if (!string.IsNullOrEmpty(value))
					{
						IsEventStatusLabelVisible = true;
					}
					_processTerminatedStatus = value;
					OnPropertyChanged();
				}
			}
		}

		public string JsEvaluationResult
		{
			get => _jsEvaluationResult;
			set
			{
				if (_jsEvaluationResult != value)
				{
					_jsEvaluationResult = value;
					OnPropertyChanged();
				}
			}
		}

		public bool IsEventStatusLabelVisible
		{
			get => _isEventStatusLabelVisible;
			set
			{
				if (_isEventStatusLabelVisible != value)
				{
					_isEventStatusLabelVisible = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand GoBackCommand { get; }
		public ICommand GoForwardCommand { get; }
		public ICommand ReloadCommand { get; }
		public ICommand EvaluateJavaScriptCommand { get; }

		public WebView WebViewReference { get; set; }

		private void OnGoBack()
		{
			WebViewReference?.GoBack();
		}

		private void OnGoForward()
		{
			WebViewReference?.GoForward();
		}

		private void OnReload()
		{
			WebViewReference?.Reload();
		}

		private async void OnEvaluateJavaScript()
		{
			if (WebViewReference != null)
			{
				try
				{
					var result = await WebViewReference.EvaluateJavaScriptAsync("document.title");
					JsEvaluationResult = $"JS Result: {result}";
				}
				catch (Exception ex)
				{
					JsEvaluationResult = $"JS Error: {ex.Message}";
				}
			}
		}

		public void OnNavigating(object sender, WebNavigatingEventArgs e)
		{
			NavigatingStatus = $"Navigating to: {e.Url}";
		}

		public void OnNavigated(object sender, WebNavigatedEventArgs e)
		{
			NavigatedStatus = $"Navigated to: {e.Url} - Result: {e.Result}";
			
			if (WebViewReference != null)
			{
				CanGoBack = WebViewReference.CanGoBack;
				CanGoForward = WebViewReference.CanGoForward;
			}
		}

		public void OnProcessTerminated(object sender, EventArgs e)
		{
			ProcessTerminatedStatus = "WebView process terminated";
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}