#if TEST_FAILS_ON_CATALYST // TimePicker not opens the dialog, issue: https://github.com/dotnet/maui/issues/10827 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla42074 : _IssuesUITest
{
	public Bugzilla42074(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Android] Clicking cancel on a TimePicker does not cause it to unfocus";

	[Test]
	[Category(UITestCategories.TimePicker)]
	public void TimePickerCancelShouldUnfocus()
	{
		App.WaitForElement("TimePicker");
		App.Tap("TimePicker");

		CloseDialog();
		App.WaitForElement("Click to focus TimePicker");
#if !ANDROID && !WINDOWS //Programmatic focus does not open the dialog for picker controls, issue: https://github.com/dotnet/maui/issues/8946 
		App.Tap("focusbtn");
		CloseDialog();
#endif
	}

	void CloseDialog()
	{
#if ANDROID
		App.WaitForElement("Cancel");
		App.Tap("Cancel");
#elif IOS
		App.WaitForElement("Done");
		App.Tap("Done");
#elif WINDOWS
		App.WaitForElement("Accept");
		App.Tap("Accept");
#endif
	}
}
#endif
