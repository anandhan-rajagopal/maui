#if TEST_FAILS_ON_ANDROID //The test intermittently fails on Android, sometimes passing and sometimes failing, likely due to inconsistent timing or synchronization issues when navigating between pages.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla40955 : _IssuesUITest
{
	const string DestructorMessage = "NavigationPageEx Destructor called";
#if WINDOWS && ANDROID
    const string LabelPage1 = "LabelOne",
    const string LabelPage2 = "LabelTwo",
    const string LabelPage3 = "LabelThree";
#else
	const string LabelPage1 = "Open the drawer menu and select Page2";
	const string LabelPage2 = "Open the drawer menu and select Page3";
	const string LabelPage3 = $"The console should have displayed the text '{DestructorMessage}' at least once. If not, this test has failed.";
 
#endif
	public Bugzilla40955(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Memory leak with FormsAppCompatActivity and NavigationPage";

	 [Test]
	[Category(UITestCategories.Performance)]
	public void MemoryLeakInFormsAppCompatActivity()
	{
		App.WaitForElement("Page1");
		App.WaitForElement(LabelPage1);
		App.Tap(LabelPage1);
		App.WaitForElement("Page2");
		App.Tap("Page2");
		App.WaitForElement(LabelPage2);
		App.Tap(LabelPage2);
		App.WaitForElement("Page3");
		App.Tap("Page3");
#if ANDROID || WINDOWS
		App.WaitForElement("LabelThree");
		App.Tap("LabelThree");
#else
		App.WaitForElement(LabelPage3);
		App.Tap(LabelPage3);
#endif
		App.WaitForElement(DestructorMessage);
	}
}
#endif