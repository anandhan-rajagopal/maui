using System;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Maui.Controls.Sample
{
    public partial class SelectionOptionsPage : ContentPage
    {
        private CollectionViewViewModel _viewModel;

        public SelectionOptionsPage(CollectionViewViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = _viewModel;
        }

        private void ApplyButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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
                        break;
                }
            }
        }
        private void OnIsGroupedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (IsGroupedFalse.IsChecked)
            {
                _viewModel.IsGrouped = false;
            }
            else if (IsGroupedTrue.IsChecked)
            {
                _viewModel.IsGrouped = true;
            }
        }
        private void OnItemsLayoutChanged(object sender, CheckedChangedEventArgs e)
        {
            if (ItemsLayoutVerticalList.IsChecked)
            {
                _viewModel.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Vertical);
            }
            else if (ItemsLayoutHorizontalList.IsChecked)
            {
                _viewModel.ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal);
            }
            else if (ItemsLayoutVerticalGrid.IsChecked)
            {
                _viewModel.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Vertical); // 2 columns
            }
            else if (ItemsLayoutHorizontalGrid.IsChecked)
            {
                _viewModel.ItemsLayout = new GridItemsLayout(2, ItemsLayoutOrientation.Horizontal); // 2 rows
            }
        }
        private void OnItemsSourceChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!(sender is RadioButton radioButton) || !e.Value)
                return;
            else if (radioButton == ItemsSourceObservableCollection5)
                _viewModel.ItemsSourceType = ItemsSourceType.ObservableCollection5T;
            else if (radioButton == ItemsSourceGroupedList)
                _viewModel.ItemsSourceType = ItemsSourceType.GroupedListT;
            else if (radioButton == ItemsSourceNone)
                _viewModel.ItemsSourceType = ItemsSourceType.None;
        }
    }
}
