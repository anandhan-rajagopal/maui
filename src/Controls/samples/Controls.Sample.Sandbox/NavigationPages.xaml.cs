namespace Maui.Controls.Sample;

public class NavigationMainPages : NavigationPage
{
	public NavigationMainPages()
	{
		Navigation.PushAsync(new NavigationPages());
	}
}

public partial class NavigationPages : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationPages()
	{
		InitializeComponent();
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
					Command = new Command(() => Navigation.PushAsync(new NavigationPageOne()))
				},
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

public class NavigationPageOne : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationPageOne()
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
				new Label { Text = "First Page", FontSize = 18, FontAttributes = FontAttributes.Bold },
				new Button
				{
					Text = "Pop Back",
					Command = new Command(() => Navigation.PopAsync())
				},
				new Button
				{
					Text = "Push Second Page",
					Command = new Command(() => Navigation.PushAsync(new NavigationPageTwo()))
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
public class NavigationPageTwo : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationPageTwo()
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
					Command = new Command(() => Navigation.PushAsync(new NavigationPageThree()))
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
public class NavigationPageThree : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationPageThree()
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
					Text = "Insert Fourth Page",
					Command = new Command(() =>
					{
						Navigation.InsertPageBefore(new NavigationPageFour(), this);
						Navigation.PopAsync();
					}),
				},
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

public class NavigationPageFour : ContentPage
{
	readonly Label _navigatedToLabel;
	readonly Label _navigatingFromLabel;
	readonly Label _navigatedFromLabel;

	public NavigationPageFour()
	{
		Title = "Fourth Page";

		_navigatedToLabel = new Label { Text = "NavigatedTo: -" };
		_navigatingFromLabel = new Label { Text = "NavigatingFrom: -" };
		_navigatedFromLabel = new Label { Text = "NavigatedFrom: -" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
			{
				new Label { Text = "Fourth Page", FontSize = 18, FontAttributes = FontAttributes.Bold },
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