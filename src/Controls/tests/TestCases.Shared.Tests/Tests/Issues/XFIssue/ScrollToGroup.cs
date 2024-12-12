using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.CollectionView)]
public class ScrollToGroup : _IssuesUITest
{
	public ScrollToGroup(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "CollectionView Scroll To Grouped Item";

	// TODO: HostApp UI pushes some ControlGallery specific page? Commented out now, fix that first!
	[Test]
	public void CanScrollToGroupAndItemIndex()
	{
		App.WaitForElement("GroupIndexEntry");
		App.Tap("GroupIndexEntry");
		App.ClearText("GroupIndexEntry");
		App.EnterText("GroupIndexEntry","5");
		
		App.WaitForElement("ItemIndexEntry");
		App.Tap("ItemIndexEntry");
		App.ClearText("ItemIndexEntry");
		App.EnterText("ItemIndexEntry","1");

		App.Tap("GoButton");

		// Should scroll enough to display this item
		App.WaitForElement("Squirrel Girl");
	}

	[Test]
	public void InvalidScrollToIndexShouldNotCrash()
	{
		App.WaitForElement("GroupIndexEntry");
		App.Tap("GroupIndexEntry");
		App.ClearText("GroupIndexEntry");
		App.EnterText("GroupIndexEntry","55");

		App.Tap("ItemIndexEntry");
		App.ClearText("ItemIndexEntry");
		App.EnterText("ItemIndexEntry","1");

		App.Tap("GoButton");

		// Should scroll enough to display this item
		App.WaitForElement("Avengers");
	}

	[Test]

	public void CanScrollToGroupAndItem()
	{
		App.WaitForElement("GroupNameEntry");
		App.Tap("GroupNameEntry");
		App.ClearText("GroupNameEntry");
		App.EnterText("GroupNameEntry","Heroes for Hire");

		App.Tap("ItemNameEntry");
		App.ClearText("ItemNameEntry");
		App.EnterText("ItemNameEntry","Misty Knight");

		App.Tap("GoItemButton");

		// Should scroll enough to display this item
		App.WaitForElement("Luke Cage");
	}
}