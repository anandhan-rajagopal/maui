#if TEST_FAILS_ON_CATALYST
//In the MacCatalyst platform, the dragCoordinates feature is not working.
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

		App.DragCoordinates(collectionView.GetRect().Width - 10, collectionView.GetRect().Y + collectionView.GetRect().Height - 50, collectionView.GetRect().Width - 10, collectionView.GetRect().Y + 5);

		App.WaitForElement("19");
	}
}
#endif