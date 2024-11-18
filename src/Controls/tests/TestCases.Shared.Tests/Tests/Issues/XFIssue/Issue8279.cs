#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //Sample works but in test not rendering 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.ListView)]
public class Issue8279 : _IssuesUITest
{
	public Issue8279(TestDevice testDevice) : base(testDevice)
	{
	}
	const string ScrollWithNoItemButGroup = "ScrollWithNoItemButGroup";
	const string ScrollWithItemButNoGroup = "ScrollWithItemButNoGroup";
	const string ScrollWithItemWithGroup = "ScrollWithItemWithGroup";
	const string ScrollWithNoItemNoGroup = "ScrollWithNoItemNoGroup";
	const string ScrollWithNoItemEmptyGroup = "ScrollWithNoItemEmptyGroup";
	const string Reset1 = "Reset";
	public override string Issue => "[Feature requested] ListView do not ScrollTo a group when there is no child of this group";

	[Test]
	public void ScrollWithNoItemButGroupTest()
	{
		App.WaitForElement(Reset1);
		App.Tap(Reset1);
		App.WaitForElement(ScrollWithNoItemButGroup);
		App.Tap(ScrollWithNoItemButGroup);
		// This will fail if the list didn't scroll. If it did scroll, it will succeed
		App.WaitForElement("Header 3");
	}

	[Test]
	public void ScrollWithItemButNoGroupTest()
	{
		App.WaitForElement(Reset1);
		App.Tap(Reset1);
		App.WaitForElement(ScrollWithItemButNoGroup);
		App.Tap(ScrollWithItemButNoGroup);
		// This will fail if the list didn't scroll. If it did scroll, it will succeed
		App.WaitForElement("title 1");
	}

	[Test]
	public void ScrollWithItemWithGroupTest()
	{
		App.WaitForElement(Reset1);
		App.Tap(Reset1);
		App.WaitForElement(ScrollWithItemWithGroup);
		App.Tap(ScrollWithItemWithGroup);
		// This will fail if the list didn't scroll. If it did scroll, it will succeed
		App.WaitForElement("Header 3");
	}

	[Test]
	public void ScrollWithNoItemNoGroupTest()
	{
		App.WaitForElement(Reset1);
		App.Tap(Reset1);
		App.WaitForElement(ScrollWithNoItemNoGroup);
		App.Tap(ScrollWithNoItemNoGroup);
		// This will pass if the list didn't scroll and remain on the same state
		App.WaitForElement("Header 1");
	}

	[Test]
	public void ScrollWithNoItemEmptyGroupTest()
	{
		App.WaitForElement(Reset1);
		App.Tap(Reset1);
		App.WaitForElement(ScrollWithNoItemEmptyGroup);
		App.Tap(ScrollWithNoItemEmptyGroup);
		// This will fail if the list didn't scroll. If it did scroll, it will succeed
		App.WaitForElement("Header 2");
	}
}
#endif