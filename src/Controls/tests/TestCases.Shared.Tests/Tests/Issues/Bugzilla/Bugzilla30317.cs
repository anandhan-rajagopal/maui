#if TEST_FAILS_ON_CATALYST //When tapping Back Button
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
[Category(UITestCategories.TabbedPage)]
public class Bugzilla30317 : _IssuesUITest
{
	public Bugzilla30317(TestDevice testDevice) : base(testDevice)
	{
	}
 
	const string PageTwoButton = "GoToPageTwoButton";
	const string PageThreeButton = "GoToPageThreeButton";
	const string PageOneItem1 = "PageOneItem1";
	const string PageOneItem5 = "PageOneItem5";
	const string PageTwoItem1 = "PageTwoItem1";
	const string PageTwoItem5 = "PageTwoItem5";
#if ANDROID
    const string TabOne = "TABONECTOR";
    const string TabTwo = "TABTWOONAPPEARING";
#elif WINDOWS
	const string TabOne = "TabOneCtor";
    const string TabTwo = "TabTwoOnAppearing";
#else
	const string TabOne = "TabbedPageOne";
	const string TabTwo = "TabbedPageTwo";
#endif
	const string TabOneItem1 = "PageThreeTabOneItem1";
	const string TabOneItem5 = "PageThreeTabOneItem5";
	const string TabTwoItem1 = "PageThreeTabTwoItem1";
	const string TabTwoItem5 = "PageThreeTabTwoItem5";
 
	public override string Issue => "https://bugzilla.xamarin.com/show_bug.cgi?id=30137";
 
	[Test]
	public void Bugzilla30317ItemSourceOnAppearingContentPage()
	{
#if WINDOWS
        App.WaitForElement("Set ItemSource On Appearing");  
#else
		App.WaitForElement("PageOne");
#endif
		App.WaitForElement(PageOneItem1);
		HoldMethod(PageOneItem1);
 
		App.WaitForElement(PageOneItem5);
		HoldMethod(PageOneItem5);
	}
 
	[Test]
	public void Bugzilla30317ItemSourceCtorContentPage()
	{
		App.WaitForElement(PageTwoButton);
		App.Tap(PageTwoButton);
 
#if WINDOWS
        App.WaitForElement("Set ItemSource in ctor");   
#else
		App.WaitForElement("PageTwo");
#endif
 
		App.WaitForElement(PageTwoItem1);
		HoldMethod(PageTwoItem1);
 
		App.WaitForElement(PageTwoItem5);
		HoldMethod(PageTwoItem5);
#if MACCATALYST || WINDOWS
		App.TapBackArrow();
#else
        App.Back();
#endif
 
	}
 
	[Test]
	public void Bugzilla30317ItemSourceTabbedPage()
	{
		App.WaitForElement(PageTwoButton);
		App.Tap(PageTwoButton);
 
#if WINDOWS
        App.WaitForElement("Set ItemSource in ctor");   
#else
		App.WaitForElement("PageTwo");
#endif
 
		App.WaitForElement(PageThreeButton);
		App.Tap(PageThreeButton);
 
		App.WaitForElement(TabTwo);
		App.Tap(TabTwo);
 
		App.WaitForElement(TabTwoItem1);
		HoldMethod(TabTwoItem1);
		App.WaitForElement(TabTwoItem1);
 
		App.WaitForElement(TabTwoItem5);
		HoldMethod(TabTwoItem5);
		App.WaitForElement(TabTwoItem5);
 
		App.WaitForElement(TabOne);
		App.Tap(TabOne);
 
		App.WaitForElement(TabOneItem1);
		HoldMethod(TabOneItem1);
		App.WaitForElement(TabOneItem1);
 
		App.WaitForElement(TabOneItem5);
		HoldMethod(TabOneItem5);
		App.WaitForElement(TabOneItem5);
	}
 
	void HoldMethod(string item)
	{
#if MACCATALYST
		App.LongPress(item);
#else
    App.TouchAndHold(item);
#endif
	}
}
#endif