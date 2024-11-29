using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.TitleView)]
public class Issue15565 : _IssuesUITest
{
#if ANDROID
	const string Page1 = "PAGE 1";
	const string Page2 = "PAGE 2";
	const string Page3 = "PAGE 3";
#else
	const string Page1 = "page 1";
	const string Page2 = "page 2";
	const string Page3 = "page 3";
#endif

	public Issue15565(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] Shell TitleView and ToolBarItems rendering strange display on iOS 16";

	[Test]
	public void TitleViewHeightIsNotZero()
	{
		TapTab(Page1);
        var titleView = App.WaitForElement("title 1").GetRect();
        var topTab = App.WaitForElement(Page1).GetRect();
 
        var titleViewBottom = titleView.Y + titleView.Height;
        var topTabTop = topTab.Y;
 
        Assert.That(topTabTop, Is.GreaterThanOrEqualTo(titleViewBottom), "Title View is incorrectly positioned in iOS 16");
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
		App.WaitForElement("title 1");
		ValidateElementsCount("title 1");     
		TapTab(Page1);
		TapTab(Page2);
		TapTab(Page3);
		ValidateElementsCount("title 3");
	}

	void TapTab(string tab)
	{
#if WINDOWS
		App.Tap("navViewItem");
#endif
		App.Tap(tab);		
	}

	void ValidateElementsCount(string element)
	{
#if ANDROID || WINDOWS //FindElements and FindElementsByText different results on each platforms, so here we are using different methods to validate the count for specified platforms.
        Assert.That(App.FindElementsByText(element).Count, Is.EqualTo(1));
#else
		Assert.That(App.FindElements(AppiumQuery.ById(element)).Count, Is.EqualTo(1));
#endif
	}

}