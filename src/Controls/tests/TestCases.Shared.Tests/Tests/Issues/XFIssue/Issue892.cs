#if  TEST_FAILS_ON_CATALYST // TapBackArrow and App.Back not working on MacCatalyst
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue892 : _IssuesUITest
{
	public Issue892(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "NavigationPages as details in FlyoutPage don't work as expected";


	[Test]
	[Category(UITestCategories.FlyoutPage)]

	[Description("Change pages in the Flyout ListView, and navigate to the end and back")]
	public void Issue892TestsNavigateChangePagesNavigate()
	{
		NavigateToEndAndBack();

		App.Tap("Present Flyout");
		App.Tap("Page 5");

#if WINDOWS || ANDROID

        App.WaitForElementTillPageNavigationSettled("Page 5");
		App.TapInFlyoutPageFlyout("Close Flyout");
#else
		App.Tap("Close Flyout");
#endif
		 
		NavigateToEndAndBack();
	}

	void NavigateToEndAndBack()
	{
		App.WaitForElement("Push next page"); 
		App.Tap("Push next page");
	  
		App.WaitForElement("Push next next page"); 
		App.Tap("Push next next page");
		 
		App.WaitForElement("You are at the end of the line");
		App.Tap("Check back one");
		App.WaitForElement("Pop one");

#if IOS
		App.Back();
#else
		App.TapBackArrow();
#endif
		App.WaitForElementTillPageNavigationSettled("Check back two");
		App.Tap("Check back two");
		App.WaitForElement("Pop two");

#if IOS
		App.Back();
#else
    App.TapBackArrow();
#endif

		App.Tap("Check back three");
		App.WaitForElement("At root");
		  
	}
}
#endif