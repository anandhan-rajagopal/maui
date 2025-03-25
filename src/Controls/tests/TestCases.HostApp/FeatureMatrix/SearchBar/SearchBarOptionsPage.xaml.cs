namespace Maui.Controls.Sample
{
	public partial class SearchBarOptionsPage : ContentPage
	{
		private SearchBarViewModel _viewModel;
		public SearchBarOptionsPage(SearchBarViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		private async void ApplyButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private void OnColorsRadioButtonCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton.IsChecked)
			{
				_viewModel.CancelButtonColor = radioButton.Content.ToString() == "Red" ? Colors.Red : Colors.Green;
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
				_viewModel.FontFamily = radioButton.Content.ToString() == "Courier New" ? "Courier New" : "Times New Roman";
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
}