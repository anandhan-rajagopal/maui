using Microsoft.Maui.Layouts;

namespace Maui.Controls.Sample;

public partial class FlexLayoutOptionsPage : ContentPage
{
    FlexLayoutViewModel _viewModel;
    public FlexLayoutOptionsPage(FlexLayoutViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    async void ApplyButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    void OnAlignContentChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexAlignContent>(rb.Content.ToString(), out var v))
            _viewModel.AlignContent = v;
    }
    void OnAlignItemsChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexAlignItems>(rb.Content.ToString(), out var v))
            _viewModel.AlignItems = v;
    }
    void OnDirectionChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexDirection>(rb.Content.ToString(), out var v))
            _viewModel.Direction = v;
    }
    void OnJustifyContentChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexJustify>(rb.Content.ToString(), out var v))
            _viewModel.JustifyContent = v;
    }
    void OnWrapChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexWrap>(rb.Content.ToString(), out var v))
            _viewModel.Wrap = v;
    }
    void OnChild1AlignSelfChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexAlignSelf>(rb.Content.ToString(), out var v))
            _viewModel.Child1AlignSelf = v;
    }
    void OnChild1BasisChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        _viewModel.Child1BasisMode = rb.Content.ToString();
    }
    void OnChild1PositionChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;
        var rb = (RadioButton)sender;
        if (Enum.TryParse<FlexPosition>(rb.Content.ToString(), out var v))
            _viewModel.Child1Position = v;
    }
}
