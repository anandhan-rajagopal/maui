namespace Maui.Controls.Sample;

public partial class TabbedPageControlPage : TabbedPage
{
	private TabbedPageViewModel _viewModel;

	public TabbedPageControlPage()
	{
		InitializeComponent();
		_viewModel = new TabbedPageViewModel();
		BindingContext = _viewModel;
		Children.Add(new HomePage());
		Children.Add(new SecondPage());
		Children.Add(new ThirdPage(NavigateToOptionsPage_Clicked));
	}

	private async void NavigateToOptionsPage_Clicked(object sender, EventArgs e)
	{
		BindingContext = _viewModel = new TabbedPageViewModel();
		await Navigation.PushModalAsync(new TabbedPageOptionsPage(_viewModel));
	}
}

public class HomePage : ContentPage
{
	public HomePage()
	{
		AutomationId = "HOME PAGE";
		Title = "HOME PAGE";
		IconImageSource = "coffee.png";
		Content = new StackLayout
		{
			Children =
			{
				new Label
				{
					HorizontalOptions= LayoutOptions.Start,
					Text = "This is the first tab in the TabbedPage",
					WidthRequest = 300
				},
				new Label
				{
					AutomationId = "HomePageLabel",
					Text = "Home Page Content",
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				}
			}
		};
	}
}

public class SecondPage : ContentPage
{
	public SecondPage()
	{
		AutomationId = "SECOND PAGE";
		Title = "SECOND PAGE";
		IconImageSource = "coffee.png";
		Content = new StackLayout
		{
			Children =
			{
				new Label
				{
					HorizontalOptions= LayoutOptions.Start,
					Text = "This is the second tab in the TabbedPage",
					WidthRequest = 300
				},
				new Label
				{
					AutomationId = "SecondPageLabel",
					Text = "Second Page Content",
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand
				}
			}
		};
	}
}

public class ThirdPage : ContentPage
{
	public ThirdPage(EventHandler navigateToOptions)
	{
		Title = "THIRD PAGE";
		IconImageSource = "coffee.png";
		AutomationId = "THIRD PAGE";

		var optionsButton = new Button
		{
			Text = "Go to Options",
			AutomationId = "OptionsButton"
		};
		optionsButton.Clicked += navigateToOptions;

		Content = new StackLayout
		{
			Children =
			{
				optionsButton,
				new Label
				{
					HorizontalOptions= LayoutOptions.Start,
					Text = "This is the third tab in the TabbedPage",
					WidthRequest = 300
				},
				new Label
				{
					AutomationId = "ThirdPageLabel",
					Text = "Third Page Content",
					FontSize = 18,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.CenterAndExpand,
				},
			}
		};
	}
}