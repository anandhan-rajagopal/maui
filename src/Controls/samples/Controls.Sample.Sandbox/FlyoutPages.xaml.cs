namespace Maui.Controls.Sample;

public partial class FlyoutPages : FlyoutPage
{
	private readonly NavigationPage _navigationPage;

	[Obsolete]
	public FlyoutPages()
	{
		InitializeComponent();

		FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;

		Flyout = new FlyoutHomePages(this);

		_navigationPage = new NavigationPage(new FlyoutPagesOne());

		Detail = _navigationPage;
	}
	public void NavigateTo(ContentPage page)
	{
		_navigationPage.Navigation.PushAsync(page);
		IsPresented = false; // Close the flyout menu
	}
}

public class FlyoutHomePages : ContentPage
{
	readonly FlyoutPages _parentPage;

	[Obsolete]
	public FlyoutHomePages(FlyoutPages parentPage)
	{
		_parentPage = parentPage;
		Title = "Flyout Menu";

		var listView = new ListView
		{
			ItemsSource = new[]
			{
					"Item 1",
					"Item 2",
					"Item 3",
					"Go to Main Page"
				}
		};

		listView.ItemTapped += (sender, e) =>
		{
			switch (e.Item.ToString())
			{
				case "Item 1":
					_parentPage.NavigateTo(new FlyoutPagesOne());
					break;
				case "Item 2":
					_parentPage.NavigateTo(new FlyoutPagesTwo());
					break;
				case "Item 3":
					_parentPage.NavigateTo(new FlyoutPagesThree());
					break;
				case "Go to Main Page":
					_parentPage.NavigateTo(new GoToMainPage());
					break;
			}
		};

		Content = new StackLayout { Children = { listView } };
	}
}

public class FlyoutPagesOne : ContentPage
{
	readonly Label _onNavigatedToLabel;
	readonly Label _onNavigatingFromLabel;
	readonly Label _onNavigatedFromLabel;

	public FlyoutPagesOne()
	{
		Title = "Item 1";

		_onNavigatedToLabel = new Label { AutomationId = "FlyoutItem1OnNavigatedToLabel", Text = "-" };
		_onNavigatingFromLabel = new Label { AutomationId = "FlyoutItem1OnNavigatingFromLabel", Text = "-" };
		_onNavigatedFromLabel = new Label { AutomationId = "FlyoutItem1OnNavigatedFromLabel", Text = "-" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
				{
					new Label { AutomationId = "FlyoutContent1", Text = "Item 1", FontAttributes = FontAttributes.Bold, FontSize = 18 },
					new Label { Text = "OnNavigated", FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 12)},
					_onNavigatedToLabel,
					new Label { Text = "OnNavigatingFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatingFromLabel,
					new Label { Text = "OnNavigatedFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatedFromLabel
				}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_onNavigatedToLabel.Text = $"PreviousPage: {previousPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatingFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatedFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}
}

public class FlyoutPagesTwo : ContentPage
{
	readonly Label _onNavigatedToLabel;
	readonly Label _onNavigatingFromLabel;
	readonly Label _onNavigatedFromLabel;

	public FlyoutPagesTwo()
	{
		Title = "Item 2";

		_onNavigatedToLabel = new Label { AutomationId = "FlyoutItem2OnNavigatedToLabel", Text = "-" };
		_onNavigatingFromLabel = new Label { AutomationId = "FlyoutItem2OnNavigatingFromLabel", Text = "-" };
		_onNavigatedFromLabel = new Label { AutomationId = "FlyoutItem2OnNavigatedFromLabel", Text = "-" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
				{
					new Label { AutomationId = "FlyoutContent2", Text = "Item 2", FontAttributes = FontAttributes.Bold, FontSize = 18 },
					new Label { Text = "OnNavigated", FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 12)},
					_onNavigatedToLabel,
					new Label { Text = "OnNavigatingFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatingFromLabel,
					new Label { Text = "OnNavigatedFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatedFromLabel
				}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_onNavigatedToLabel.Text = $"PreviousPage: {previousPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatingFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatedFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}
}

public class FlyoutPagesThree : ContentPage
{
	readonly Label _onNavigatedToLabel;
	readonly Label _onNavigatingFromLabel;
	readonly Label _onNavigatedFromLabel;

	public FlyoutPagesThree()
	{
		Title = "Item 3";

		_onNavigatedToLabel = new Label { AutomationId = "FlyoutItem3OnNavigatedToLabel", Text = "-" };
		_onNavigatingFromLabel = new Label { AutomationId = "FlyoutItem3OnNavigatingFromLabel", Text = "-" };
		_onNavigatedFromLabel = new Label { AutomationId = "FlyoutItem3OnNavigatedFromLabel", Text = "-" };

		Content = new StackLayout
		{
			Padding = 20,
			Children =
				{
					new Label { AutomationId = "FlyoutContent3", Text = "Item 3", FontAttributes = FontAttributes.Bold, FontSize = 18 },
					new Label { Text = "OnNavigated", FontAttributes = FontAttributes.Bold, Margin = new Thickness(0, 12)},
					_onNavigatedToLabel,
					new Label { Text = "OnNavigatingFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatingFromLabel,
					new Label { Text = "OnNavigatedFrom", FontAttributes = FontAttributes.Bold },
					_onNavigatedFromLabel
				}
		};
	}

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		var previousPage = args.PreviousPage?.GetType().Name ?? "Null";
		_onNavigatedToLabel.Text = $"PreviousPage: {previousPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
	{
		base.OnNavigatingFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatingFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}

	protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
	{
		base.OnNavigatedFrom(args);

		var destinationPage = args.DestinationPage?.GetType().Name ?? "Null";
		_onNavigatedFromLabel.Text = $"DestinationPage: {destinationPage}, NavigationType: {args.NavigationType}";
	}
}