#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_ANDROID
//In windows and Android, Sample doesn't working properly.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue4973 : _IssuesUITest
{
	public Issue4973(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TabbedPage nav tests";

	[Test]
	[Category(UITestCategories.Navigation)]
	public void Issue4973Test()
	{
		App.Tap("Tab5");

		App.WaitForElement("Test");

		App.Tap("Tab1");

		App.Tap("Tab2");
	}
}
#endif