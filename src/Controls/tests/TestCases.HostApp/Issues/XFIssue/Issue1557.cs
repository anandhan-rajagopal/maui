using System.Collections.ObjectModel;

namespace Maui.Controls.Sample.Issues;


[Issue(IssueTracker.Github, 1557, "Setting source crashes if view was detached from visual tree", PlatformAffected.iOS)]
public class Issue1557 : TestContentPage
{
	const int Delay = 3000;

	
	protected override void Init()
	{
		var btn = new Button
		{
			Text= "Next Page",
			AutomationId="NextPage",
		};
		
		btn.Clicked += async(sender, e) => await Navigation.PushModalAsync(new NextPage());
		Content = btn;

		
	}
	public class NextPage : ContentPage
	{
		ObservableCollection<string> _items = new ObservableCollection<string> { "foo", "bar" };
		public NextPage()
		{
			var listView = new ListView
			{
				ItemsSource = _items
			};
			Task.Delay(Delay).ContinueWith(async t =>
			{
				var list = (ListView)Content;

				await Navigation.PopModalAsync();

				list.ItemsSource = new List<string> { "test" };
			}, TaskScheduler.FromCurrentSynchronizationContext());

			Content=listView;
		}
	}
}

