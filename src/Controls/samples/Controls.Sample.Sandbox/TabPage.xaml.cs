namespace Maui.Controls.Sample;

public partial class TabPage : TabbedPage
{
	public TabPage()
	{
		InitializeComponent();
		Children.Add(new TabPageOne());
		Children.Add(new TabPageTwo());
		Children.Add(new TabPageThree());
		Children.Add(new GoToMainPage());
		Children.Add(new NavigationTabPages());
	}
}

public class NavigationTabPages : NavigationPage
{
	public NavigationTabPages()
	{
		Title = "Navigation Pages";
		Navigation.PushAsync(new NavigationPages());
	}
}

public class TabPageOne : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public TabPageOne()
	{
		Title = "Tab Test 1";

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

public class TabPageTwo : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public TabPageTwo()
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

public class TabPageThree : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public TabPageThree()
	{
		Title = "Tab Test 3";

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

public class GoToMainPage : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public GoToMainPage()
	{
		Title = "Go To Main Page";

		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Go To Main Page", FontSize = 18, FontAttributes = FontAttributes.Bold },
				_navigatedToLabel,
				_navigatingFromLabel,
				_navigatedFromLabel,
				new Button
				{
					Text = "Go To Main Page Button",
					Command = new Command(() =>
					{
						var window = Application.Current?.Windows.FirstOrDefault();
						if (window != null)
						{
							window.Page = new MainPage();
						}
					})
				}
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