#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_ANDROID //On Windows and MacCatalyst, alphabets can also be entered in the numeric keyboard. On Android, a timeout exception occurs for the element "A"
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

	[Test]
	[Category(UITestCategories.TableView)]

	public void TableViewEntryCellShowsDefaultKeyboardThenNumericKeyboardAfterScrolling()
	{
		App.ScrollDown("table");
		App.Tap(AppiumQuery.ByXPath("//XCUIElementTypeTextField[@value='0']"));
		App.WaitForNoElement("A");
		App.PressEnter();
		App.ScrollUp("table", ScrollStrategy.Gesture, 0.2);
		App.Tap(AppiumQuery.ByXPath("//XCUIElementTypeTextField[@value='Enter text here 2']"));
		App.WaitForElement("A");
		App.PressEnter();


	}
}
#endif