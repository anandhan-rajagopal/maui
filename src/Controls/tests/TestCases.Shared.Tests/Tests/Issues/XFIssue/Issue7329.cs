#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // On iOS, `WaitForNoElement` consistently throws an exception, even when the element is not visible. On Catalyst, `ScrollDown` isn't functioning correctly with Appium.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7329 : _IssuesUITest
{
	public Issue7329(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Android] ListView scroll not working when inside a ScrollView";

	[Test]
	[Category(UITestCategories.ScrollView)]
	public void ScrollListViewInsideScrollView()
	{
		App.WaitForElement("1");

		App.ScrollDown("NestedListView");
		
		// App.QueryUntilPresent isn't functioning correctly; it throws a timeout exception immediately after the first try.
		// Verifying that InstructionLabel is not visible also confirms that the ListView has scrolled.
		App.WaitForNoElement("InstructionLabel");
	}
}
#endif