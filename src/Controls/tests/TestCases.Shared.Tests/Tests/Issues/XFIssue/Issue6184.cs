#if TEST_FAILS_ON_ANDROID // test case passed on windows and mac but the cell is not disabled , the cell disabled only on ios
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue6184 : _IssuesUITest
{
	public Issue6184(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Throws exception when set isEnabled to false in ShellItem index > 5";

	[Test]
	[Category(UITestCategories.Shell)]
	public void GitHubIssue6184()
	{
#if ANDROID || IOS
		App.WaitForElement("More");
		App.Tap("More");
		App.Tap("Issue 5");
		App.WaitForElement("Issue 5");
#else
		App.Tap("Issue 5");
		App.WaitForElement("Issue 5");
#endif
	}
}
#endif
