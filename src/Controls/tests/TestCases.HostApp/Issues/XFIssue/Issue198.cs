namespace Maui.Controls.Sample.Issues;


[Issue(IssueTracker.Github, 198, "TabbedPage shouldn't proxy content of NavigationPage", PlatformAffected.iOS)]
public class Issue198 : TestTabbedPage
{
	protected override void Init()
	{
		Title = "Tabbed Navigation Page";

		var leavePageBtn = new Button
		{
			Text = "Leave"
		};
		var backBtn=new Button()
		{
			Text="Bug Repro's",
		};
		backBtn.Clicked += (sender,e)=>  Navigation.PopModalAsync();
		var secondPage=new NavigationPage(new ContentPage()
		{
			Content=backBtn,
		});
		// Should work as expected, however, causes NRE
		leavePageBtn.Clicked += async(sender, e) => await Navigation.PushModalAsync(secondPage);

		var navigationPageOne = new NavigationPage(new ContentPage
		{
			Content = leavePageBtn
		})
		{
			Title = "Page One",
			IconImageSource = "calculator.png",
		};
		var navigationPageTwo = new NavigationPage(new ContentPage
		{
			Title = "Page Two",
		})
		{
			Title = "Page Two",
			IconImageSource = "calculator.png",
		};
		var navigationPageThree = new NavigationPage(new ContentPage
		{
			Title = "No Crash",
		})
		{
			Title = "Page Three",
			IconImageSource = "calculator.png"
		};
		var navigationPageFour = new NavigationPage(new ContentPage())
		{
			Title = "Page Four",
			IconImageSource = "calculator.png"
		};

		Children.Add(navigationPageOne);
		Children.Add(navigationPageTwo);
		Children.Add(navigationPageThree);
		Children.Add(navigationPageFour);
	}
}
