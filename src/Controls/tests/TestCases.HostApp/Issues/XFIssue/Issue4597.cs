

namespace Maui.Controls.Sample.Issues;

[Issue(IssueTracker.Github, 4597, "[Android] ImageCell not loading images and setting ImageSource to null has no effect",
	PlatformAffected.Android)]
public class Issue4597 : TestContentPage
{
	ImageButton _imageButton;
	Button _button;
	Image _image;
	ListView _listView;

	string _disappearText = "You should see an Image. Clicking this should cause the image to disappear";
	string _appearText = "Clicking this should cause the image to reappear";
	string _theListView = "theListViewAutomationId";
	string _fileName = "coffee.png";
	string _uriImage = "https://raw.githubusercontent.com/dotnet/maui/main/src/Compatibility/ControlGallery/src/Android/Resources/drawable/coffee.png";
	bool _isUri = false;
	string _nextTestId = "NextTest";
	string _activeTestId = "activeTestId";
	string _switchUriId = "SwitchUri";
	string _imageFromUri = "Image From Uri";
	string _imageFromFile = "Image From File";
	string _ButtonAutomationId = "Button";
	string _fileNameAutomationId = "Image";   
	string _imageButtonAutomationId = "ImageButton"; 
	string _listViewAutomationId = "ListView";   

	protected override void Init()
	{
		Label labelActiveTest = new Label()
		{
			AutomationId = _activeTestId
		};

		_image = new Image() { Source = _fileName, AutomationId = _fileNameAutomationId };
		_button = new Button() { ImageSource = _fileName, AutomationId = _ButtonAutomationId };
		_imageButton = new ImageButton() { Source = _fileName, AutomationId = _imageButtonAutomationId };
		_listView = new ListView()
		{
			ItemTemplate = new DataTemplate(() =>
			{
				var cell = new ImageCell();
				cell.SetBinding(ImageCell.ImageSourceProperty, ".");
				cell.AutomationId = _listViewAutomationId;
				return cell;
			}),
			AutomationId = _theListView,
			ItemsSource = new[] { _fileName },
			HasUnevenRows = true,
			BackgroundColor = Colors.Purple
		};

		View[] imageControls = new View[] { _image, _button, _imageButton, _listView };

		Button button = null;
		button = new Button()
		{
			AutomationId = "ClickMe",
			Text = _disappearText,
			Command = new Command(() =>
			{
				if (button.Text == _disappearText)
				{
					_image.Source = null;
					_button.ImageSource = null;
					_imageButton.Source = null;
					_listView.ItemsSource = new string[] { null };
					MainThread.BeginInvokeOnMainThread(() => button.Text = _appearText);
				}
				else
				{
					_image.Source = _isUri ? _uriImage : _fileName;
					_button.ImageSource = _isUri ? _uriImage : _fileName;
					_imageButton.Source = _isUri ? _uriImage : _fileName;
					_listView.ItemsSource = new string[] { _isUri ? _uriImage : _fileName };
					MainThread.BeginInvokeOnMainThread(() => button.Text = _disappearText);
				}
			})
		};

		var switchToUri = new Switch
		{
			AutomationId = _switchUriId,
			IsToggled = false,
			HeightRequest = 60
		};
		var sourceLabel = new Label { Text = _imageFromFile, AutomationId = "SourceLabel" };

		switchToUri.Toggled += (_, e) =>
		{
			_isUri = e.Value;
			button.Text = _appearText;
			button.SendClicked();

			if (_isUri)
				sourceLabel.Text = _imageFromUri;
			else
				sourceLabel.Text = _imageFromFile;
		};


		foreach (var view in imageControls)
		{
			view.BackgroundColor = Colors.Red;
		}

		StackLayout layout = null;

		StackLayout horizontalStackLayout = new() { Orientation = StackOrientation.Horizontal };

		horizontalStackLayout.Add(labelActiveTest);
		horizontalStackLayout.Add(switchToUri);
		horizontalStackLayout.Add(sourceLabel);

		var loadNextButton = new Button()
		{
			Text = "Load Next Image Control to Test",
			Command = new Command(() =>
			{
				var activeImage = (View)layout.Children.Last();
				int nextIndex = imageControls.ToList().IndexOf(activeImage) + 1;

				if (nextIndex >= imageControls.Length)
					nextIndex = 0;

				layout.Remove(activeImage);
				layout.Add(imageControls[nextIndex]);
				labelActiveTest.Text = imageControls[nextIndex].GetType().Name;
				button.Text = _appearText;
				button.SendClicked();
			}),
			AutomationId = _nextTestId
		};


		layout = new StackLayout()
		{
			AutomationId = "layoutContainer"
		};

		layout.Add(horizontalStackLayout);
		layout.Add(button);
		layout.Add(loadNextButton);
		layout.Add(imageControls[0]);

		Content = layout;
		labelActiveTest.Text = imageControls[0].GetType().Name;
	}

}


