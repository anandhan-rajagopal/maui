namespace Maui.Controls.Sample;

public partial class MainPage : TabbedPage
{
	public MainPage()
	{
		InitializeComponent();
		
		// Add a custom tab page for testing tab navigation
		Children.Add(new TabTestPage());
	}
}

// Tab test page for testing Replace navigation when switching tabs
public class TabTestPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public TabTestPage()
	{
		Title = "Tab Test 2";
		
		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Tab Test Page 2", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Label { Text = "Switch between tabs to see Replace navigation events" },
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}

// Test page for Navigation (Push/Pop) scenarios
public class NavigationTestPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationTestPage()
	{
		Title = "Navigation Test";
		
		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Navigation Events Test", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Label { Text = "Test Push/Pop navigation types" },
				new Button
				{
					Text = "Push Second Page",
					Command = new Command(() => Navigation.PushAsync(new SecondPage()))
				},
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}

// Second page for navigation testing
public class SecondPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public SecondPage()
	{
		Title = "Second Page";
		
		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Second Page", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Button
				{
					Text = "Pop Back",
					Command = new Command(() => Navigation.PopAsync())
				},
				new Button
				{
					Text = "Push Third Page",
					Command = new Command(() => Navigation.PushAsync(new ThirdPage()))
				},
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}

// Third page for testing PopToRoot
public class ThirdPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public ThirdPage()
	{
		Title = "Third Page";
		
		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Third Page", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Button
				{
					Text = "Pop Back",
					Command = new Command(() => Navigation.PopAsync())
				},
				new Button
				{
					Text = "Pop to Root",
					Command = new Command(() => Navigation.PopToRootAsync())
				},
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}

// FlyoutPage for testing Replace navigation type
public class FlyoutTestPage : FlyoutPage
{
	public FlyoutTestPage()
	{
		Title = "Flyout Test";
		
		// Flyout menu
		Flyout = new ContentPage
		{
			Title = "Menu",
			Content = new StackLayout
			{
				Padding = 20,
				Children =
				{
					new Label { Text = "Flyout Menu", FontSize = 18, FontAttributes = FontAttributes.Bold },
					new Label { Text = "Test Replace navigation when switching detail pages" },
					new Button
					{
						Text = "Switch to Detail 1",
						Command = new Command(() => 
						{
							Detail = new FlyoutDetailPage("Detail 1");
							IsPresented = false;
						})
					},
					new Button
					{
						Text = "Switch to Detail 2", 
						Command = new Command(() => 
						{
							Detail = new FlyoutDetailPageTwo("Detail 2");
							IsPresented = false;
						})
					}
				}
			}
		};

		// Initial detail
		Detail = new FlyoutDetailPage("Detail 1");
	}
}

// Detail page for FlyoutPage testing
public class FlyoutDetailPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public FlyoutDetailPage(string title)
	{
		Title = title;

		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = $"Flyout {title}", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Label { Text = "Test Replace navigation type when switching flyout details" },
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}

// Detail page for FlyoutPage testing
public class FlyoutDetailPageTwo : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public FlyoutDetailPageTwo(string title)
	{
		Title = title;
		
		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = $"Flyout {title}", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Label { Text = "Test Replace navigation type when switching flyout details" },
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel
			}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_navigatedToLabel.Text = $"NavigatedTo: Previous={previousPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatingFromLabel.Text = $"NavigatingFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);
		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_navigatedFromLabel.Text = $"NavigatedFrom: Destination={destinationPage}, Type={args.NavigationType}";
	}
}