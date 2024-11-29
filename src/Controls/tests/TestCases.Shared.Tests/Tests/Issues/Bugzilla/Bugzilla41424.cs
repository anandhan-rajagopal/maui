
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla41424 : _IssuesUITest
{
	public Bugzilla41424(TestDevice testDevice) : base(testDevice)
	{
	}
	const string FocusState = "getfocusstate";
	public override string Issue => "[Android] Clicking cancel on a DatePicker does not cause it to unfocus";

	// TODO from Xamarin.UITest migration: replace DialogIsOpened calls with another way of detecting the dialog
	// Maybe see Bugzilla42074 which seems to do the same?

	[Test]
	[Category(UITestCategories.DatePicker)]
	public void DatePickerCancelShouldUnfocus()
	{
#if ANDROID
        App.WaitForElement("DatePicker");
		App.Tap("DatePicker");
		App.WaitForElement("Cancel");
		App.Tap("Cancel");
#else
		App.Tap("DatePicker");
#endif


		App.WaitForElement(FocusState);
		App.Tap(FocusState);
		App.WaitForElement("focusstate", "unfocused");

		App.Tap("Click to focus DatePicker");


		App.WaitForElement(FocusState);
		App.Tap(FocusState);
		App.WaitForElement("focusstate", "unfocused");
	}

}