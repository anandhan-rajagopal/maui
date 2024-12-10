#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS //Not supported Numberic Entry Keyboard - also need to check in Android and IOS
// This test case is designed to verify the behavior of the keyboard when interacting with EntryCells in a TableView.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla33578 : _IssuesUITest
{
	public Bugzilla33578(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TableView EntryCell shows DefaultKeyboard, but after scrolling down and back a NumericKeyboard (";

	// TODO: Migration from Xamarin.UITest
	// Find out how to do this advanced stuff with Appium
	[Test]
	[Category(UITestCategories.TableView)]

	public void TableViewEntryCellShowsDefaultKeyboardThenNumericKeyboardAfterScrolling()
	{
		App.ScrollDown("table");
		App.ScrollDown("table");
		App.WaitForElement("0");
		App.Tap("0");
		var e = App.WaitForElement("0");
		//8 DecimalPad
		//Assert.That(e,Is.EqualTo(8));
		App.DismissKeyboard();
		App.WaitForElement("entryPreviousNumeric");
		App.Tap("Enter text here");
		App.ScrollUp("table");
		App.WaitForElement("entryNormal");
		App.Tap("Enter text here 1");
		App.WaitForElement("Enter text here 2");
		App.Tap("Enter text here 2");
		//var e1 = App.Query(c => c.Marked("Enter text here 2").Parent("UITextField").Index(0).Invoke("keyboardType"))[0];
		//Assert.AreEqual(0, e1);
	}
}
#endif