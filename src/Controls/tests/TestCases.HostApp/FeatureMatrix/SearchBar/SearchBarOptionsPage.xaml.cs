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

		private void CancelButtonColor_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.CancelButtonColor = button.BackgroundColor;
			}
		}

		private void FontAttributes_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.FontAttributes = button.FontAttributes;
			}
		}
		private void FontAutoScalingEnabled_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.FontAutoScalingEnabled = button.Text == "True" ? true : false;
			}
		}
		private void FontFamily_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.FontFamily = button.Text;
			}
		}
		private void HorizontalTextAlignment_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.HorizontalTextAlignment = button.Text == "Start" ? TextAlignment.Start : button.Text == "Center" ? TextAlignment.Center : TextAlignment.End;
			}
		}
		private void IsReadOnly_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.IsReadOnly = button.Text == "True" ? true : false;
			}
		}
		private void IsSpellCheckEnabled_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.IsSpellCheckEnabled = button.Text == "True" ? true : false;
			}
		}
		private void IsTextPredictionEnabled_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.IsSpellCheckEnabled = button.Text == "True" ? true : false;
			}
		}
		private void PlaceholderColor_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.PlaceholderColor = button.BackgroundColor;
			}
		}
		private void TextColor_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.TextColor = button.BackgroundColor;
			}
		}
		private void TextTransform_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.TextTransform = button.Text == "None" ? TextTransform.None : button.Text == "Uppercase" ? TextTransform.Uppercase : TextTransform.Lowercase;
			}
		}
		private void VerticalTextAlignment_Clicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if (button != null)
			{
				_viewModel.VerticalTextAlignment = button.Text == "Start" ? TextAlignment.Start : button.Text == "Center" ? TextAlignment.Center : TextAlignment.End;
			}
		}
	}
}