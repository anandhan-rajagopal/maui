using System;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Maui.Controls.Sample
{
    public partial class CollectionViewOptionsPage : ContentPage
    {
        private CollectionViewViewModel _viewModel;

        public CollectionViewOptionsPage(CollectionViewViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private void ApplyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnEmptyViewChanged(object sender, CheckedChangedEventArgs e)
        {
            if (EmptyViewNone.IsChecked)
            {
                _viewModel.EmptyView = null;
            }
            else if (EmptyViewString.IsChecked)
            {
                _viewModel.EmptyView = "No Items Available(String)";
            }
            else if (EmptyViewGrid.IsChecked)
            {
                Grid grid = new Grid
                {
                    BackgroundColor = Colors.LightGray,
                    Padding = new Thickness(10)
                };
                grid.Children.Add(new Label
                {
                    Text = "No Items Available(Grid View)",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 18,
                    TextColor = Colors.Blue,
                    AutomationId = "EmptyViewLabel"
                });
                _viewModel.EmptyView = grid;
            }
        }

        private void OnItemsSourceChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!(sender is RadioButton radioButton) || !e.Value)
                return;
            if (radioButton == ItemsSourceGroupedList)
            {
                _viewModel.IsGrouped = true;
            }
            else
            {
                _viewModel.IsGrouped = false;
            }
            // Set ItemsSourceType based on selection
            if (radioButton == ItemsSourceList)
                _viewModel.ItemsSourceType = ItemsSourceType.ListT;
            else if (radioButton == ItemsSourceEmptyList)
                _viewModel.ItemsSourceType = ItemsSourceType.EmptyListT;
            else if (radioButton == ItemsSourceObservableCollection)
                _viewModel.ItemsSourceType = ItemsSourceType.ObservableCollectionT;
            else if (radioButton == ItemsSourceGroupedList)
                _viewModel.ItemsSourceType = ItemsSourceType.GroupedListT;
        }

        private void OnSelectionModeChanged(object sender, System.EventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                // Use AutomationId to determine the selection mode
                switch (radioButton.AutomationId)
                {
                    case "SelectionModeNone":
                        _viewModel.SelectionMode = SelectionMode.None;
                        break;
                    case "SelectionModeSingle":
                        _viewModel.SelectionMode = SelectionMode.Single;
                        break;
                    case "SelectionModeMultiple":
                        _viewModel.SelectionMode = SelectionMode.Multiple;
                        break;
                    default:
                        // Handle unexpected cases if necessary
                        break;
                }
            }
        }

        private void OnSelectionModeButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                // Use AutomationId to determine the selection mode
                switch (button.AutomationId)
                {
                    case "SelectionModeNone":
                        _viewModel.SelectionMode = SelectionMode.None;
                        break;
                    case "SelectionModeSingle":
                        _viewModel.SelectionMode = SelectionMode.Single;
                        break;
                    case "SelectionModeMultiple":
                        _viewModel.SelectionMode = SelectionMode.Multiple;
                        break;
                    default:
                        // Handle unexpected cases if necessary
                        break;
                }
            }
        }
    }
}
