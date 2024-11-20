#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST // text doesnot override in windows and null reference excepion in mac
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7856 : _IssuesUITest
{
	public Issue7856(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug]  Shell BackButtonBehaviour TextOverride breaks back";

	[Test]
	[Category(UITestCategories.Shell)]
	public void BackButtonBehaviorTest()
	{
		App.Tap("Tap to Navigate To the Page With BackButtonBehavior");
		App.WaitForElement("Navigate again");
		App.Tap("Navigate again");
		App.WaitForElement("Test");
		App.Tap("Test");
	}
}
#endif