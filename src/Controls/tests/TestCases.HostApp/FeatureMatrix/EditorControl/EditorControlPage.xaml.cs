using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample;

public class EditorControlPage : NavigationPage
{
    private EditorViewModel _viewModel;

    public EditorControlPage()
    {
        _viewModel = new EditorViewModel();
        PushAsync(new EditorControlMainPage(_viewModel));
    }
}

public partial class EditorControlMainPage : ContentPage
{
    private EditorViewModel _viewModel;

    public EditorControlMainPage(EditorViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
    {
        // Reset the view model to default values
        BindingContext = _viewModel = new EditorViewModel();
        _viewModel.Text = "Test Editor";
        _viewModel.Placeholder = "Enter text here";
        await Navigation.PushAsync(new EditorOptionsPage(_viewModel));
    }

    private void EditorControl_TextChanged(object sender, TextChangedEventArgs e)
    {
        string eventInfo = $"TextChanged: Old='{e.OldTextValue}', New='{e.NewTextValue}'";

        if (BindingContext is EditorViewModel vm)
        {
            vm.TextChangedText = eventInfo;
        }
    }
}