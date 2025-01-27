namespace Maui.Controls.Sample.Issues
{

	[Issue(IssueTracker.Github, 2837, "Exception thrown during NavigationPage.Navigation.PopAsync", PlatformAffected.Android)]
	public class Issue2837 : TestNavigationPage
	{
		string _labelText = "worked";
		protected override async void Init()
		{
			// Initialize ui here instead of ctor
			await PushAsync(new ContentPage() { Title = "MainPage" });
		}

		protected override async void OnAppearing()
		{
			var nav = (NavigationPage)this;

			nav.Navigation.InsertPageBefore(new ContentPage() { Title = "SecondPage ", Content = new Label { Text = _labelText } }, nav.CurrentPage);
			await nav.Navigation.PopAsync(false);
			base.OnAppearing();
		}
	}
}