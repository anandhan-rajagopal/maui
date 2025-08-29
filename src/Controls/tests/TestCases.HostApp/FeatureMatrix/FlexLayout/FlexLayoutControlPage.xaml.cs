namespace Maui.Controls.Sample;

public class FlexLayoutControlPage : NavigationPage
{
    FlexLayoutViewModel _viewModel;
    public FlexLayoutControlPage()
    {
        _viewModel = new FlexLayoutViewModel();
        PushAsync(new FlexLayoutControlMainPage(_viewModel));
    }
}

public partial class FlexLayoutControlMainPage : ContentPage
{
    FlexLayoutViewModel _viewModel;
    public FlexLayoutControlMainPage(FlexLayoutViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
    {
        BindingContext = _viewModel = new FlexLayoutViewModel();
        await Navigation.PushAsync(new FlexLayoutOptionsPage(_viewModel));
    }
}
