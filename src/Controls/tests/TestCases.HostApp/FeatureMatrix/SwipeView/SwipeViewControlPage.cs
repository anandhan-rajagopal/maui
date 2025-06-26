using Microsoft.Maui.Controls;
using System;

namespace Maui.Controls.Sample;

public class SwipeViewControlPage : NavigationPage
{
	public SwipeViewControlPage()
	{
		var vm = new SwipeViewViewModel();
		var mainPage = new SwipeViewControlMainPage(vm);
		PushAsync(mainPage);
	}
}

public class SwipeViewControlMainPage : ContentPage
{
	private SwipeViewViewModel _viewModel;
	private VerticalStackLayout layout;

	public SwipeViewControlMainPage(SwipeViewViewModel viewModel)
	{
		Title = "SwipeView Control";
		_viewModel = viewModel;
		BindingContext = _viewModel;

		ToolbarItems.Add(new ToolbarItem
		{
			Text = "Options",
			Command = new Command(async () =>
			{
				await Navigation.PushAsync(new SwipeViewOptionsPage(_viewModel, this));
			})
		});

		layout = new VerticalStackLayout
		{
			Padding = 20,
			Spacing = 8,
			Children =
		{
			// 1. Title Label
			new Label
			{
				Text = "SwipeView Control Label",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
				Margin = new Thickness(0, 0, 0, 10)
			},

			// 2. SwipeView content
			ApplyContentWithSwipeItems("Label", "Label"),

			// 3. Space 150
			new BoxView
			{
				HeightRequest = 150,
				Color = Colors.Transparent
			},

			// 4. Programmatic Actions label
			new Label
			{
				Text = "Programmatic Actions:",
				FontSize = 11,
				Margin = new Thickness(0, 10, 0, 0)
			},

			// 5. Buttons
			CreateProgrammaticActionButtons(),

			// 6. Event Labels
			new Label { Text = "Events:", FontSize = 11, FontAttributes = FontAttributes.Bold },

			new Label { FontSize = 11, TextColor = Colors.Red, AutomationId = "EventInvokedLabel" }
				.ApplyBinding(Label.TextProperty, nameof(_viewModel.EventInvokedText)),

			new Label { FontSize = 11, TextColor = Colors.Red, AutomationId = "SwipeStartedLabel" }
				.ApplyBinding(Label.TextProperty, nameof(_viewModel.SwipeStartedText)),

			new Label { FontSize = 11, TextColor = Colors.Red, AutomationId = "SwipeChangingLabel" }
				.ApplyBinding(Label.TextProperty, nameof(_viewModel.SwipeChangingText)),

			new Label { FontSize = 11, TextColor = Colors.Red, AutomationId = "SwipeEndedLabel" }
				.ApplyBinding(Label.TextProperty, nameof(_viewModel.SwipeEndedText))
		}
		};

		Content = layout;
	}

	private View ApplyContentWithSwipeItems(string contentType, string swipeItemType)
	{
		View finalContent;

		switch (contentType)
		{
			case "Label":
				var label = new Label
				{
					Text = "SwipeView Content",
					FontSize = 18,
					HeightRequest = 150,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};

				finalContent = CreateSwipeView(label, swipeItemType);
				break;

			case "Image":
				var image = new Image
				{
					Source = "dotnet_bot.png",
					Aspect = Aspect.AspectFit,
					HeightRequest = 150,
					WidthRequest = 150,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};

				finalContent = CreateSwipeView(image, swipeItemType);
				break;

			case "CollectionView":
				var collectionView = new CollectionView
				{
					ItemsSource = _viewModel.Items,
					ItemTemplate = new DataTemplate(() =>
					{
						var itemLabel = new Label { FontSize = 18 };
						itemLabel.SetBinding(Label.TextProperty, nameof(SwipeViewViewModel.ItemModel.Title));

						var swipeItems = CreateSwipeItems(swipeItemType);
						var swipeView = new SwipeView
						{
							Content = itemLabel,
							LeftItems = swipeItems,
							RightItems = swipeItems,
							TopItems = swipeItems,
							BottomItems = swipeItems
						};

						swipeView.SetBinding(BindingContextProperty, ".");
						AttachSwipeEvents(swipeView);
						return swipeView;
					})
				};
				finalContent = collectionView;
				break;

			default:
				finalContent = new Label { Text = "Default Content" };
				break;
		}

		if (finalContent is SwipeView swipe)
		{
			_viewModel.RequestOpen += dir => swipe.Open(dir);
			_viewModel.RequestClose += () => swipe.Close();
		}

		return finalContent;
	}

