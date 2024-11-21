#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST // null reference exception in Mac and text does not override in windows, More Information:https://github.com/dotnet/maui/issues/1625
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