#if TEST_FAILS_ON_WINDOWS// WHEN TAP CLOSED FLYOUT IT SHOWS CLOSED FLYOUTT LEFTT ALIGNED
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue973 : _IssuesUITest
{
	public Issue973(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "ActionBar doesn't immediately update when nested TabbedPage is changed";

	[Test]
	[Category(UITestCategories.TabbedPage)]
	[Description("Test tab reset when swapping out detail")]
	public void Issue973TestsTabResetAfterDetailSwap()
	{
		App.WaitForElement("Initial Page Left aligned");
#if ANDROID
		App.WaitForElement("TAB 1");
		App.Tap("TAB 2");
#else
		App.WaitForElement("Tab 1");
		App.Tap("Tab 2");
#endif
		App.WaitForElement("Initial Page Right aligned");
		App.Tap("Present Flyout");
		App.Tap("Page 4");
#if ANDROID
          App.DragCoordinates(15,500,800,300);
#endif
		App.Tap("Closed Flyout");
		App.WaitForElement("Page 4 Left aligned");
#if ANDROID
		App.Tap("TAB 2");
#else
		App.Tap("Tab 2");
#endif
		App.WaitForElement("Page 4 Right aligned");

	}
}
#endif