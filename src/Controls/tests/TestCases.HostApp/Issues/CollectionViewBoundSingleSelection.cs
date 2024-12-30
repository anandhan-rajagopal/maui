namespace Maui.Controls.Sample.Issues;

[Issue(IssueTracker.None, 4539134, "CollectionView: Single Selection Binding", PlatformAffected.All)]
public class CollectionViewBoundSingleSelection : TestNavigationPage
{
	protected override void Init()
	{
		PushAsync(new CollectionViewGalleries.SelectionGalleries.SingleBoundSelection());
	}
}