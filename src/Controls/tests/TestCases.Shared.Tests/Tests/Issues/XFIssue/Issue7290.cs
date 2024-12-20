#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_ANDROID
//DisplayActionSheet and DisplayAlert are popped up message is not working on Windows and Android.
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
		#if MACCATALYST
		App.WaitForElement("action-button--999");
		App.Tap("action-button--999");
		App.WaitForElement("action-button--998");
		App.Tap("action-button--998");
		#else
		App.Tap("Cancel");
		App.Tap("Close Action Sheet");
		#endif
	}
}
#endif