#if TEST_FAILS_ON_CATALYST // DragCoordinates is not supported in MacCatalyst
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7803 : _IssuesUITest
{
	public Issue7803(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] CarouselView/RefreshView pull to refresh command firing twice on a single pull";

	[Test]
	[Category(UITestCategories.CollectionView)]
	public void DelayedIsRefreshingAndCommandTest_SwipeDown()
	{
		var collectionView = App.WaitForElement("CollectionView7803");
		App.ScrollUp("CollectionView7803");

		App.WaitForElement("Count: 20");

		App.WaitForNoElement("Count: 30");

		// Radomly the single drag actions not fully scroll to end of list so added two drag actions to make this test more stable.
		App.DragCoordinates(collectionView.GetRect().Width - 10, collectionView.GetRect().Y + collectionView.GetRect().Height - 50, collectionView.GetRect().Width - 10, collectionView.GetRect().Y + 5);
		App.DragCoordinates(collectionView.GetRect().Width - 10, collectionView.GetRect().Y + collectionView.GetRect().Height - 50, collectionView.GetRect().Width - 10, collectionView.GetRect().Y + 5);

		App.WaitForElement("19");
	}
}
#endif