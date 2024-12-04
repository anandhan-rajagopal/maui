#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS
//In MacCatalyst, the DragCoordinates feature is not working. On the iOS platform, when the button is clicked, the value does not change to 0.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7993 : _IssuesUITest
{
	public Issue7993(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] CollectionView.Scrolled event offset isn't correctly reset when items change";

	[Test]
	[Category(UITestCategories.CollectionView)]
	public void CollectionViewVerticalOffset()
	{
		var colView = App.WaitForElement("CollectionView7993");

		App.WaitForElement("VerticalOffset: 0");
		App.DragCoordinates(colView.GetRect().Width - 10, 
			colView.GetRect().Y + colView.GetRect().Height - 50, 
			colView.GetRect().Width - 10,
			colView.GetRect().Y + 5);
		App.WaitForElement("19");
		App.Tap("NewItemsSource");
		App.WaitForElement("VerticalOffset: 0");
	}
}
#endif