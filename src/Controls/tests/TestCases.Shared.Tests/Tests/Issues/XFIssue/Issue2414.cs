//TestDoesntCrashShowingContextMenu this testcase was failed. TestShowContextMenuItemsInTheRightOrder this testcase passed.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2414 : _IssuesUITest
{
	public Issue2414(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "NullReferenceException when swiping over Context Actions";

	[Test]
	[Category(UITestCategories.TableView)]
	public void TestDoesntCrashShowingContextMenu()
	{
		App.ActivateContextMenu("Swipe ME");
		App.WaitForElement("Text0");
		App.Screenshot("Didn't crash");
		App.Tap("Text0");
	}

	[Test]
	[Category(UITestCategories.TableView)]
	public void TestShowContextMenuItemsInTheRightOrder()
	{
		App.ActivateContextMenu("Swipe ME");
		App.WaitForElement("Text0");
		App.Screenshot("Are the menuitems in the right order?");
		App.Tap("Text0");
	}
}