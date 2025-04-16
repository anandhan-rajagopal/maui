using Maui.Controls.Sample;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
    public class CollectionViewFeaturePage : NavigationPage
	{
		public CollectionViewFeaturePage()
		{
			PushAsync(new CollectionViewFeatureMainPage());
		}
	}

	public partial class CollectionViewFeatureMainPage : ContentPage
	{
		public CollectionViewFeatureMainPage()
		{
			InitializeComponent();
		}

		private async void OnSelectionMainPageClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CollectionViewSelectionPage());
		}
	}
}
