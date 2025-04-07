namespace Maui.Controls.Sample;

public partial class EditorOptionsPage : ContentPage
{
	private EditorViewModel _viewModel;
	public EditorOptionsPage(EditorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_viewModel = viewModel;
	}
	protected override void OnAppearing()
	{
		base.OnAppearing();
	}
	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnAutoSizeRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.AutoSize = radioButton.Content.ToString() == "TextChanges" ? EditorAutoSizeOption.TextChanges : EditorAutoSizeOption.Disabled;
		}
	}
	private void OnFontAttributesRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontAttributes = radioButton.Content.ToString() == "Italic" ? FontAttributes.Italic : radioButton.Content.ToString() == "Bold" ? FontAttributes.Bold : FontAttributes.None;
		}
	}
	private void OnFontFamilyRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.FontFamily = radioButton.Content.ToString() == "Dokdo" ? "Dokdo" : "MontserratBold";
		}
	}
	private void OnHorizontalTextAlignmentRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.HorizontalTextAlignment = radioButton.Content.ToString() == "Center"
				? TextAlignment.Center
				: TextAlignment.End;
		}
	}

	private void OnIsReadOnlyRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsReadOnly = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnIsSpellCheckEnabledRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsSpellCheckEnabled = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnIsTextPredictionEnabledRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.IsTextPredictionEnabled = radioButton.Content.ToString() == "True" ? true : false;
		}
	}
	private void OnKeyboardRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.Keyboard = radioButton.Content.ToString() == "Chat" ? Keyboard.Chat :
				radioButton.Content.ToString() == "Default" ? Keyboard.Default :
				radioButton.Content.ToString() == "Email" ? Keyboard.Email :
				radioButton.Content.ToString() == "Numeric" ? Keyboard.Numeric :
				radioButton.Content.ToString() == "Plain" ? Keyboard.Plain :
				radioButton.Content.ToString() == "Telephone" ? Keyboard.Telephone :
				radioButton.Content.ToString() == "Text" ? Keyboard.Text : Keyboard.Url;
		}
	}

	private void OnPlaceholderColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.PlaceholderColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}
	private void OnTextColorRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.TextColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
		}
	}

	private void OnTextTransformRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.TextTransform = radioButton.Content.ToString() == "Lowercase"
				? TextTransform.Lowercase
				: TextTransform.Uppercase;
		}
	}
	private void OnVerticalTextAlignmentRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton.IsChecked)
		{
			_viewModel.VerticalTextAlignment = radioButton.Content.ToString() == "Center"
				? TextAlignment.Center
				: TextAlignment.End;
		}
	}
}