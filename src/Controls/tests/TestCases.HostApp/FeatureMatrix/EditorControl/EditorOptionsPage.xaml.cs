using Microsoft.Maui.Controls;
using System;

namespace Maui.Controls.Sample;

public partial class EditorOptionsPage : ContentPage
{
    private EditorViewModel _viewModel;

    public EditorOptionsPage(EditorViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void ApplyButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && !string.IsNullOrEmpty(entry.Text))
        {
            _viewModel.Text = entry.Text;
        }
    }

    private void FontSizeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && double.TryParse(entry.Text, out double fontSize))
        {
            _viewModel.FontSize = fontSize;
        }
    }

    private void CharacterSpacing_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && double.TryParse(entry.Text, out double spacing))
        {
            _viewModel.CharacterSpacing = spacing;
        }
    }

    private void MaxLength_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry && int.TryParse(entry.Text, out int maxLength))
        {
            _viewModel.MaxLength = maxLength;
        }
    }

    private void PlaceholderText_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            _viewModel.Placeholder = entry.Text ?? "";
        }
    }

    private void FontFamily_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            _viewModel.FontFamily = entry.Text;
        }
    }

    private void AutoSize_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.AutoSize = radioButton.AutomationId switch
            {
                "AutoSizeDisabledRadio" => EditorAutoSizeOption.Disabled,
                "AutoSizeTextChangesRadio" => EditorAutoSizeOption.TextChanges,
                _ => EditorAutoSizeOption.Disabled
            };
        }
    }

    private void IsReadOnlyTrueOrFalse_Clicked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.IsReadOnly = radioButton.AutomationId == "ReadOnlyTrue";
        }
    }

    private void IsTextPredictionEnabledTrueOrFalse_Clicked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.IsTextPredictionEnabled = radioButton.AutomationId == "TextPredictionTrue";
        }
    }

    private void IsEnabledTrueOrFalse_Clicked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.IsEnabled = radioButton.AutomationId == "EnabledTrue";
        }
    }

    private void IsVisibleTrueOrFalse_Clicked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.IsVisible = radioButton.AutomationId == "VisibleTrue";
        }
    }

    private void FlowDirection_Clicked(object sender, CheckedChangedEventArgs e)
    {
        if (sender is RadioButton radioButton && radioButton.IsChecked)
        {
            _viewModel.FlowDirection = radioButton.AutomationId == "FlowDirectionRightToLeft" 
                ? FlowDirection.RightToLeft 
                : FlowDirection.LeftToRight;
        }
    }

    private void TextColorButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _viewModel.TextColor = button.BackgroundColor;
        }
    }

    private void PlaceholderColorButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _viewModel.PlaceholderColor = button.BackgroundColor;
        }
    }

    private void FontAttributesButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _viewModel.FontAttributes = button.AutomationId switch
            {
                "FontAttributesBold" => FontAttributes.Bold,
                "FontAttributesItalic" => FontAttributes.Italic,
                _ => FontAttributes.None
            };
        }
    }

    private void KeyboardButton_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button)
        {
            _viewModel.Keyboard = button.AutomationId switch
            {
                "Email" => Keyboard.Email,
                "Numeric" => Keyboard.Numeric,
                _ => Keyboard.Default
            };
        }
    }
}