using Maui.Controls.Sample;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
    public class SelectionMainPage : NavigationPage
	{
		public SelectionMainPage()
		{
			PushAsync(new SelectionContentPage());
		}
	}

	public partial class SelectionContentPage : ContentPage
	{
		public SelectionContentPage()
		{
			InitializeComponent();
		}

		private async void OnSelectionMainPageClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CollectionViewControlPage());
		}
	}
}
