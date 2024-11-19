#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //Sample fails except Android - Test fails on Android in element LayoutId - Boxview
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
	public override string Issue => "[Bug] [iOS] [Shell] \"Nav Stack consistency error\"";

	[Test]
	[Category(UITestCategories.Navigation)]

	public void ShellSwipeToDismiss()
	{
		var pushButton = App.WaitForElement(ButtonId);
		//Assert.AreEqual(1, pushButton.Length);

		App.Tap(ButtonId);

		var page2Layout = App.WaitForElement(LayoutId);
		//Assert.AreEqual(page2Layout.Length);
		// Swipe in from left across 1/2 of screen width
		App.SwipeLeftToRight(LayoutId, 0.99, 500, false);
		// Swipe in from left across full screen width
		App.SwipeLeftToRight(0.99, 500);

		pushButton = App.WaitForElement(ButtonId);
		//Assert.AreEqual(1, pushButton.Length);
	}
}
#endif