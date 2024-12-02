using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla41424 : _IssuesUITest
{

	const string DatePicker = "DatePicker";
	const string GetFocusState = "GetFocusState";
	const string ProgrammaticFocus = "ProgrammaticFocus";
	const string FocusStateLabel = "FocusStateLabel";

	public Bugzilla41424(TestDevice testDevice) : base(testDevice)
	{
	}
	public override string Issue => "[Android] Clicking cancel on a DatePicker does not cause it to unfocus";

	[Test]
	[Category(UITestCategories.DatePicker)]
	public void DatePickerCancelShouldUnfocus()
	{

        App.WaitForElement(DatePicker);
		App.Tap(DatePicker);

		CloseDialog();

		App.WaitForElement(GetFocusState);
		App.Tap(GetFocusState);

		Assert.That(App.WaitForElement(FocusStateLabel)?.GetText(), Is.EqualTo("unfocused"));
#if !ANDROID && !MACCATALYST //Programmatic focus does not open the dialog for picker controls, issue: https://github.com/dotnet/maui/issues/8946 
		App.Tap(ProgrammaticFocus);

		CloseDialog();
		App.WaitForElement(GetFocusState);
		App.Tap(GetFocusState);
		
		Assert.That(App.WaitForElement(FocusStateLabel)?.GetText(), Is.EqualTo("unfocused"));
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
#elif MACCATALYST // unable to locate the elements in the dialog box, so tapping outside the dialog caused it to close on a Mac.
		App.Tap(GetFocusState);
#endif
	}

}