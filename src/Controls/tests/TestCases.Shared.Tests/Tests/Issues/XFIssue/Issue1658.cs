//Timeout Exception raises in the App.WaitForElement("coffee.png");
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue1658 : _IssuesUITest
{
	public Issue1658(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[macOS] GestureRecognizer on ListView Item not working";

	[Test]
	[Category(UITestCategories.ListView)]
	public void ContextActionsIconImageSource()
	{
		App.ActivateContextMenu("Right click on any item within viewcell (including this label) should trigger context action on this row and you should see a coffee cup. Tap on colored box should change box color");
		App.WaitForElement("coffee.png");
		App.DismissContextMenu();

		App.WaitForElement("ColorBox");
		App.Screenshot("Box should be red");
		App.Tap("ColorBox");
		App.Screenshot("Box should be yellow");
	}
}