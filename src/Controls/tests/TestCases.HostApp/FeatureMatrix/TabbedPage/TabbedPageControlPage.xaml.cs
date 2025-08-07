using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class TabbedPageControlPage : NavigationPage
{
	public TabbedPageControlPage()
	{
		PushAsync(new TabbedPageControlMainPage());
	}
}

public partial class TabbedPageControlMainPage : ContentPage
{
	private TabbedPageViewModel _viewModel;

	public TabbedPageControlMainPage()
	{
		InitializeComponent();
		_viewModel = new TabbedPageViewModel();
		BindingContext = _viewModel;
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
        BindingContext = _viewModel = new TabbedPageViewModel();
		await Navigation.PushModalAsync(new TabbedPageOptionsPage(_viewModel));
	}
}
