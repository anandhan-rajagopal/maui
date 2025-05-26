using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	
	public class StepperControlPage : NavigationPage
{
	private StepperViewModel _viewModel;

	public StepperControlPage()
	{
		_viewModel = new StepperViewModel();
		PushAsync(new StepperControlMainPage(_viewModel));
	}
}
    public partial class StepperControlMainPage : ContentPage
	{
		private StepperViewModel _viewModel;

		public StepperControlMainPage(StepperViewModel viewModel)
		{
			InitializeComponent();
			_viewModel = viewModel;
			BindingContext = _viewModel;
		}

        private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
        {
            BindingContext = _viewModel = new StepperViewModel();
            await Navigation.PushAsync(new StepperFeaturePage(_viewModel));
        }
    }
}