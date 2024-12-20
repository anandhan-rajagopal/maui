#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST
//DisplayPromptAsync are popped up message is not working on Windows, Android, iOS and Catalyst. 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue8526 : _IssuesUITest
{
	public Issue8526(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] DisplayPromptAsync hangs app, doesn't display when called in page load";

	[Test]
	[Category(UITestCategories.DisplayPrompt)]
	public void DisplayPromptShouldWorkInPageLoad()
	{
		App.WaitForElement("Success");
		App.Tap("Cancel");
	}
}
#endif