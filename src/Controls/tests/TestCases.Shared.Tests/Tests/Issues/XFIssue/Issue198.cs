# if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_WINDOWS // the application crash while tap the back button.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue198 : _IssuesUITest
{
	public Issue198(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TabbedPage shouldn't proxy content of NavigationPage";

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void Issue198TestsNREWithPopModal()
	{
		App.WaitForElement("Page One");
		App.WaitForElement("Leave");
	
		App.Tap("Leave");
	
		App.WaitForElement("Bug Repro's");
		App.Tap("Bug Repro's");
	
		App.WaitForElement("Page Three");
		App.Tap("Page Three");
	
		App.WaitForElement("No Crash");
	}
}
#endif