#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS //Timeout Exception on wait for elament - Display Alert
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue3139 : _IssuesUITest
{
	public Issue3139(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "DisplayActionSheet is hiding behind Dialogs";

	[Test]
	[Category(UITestCategories.ActionSheet)]
	public void Issue3139Test()
	{
		App.WaitForElement("ClickYes");
		App.Tap("Yes");
		App.WaitForElement("AgainYes");
		App.Tap("YesYes");
		App.WaitForElement("Testpassed");
	}
}
#endif