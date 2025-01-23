namespace Maui.Controls.Sample.Issues
{

	[Issue(IssueTracker.Bugzilla, 41842, "Set FlyoutPage.Detail = New Page() twice will crash the application when set FlyoutLayoutBehavior = FlyoutLayoutBehavior.Split", PlatformAffected.WinRT)]
	public class Bugzilla41842 : TestFlyoutPage
	{
		protected override void Init()
		{
			FlyoutLayoutBehavior = FlyoutLayoutBehavior.Split;

			//for more information: https://github.com/dotnet/maui/issues/21205
			Flyout = new ContentPage() { Title = "Flyout" };
			Detail = new NavigationPage(new ContentPage { Content = new Label { AutomationId = "Success", Text = "Success" } });
		}
	}
}
