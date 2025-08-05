namespace Maui.Controls.Sample;

public partial class FlyoutTabbedPages : FlyoutPage
{
	private readonly NavigationPage _navigationPage;

	[Obsolete]
	public FlyoutTabbedPages()
	{
		InitializeComponent();

		FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;

		Flyout = new ContentPage
		{
			Title = "Menu",
			Content = new StackLayout
			{
				Children =
				{
					new Label { Text = "Flyout Menu" },
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
			}
		};

		_navigationPage = new NavigationPage(new TabPage());

		Detail = _navigationPage;
	}
	public void NavigateTo(TabPage page)
	{
		_navigationPage.Navigation.PushAsync(page);
		IsPresented = false; // Close the flyout menu
	}
}