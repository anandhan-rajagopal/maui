#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue774 : _IssuesUITest
{
	public Issue774(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "ActionSheet won't dismiss after rotation to landscape";

	[Test]
	[Category(UITestCategories.ActionSheet)]

	public void Issue774TestsDismissActionSheetAfterRotation()
	{
		App.WaitForElement("Show ActionSheet");
		App.Tap("Show ActionSheet");
		App.Screenshot("Show ActionSheet");

		App.SetOrientationLandscape();
		App.Screenshot("Rotate Device");

		App.Tap("Dismiss");
		App.Screenshot("Dismiss ActionSheet");
	}

	[TearDown]
	public  void TearDown()
	{
		App.SetOrientationPortrait();
	}
}
#endif