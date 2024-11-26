#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // SwipeActions not applicable in Catalyst, In iOS, the test will pass, but unable to view the drawer while swiping.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue8461 : _IssuesUITest
{
	public Issue8461(TestDevice testDevice) : base(testDevice)
	{
	}
	const string ButtonId = "PageButtonId";
	const string LayoutId = "LayoutId";
	public override string Issue => "[Bug] [iOS] [Shell] Nav Stack consistency error";

	[Test]
	[Category(UITestCategories.Navigation)]

	public void ShellSwipeToDismiss()
	{
		var pushButton = App.WaitForElement(ButtonId);
		Assert.That(App.FindElements(ButtonId).Count, Is.EqualTo(1));

		App.Tap(ButtonId);

		var page2Layout = App.WaitForElement(LayoutId);
		Assert.That(page2Layout.GetRect().Width, Is.GreaterThan(0));
		// Swipe in from left across 1/2 of screen width
		App.SwipeLeftToRight(LayoutId);
		// Swipe in from left across full screen width
		App.SwipeLeftToRight(LayoutId);

		App.TapBackArrow();

		pushButton = App.WaitForElement(ButtonId);
		Assert.That(App.FindElements(ButtonId).Count, Is.EqualTo(1));
	}
}
#endif