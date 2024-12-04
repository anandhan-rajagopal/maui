using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla37841 : _IssuesUITest
{
	public Bugzilla37841(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TableView EntryCells and TextCells cease to update after focus change";

	[Test]
	[Category(UITestCategories.TableView)]
	public void TextAndEntryCellsDataBindInTableView()
	{
		App.WaitForElement("Generate");
		App.Tap("Generate");

		// App.WaitForTextToBePresentInElement always succeeds even when the text is absent.
		// So use WaitForElement to checks if the specific text is present in UI.
        App.WaitForElement("12345");
		App.WaitForElement("6789");
		
		App.Tap("Generate");

        App.WaitForElement("112358");
		App.WaitForElement("48151623");
	}
}