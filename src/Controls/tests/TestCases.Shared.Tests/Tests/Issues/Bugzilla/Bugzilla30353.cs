#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST // Setting orientation is not supported on Windows and mac
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla30353 : _IssuesUITest
{
	public Bugzilla30353(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "FlyoutPage.IsPresentedChanged is not raised";
	[Test]
	[Category(UITestCategories.FlyoutPage)]
	public void FlyoutPageIsPresentedChangedRaised()
	{
		App.SetOrientationPortrait();
		App.WaitForElement("Toggle");
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now visible");
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now invisible");
		App.SetOrientationLandscape();
		App.WaitForElement("The Flyout is now invisible");
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now visible");
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now invisible");
		App.SetOrientationPortrait();
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now visible");
		App.Tap("Toggle");
		App.WaitForElement("The Flyout is now invisible");
		App.SetOrientationLandscape();
	}

	[TearDown]
	public void TearDown()
	{
		App.SetOrientationPortrait();
	}
}
#endif