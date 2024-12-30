#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // Swipe not working on Catalyst, The swipe action was being performed, but it was not effective, resulting in the label value not being updated on iOS and Android.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue9088 : _IssuesUITest
{
	const string SwipeViewId = "Standalone SwipeItem";
	public Issue9088(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] SwipeView items conflict with Shell menu swipe in from left, on real iOS devices";

	[Test]
	[Category(UITestCategories.Shell)]
	public void Issue9088SwipeViewConfictWithShellMenuSwipeInFromLeft()
	{
		App.WaitForElement(SwipeViewId);
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("1");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("2");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("3");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("1");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("2");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("3");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("4");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("4");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("5");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("5");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeLeftToRight(SwipeViewId, 0.9);
		App.WaitForElement("6");

		App.WaitForElement(SwipeViewId, timeout: TimeSpan.FromSeconds(10));
		App.SwipeRightToLeft(SwipeViewId, 0.9);
		App.WaitForElement("6");
	}
}
#endif
