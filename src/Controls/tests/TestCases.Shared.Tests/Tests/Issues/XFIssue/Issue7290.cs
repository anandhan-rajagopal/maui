#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS //Timeout exception i display alert element.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7290 : _IssuesUITest
{
	public Issue7290(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Android] DisplayActionSheet or DisplayAlert in OnAppearing does not work on Shell";

	[Test]
	[Category(UITestCategories.Shell)]

	public void DisplayActionSheetAndDisplayAlertFromOnAppearing()
	{
		App.TapFlyoutIcon();
		App.WaitForElement("Display Action Sheet");
		App.Tap("Display Action Sheet");
		App.WaitForElement("Close Action Sheet");
		App.Tap("Close Action Sheet");
		App.TapFlyoutIcon();
		App.WaitForElement("Display Alert");
		App.Tap("Display Alert");
		App.WaitForElement("Cancel");
		App.Tap("Cancel");
	}
}
#endif