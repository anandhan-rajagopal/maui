using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public partial class EditorOptionsPage : ContentPage
{
	private EditorViewModel _viewModel;

	public EditorOptionsPage(EditorViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
		
		// Initialize the UI with current values
		InitializeUI();
	}

	private void InitializeUI()
	{
		TextEntry.Text = _viewModel.Text;
		CharacterSpacingEntry.Text = _viewModel.CharacterSpacing.ToString();
		FontFamilyEntry.Text = _viewModel.FontFamily;
		FontSizeEntry.Text = _viewModel.FontSize.ToString();
		PlaceholderEntry.Text = _viewModel.Placeholder;
		MaxLengthEntry.Text = _viewModel.MaxLength.ToString();
	}

	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();
	}

	private void OnTextChanged(object sender, TextChangedEventArgs e)
	{
		_viewModel.Text = TextEntry.Text ?? "";
	}

	private void OnCharacterSpacingChanged(object sender, TextChangedEventArgs e)
	{
		if (double.TryParse(CharacterSpacingEntry.Text, out double spacing))
		{
			_viewModel.CharacterSpacing = spacing;
		}
	}

	private void OnFontAttributesCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (FontAttributesNoneRadio.IsChecked)
			_viewModel.FontAttributes = FontAttributes.None;
		else if (FontAttributesBoldRadio.IsChecked)
			_viewModel.FontAttributes = FontAttributes.Bold;
		else if (FontAttributesItalicRadio.IsChecked)
			_viewModel.FontAttributes = FontAttributes.Italic;
	}

	private void OnFontFamilyChanged(object sender, TextChangedEventArgs e)
	{
		_viewModel.FontFamily = FontFamilyEntry.Text ?? "";
	}

	private void OnFontSizeChanged(object sender, TextChangedEventArgs e)
	{
		if (double.TryParse(FontSizeEntry.Text, out double size) && size > 0)
		{
			_viewModel.FontSize = size;
		}
	}

	private void OnTextColorCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (TextColorBlackRadio.IsChecked)
			_viewModel.TextColor = Colors.Black;
		else if (TextColorRedRadio.IsChecked)
			_viewModel.TextColor = Colors.Red;
		else if (TextColorBlueRadio.IsChecked)
			_viewModel.TextColor = Colors.Blue;
	}

	private void OnPlaceholderChanged(object sender, TextChangedEventArgs e)
	{
		_viewModel.Placeholder = PlaceholderEntry.Text ?? "";
	}

	private void OnPlaceholderColorCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (PlaceholderColorGrayRadio.IsChecked)
			_viewModel.PlaceholderColor = Colors.Gray;
		else if (PlaceholderColorRedRadio.IsChecked)
			_viewModel.PlaceholderColor = Colors.Red;
		else if (PlaceholderColorBlueRadio.IsChecked)
			_viewModel.PlaceholderColor = Colors.Blue;
	}

	private void OnMaxLengthChanged(object sender, TextChangedEventArgs e)
	{
		if (int.TryParse(MaxLengthEntry.Text, out int maxLength))
		{
			_viewModel.MaxLength = maxLength;
		}
	}

	private void OnIsReadOnlyCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.IsReadOnly = IsReadOnlyTrueRadio.IsChecked;
	}

	private void OnIsTextPredictionEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.IsTextPredictionEnabled = IsTextPredictionEnabledTrueRadio.IsChecked;
	}

	private void OnKeyboardCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (KeyboardDefaultRadio.IsChecked)
			_viewModel.Keyboard = Keyboard.Default;
		else if (KeyboardEmailRadio.IsChecked)
			_viewModel.Keyboard = Keyboard.Email;
		else if (KeyboardNumericRadio.IsChecked)
			_viewModel.Keyboard = Keyboard.Numeric;
	}

	private void OnAutoSizeCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (AutoSizeDisabledRadio.IsChecked)
			_viewModel.AutoSize = EditorAutoSizeOption.Disabled;
		else if (AutoSizeTextChangesRadio.IsChecked)
			_viewModel.AutoSize = EditorAutoSizeOption.TextChanges;
	}

	private void OnIsEnabledCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.IsEnabled = IsEnabledTrueRadio.IsChecked;
	}

	private void OnIsVisibleCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.IsVisible = IsVisibleTrueRadio.IsChecked;
	}

	private void OnFlowDirectionChanged(object sender, CheckedChangedEventArgs e)
	{
		_viewModel.FlowDirection = FlowDirectionLTRRadio.IsChecked ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
	}
}