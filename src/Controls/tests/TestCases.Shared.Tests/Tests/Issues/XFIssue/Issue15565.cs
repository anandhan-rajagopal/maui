using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.TitleView)]
public class Issue15565 : _IssuesUITest
{
	public Issue15565(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] Shell TitleView and ToolBarItems rendering strange display on iOS 16";

	[Test]
	public void TitleViewHeightIsNotZero()
	{

#if WINDOWS
		App.Tap("navViewItem");
#elif ANDROID
        var topTab = App.WaitForElement("PAGE 1").GetRect();
#else
        App.Tap("page 1");
        var titleView = App.WaitForElement("title 1").GetRect();
        var topTab = App.WaitForElement("page 1").GetRect();
 
        var titleViewBottom = titleView.Y + titleView.Height;
        var topTabTop = topTab.Y;
 
        Assert.That(topTabTop, Is.GreaterThanOrEqualTo(titleViewBottom), "Title View is incorrectly positioned in iOS 16");
#endif
	}


	[Test]
	public void ToolbarItemsWithTitleViewAreRendering()
	{
		App.WaitForElement("Item 1");
		App.WaitForElement("Item 2");
	}

	[Test]
	public void NoDuplicateTitleViews()
	{
		var titleView = App.WaitForElement("title 1");
#if WINDOWS || ANDROID
        Assert.That(App.FindElementsByText("title 1").Count, Is.EqualTo(1));
#else
		Assert.That(App.FindElements("title 1").Count, Is.EqualTo(1));
#endif


#if WINDOWS
		App.Tap("navViewItem");
		App.Tap("page 1");
		App.Tap("navViewItem");
		App.Tap("page 2");
		App.Tap("navViewItem");
		App.Tap("page 3");

		titleView = App.WaitForElement("title 3");
		Assert.That(App.FindElementsByText("title 3").Count, Is.EqualTo(1));

#elif ANDROID
        App.Tap("PAGE 1");
        App.Tap("PAGE 2");
        App.Tap("PAGE 3");
 
        titleView = App.WaitForElement("title 3");
        Assert.That(App.FindElementsByText("title 3").Count, Is.EqualTo(1));
 
#else
        App.Tap("page 1");
        App.Tap("page 2");
        App.Tap("page 3");
        titleView = App.WaitForElement("title 3");
        Assert.That(App.FindElements("title 3").Count, Is.EqualTo(1));
#endif
	}
}