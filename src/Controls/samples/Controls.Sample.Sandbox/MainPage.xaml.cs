namespace Maui.Controls.Sample;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	public void NavigateToMainPage_Clicked(object sender, EventArgs e)
	{
		Navigation.PopToRootAsync();
	}

	[Obsolete]
	public void OnGoToFlyoutClicked(object sender, EventArgs e)
	{
		var window = Application.Current?.Windows.FirstOrDefault();
		if (window != null)
		{
			window.Page = new FlyoutPages();
		}
	}

	[Obsolete]
	public void OnGoToFlyoutTabbedPagesClicked(object sender, EventArgs e)
	{
		var window = Application.Current?.Windows.FirstOrDefault();
		if (window != null)
		{
			window.Page = new FlyoutTabbedPages();
		}
	}

	public void OnGoToNavigationClicked(object sender, EventArgs e)
	{
		var window = Application.Current?.Windows.FirstOrDefault();
		if (window != null)
		{
			window.Page = new NavigationMainPages();
		}
		// Navigation.PushAsync(new NavigationPages());
	}

	public void OnGoToTabbedClicked(object sender, EventArgs e)
	{
		var window = Application.Current?.Windows.FirstOrDefault();
		if (window != null)
		{
			window.Page = new TabPage();
		}
	}

	public void OnGoToShellClicked(object sender, EventArgs e)
	{
		var window = Application.Current?.Windows.FirstOrDefault();
		if (window != null)
		{
			window.Page = new SandboxShell();
		}
	}
}