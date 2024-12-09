namespace Maui.Controls.Sample.Issues;


[Issue(IssueTracker.Bugzilla, 45743, "[iOS] Calling DisplayAlert via BeginInvokeOnMainThread blocking other calls on iOS", PlatformAffected.iOS)]
public class Bugzilla45743 : TestNavigationPage
{
	protected override void Init()
	{
		PushAsync(new ContentPage
		{
			Content = new StackLayout
			{
				AutomationId = "Page1",
				Children =
				{
					new Label { Text = "Page 1" }
				}
			}
		});

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await DisplayAlert("Title", "Message", "Accept", "Cancel");
		});

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await PushAsync(new ContentPage
			{
				AutomationId = "Page2",
				Content = new StackLayout
				{
					Children =
					{
						new Label { Text = "Page 2", AutomationId = "Page 2" }
					}
				}
			});
		});

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await DisplayAlert("Title 2", "Message", "Accept", "Cancel");
		});

		MainThread.BeginInvokeOnMainThread(async () =>
		{
			await DisplayActionSheet("ActionSheet Title", "Cancel", "Close", new string[] { "Test", "Test 2" });
		});

	}
}