	private SwipeItems CreateSwipeItems(string type)
	{
		var swipeItems = new SwipeItems
		{
			Mode = _viewModel.SwipeMode,
			SwipeBehaviorOnInvoked = _viewModel.SwipeBehaviorOnInvoked
		};

		switch (type)
		{
			case "Label":
				var labelItem = new SwipeItem
				{
					Text = "Label",
					BackgroundColor = _viewModel.SwipeItemsBackgroundColor
				};
				labelItem.Invoked += (s, e) => _viewModel.EventInvokedText = "Label Invoked";
				swipeItems.Add(labelItem);
				break;

			case "IconImageSource":
				var iconItem = new SwipeItem
				{
					Text = "Icon",
					IconImageSource = "groceries.png",
					BackgroundColor = _viewModel.SwipeItemsBackgroundColor
				};
				iconItem.Invoked += (s, e) => _viewModel.EventInvokedText = "Icon Invoked";
				swipeItems.Add(iconItem);
				break;

			case "Button":
				var button = new Button
				{
					Text = "Click Me",
					BackgroundColor = _viewModel.SwipeItemsBackgroundColor,
					Padding = new Thickness(5)
				};
				button.Clicked += (s, e) => _viewModel.EventInvokedText = "Button Clicked";

				swipeItems.Add(new SwipeItemView { Content = button });
				break;
		}

		return swipeItems;
	}

	private SwipeView CreateSwipeView(View contentView, string swipeItemType)
	{
		var swipeItems = CreateSwipeItems(swipeItemType);

		var swipeView = new SwipeView
		{
			Content = contentView,
			LeftItems = swipeItems,
			RightItems = swipeItems,
			TopItems = swipeItems,
			BottomItems = swipeItems,
			Threshold = _viewModel.Threshold,
			FlowDirection = _viewModel.FlowDirection,
			BackgroundColor = _viewModel.BackgroundColor,
			IsEnabled = _viewModel.IsEnabled,
			IsVisible = _viewModel.IsVisible
		};

		AttachSwipeEvents(swipeView);
		return swipeView;
	}

	private void AttachSwipeEvents(SwipeView swipeView)
	{
		swipeView.SwipeStarted += (s, e) =>
			_viewModel.SwipeStartedText = $"Swipe Started: {e.SwipeDirection}";

		swipeView.SwipeChanging += (s, e) =>
			_viewModel.SwipeChangingText = $"Swipe Changing: {e.SwipeDirection}, Offset: {e.Offset}";

		swipeView.SwipeEnded += (s, e) =>
			_viewModel.SwipeEndedText = $"Swipe Ended: {e.SwipeDirection}, IsOpen: {(e.IsOpen ? "Open" : "Closed")}";
	}

	private View CreateProgrammaticActionButtons()
	{
		return new Grid
		{
			ColumnSpacing = 10,
			Margin = new Thickness(0, 10, 0, 10),
			RowDefinitions =
			{
				new RowDefinition { Height = GridLength.Auto },
				new RowDefinition { Height = GridLength.Auto }
			},
			ColumnDefinitions =
			{
				new ColumnDefinition { Width = GridLength.Star },
				new ColumnDefinition { Width = GridLength.Star }
			},
			Children =
			{
				new Label { Text = "Programmatic Actions:", FontSize = 11 }
					.AssignToGrid(0, 0, 1, 2),

				new HorizontalStackLayout
				{
					Spacing = 5,
					Children =
					{
						new Button { Text = "Open Left", FontSize = 11, Command = _viewModel.OpenLeftCommand, AutomationId = "OpenLeft" },
						new Button { Text = "Open Right", FontSize = 11, Command = _viewModel.OpenRightCommand, AutomationId = "OpenRight" }
					}
				}.AssignToGrid(1, 0),

				new HorizontalStackLayout
				{
					Spacing = 5,
					Children =
					{
						new Button { Text = "Open Top", FontSize = 11, Command = _viewModel.OpenTopCommand, AutomationId = "OpenTop" },
						new Button { Text = "Open Bottom", FontSize = 11, Command = _viewModel.OpenBottomCommand, AutomationId = "OpenBottom" }
					}
				}.AssignToGrid(1, 1)
			}
		};
	}

	public void UpdateSwipeViewContent(string contentType, string swipeItemType)
	{
		var newContent = ApplyContentWithSwipeItems(contentType, swipeItemType);
		layout.Children[1] = newContent;
		if (newContent is SwipeView swipeView)
		{
			_viewModel.RequestOpen += dir => swipeView.Open(dir);
			_viewModel.RequestClose += () => swipeView.Close();
		}
	}

}

public static class ViewExtensions
{
	public static TView AssignToGrid<TView>(this TView view, int row, int column, int rowSpan = 1, int columnSpan = 1) where TView : View
	{
		Grid.SetRow(view, row);
		Grid.SetColumn(view, column);
		if (rowSpan > 1)
			Grid.SetRowSpan(view, rowSpan);
		if (columnSpan > 1)
			Grid.SetColumnSpan(view, columnSpan);
		return view;
	}

	public static TView ApplyBinding<TView>(this TView view, BindableProperty property, string path) where TView : BindableObject
	{
		view.SetBinding(property, path);
		return view;
	}
}