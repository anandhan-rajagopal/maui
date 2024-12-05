using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue12652 : _IssuesUITest
{
	public Issue12652(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] NullReferenceException in the Shell on UWP when navigating back to Shell Section with multiple content items";

	[Test]
	[Category(UITestCategories.Shell)]
	public void NavigatingBackToAlreadySelectedTopTabDoesntCrash()
	{
#if ANDROID
		App.WaitForElement("TOP 3");
		App.Tap("TOP 3");
#else
    #if WINDOWS
		App.WaitForElement("Main 1");
		App.Tap("navViewItem");
	#endif
		App.WaitForElement("Top 3");
		App.Tap("Top 3");
#endif
		App.WaitForElement("TopTabPage3");
		App.Tap("Main 2");
		App.WaitForElement("TopTabPage2");
		App.Tap("Main 1");

		App.WaitForElement("TopTabPage3");
#if WINDOWS
		App.Tap("Main 2");
#endif
		App.Tap("Main 2");
		App.WaitForElement("TopTabPage2");
		App.Tap("Main 1");
		App.WaitForElement("TopTabPage3");
	}
}