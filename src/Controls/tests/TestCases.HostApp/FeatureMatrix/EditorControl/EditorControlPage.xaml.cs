using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class EditorControlPage : NavigationPage
{

	public EditorControlPage()
	{
		PushAsync(new EditorControlMainPage());
	}
}

public partial class EditorControlMainPage : ContentPage
{
	private EditorViewModel _viewModel;

	public EditorControlMainPage()
	{
		InitializeComponent();
		BindingContext = _viewModel = new EditorViewModel();
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EditorOptionsPage(_viewModel));
	}

	private void OnTextChanged(object sender, TextChangedEventArgs e)
	{
		if (_viewModel != null)
		{
			_viewModel.TextChangedEventText = $"Changed: {e.NewTextValue}";
		}
	}
}