using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue15542 : _IssuesUITest
{
	public Issue15542(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] Shell.TitleView does not render on iOS 16";

	[Test]
	[Category(UITestCategories.TitleView)]
	public void TitleViewHeightDoesntOverflow()
	{
		var titleView = App.WaitForElement("title 1").GetRect();
#if WINDOWS
		App.Tap("navViewItem");
#elif ANDROID
		var topTab = App.WaitForElement("PAGE 1").GetRect();
#else
		var topTab = App.WaitForElement("page 1").GetRect();

		var titleViewBottom = titleView.Y + titleView.Height;
		var topTabTop = topTab.Y;

		Assert.That(topTabTop, Is.GreaterThanOrEqualTo(titleViewBottom), "Title View is incorrectly positioned in iOS 16");
#endif
	}
}
