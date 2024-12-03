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
		NavigateToEndAndBack("Initial Page");
		App.Tap("Present Flyout");
		App.Tap("Page 5");

#if ANDROID || WINDOWS // IsPresented value not reflected when changing on ItemTapped in FlyoutPage More Information: https://github.com/dotnet/maui/issues/26324
 
App.WaitForElementTillPageNavigationSettled("Page 5");
App.TapInFlyoutPageFlyout("Close Flyout");
 
#else
		App.Tap("Close Flyout");

#endif
		NavigateToEndAndBack("Page 5");
	}

	void NavigateToEndAndBack(string BackButtonId)
	{
		App.WaitForElement("Push next page"); 
		App.Tap("Push next page");
		App.WaitForElement("Push next next page"); 
		App.Tap("Push next next page"); 
		App.WaitForElement("You are at the end of the line");
		App.Tap("Check back one");
		App.WaitForElement("Pop one");

#if ANDROID
         App.TapBackArrow();
#else
		App.TapBackArrow("One pushed");
#endif

		App.WaitForElementTillPageNavigationSettled("Check back two");
		App.Tap("Check back two");
		App.WaitForElement("Pop two");
		App.WaitForElementTillPageNavigationSettled("Check back two");

#if ANDROID
         App.TapBackArrow();
#else
		App.TapBackArrow(BackButtonId);
#endif
		App.Tap("Check back three");
		App.WaitForElement("At root");

	}


}