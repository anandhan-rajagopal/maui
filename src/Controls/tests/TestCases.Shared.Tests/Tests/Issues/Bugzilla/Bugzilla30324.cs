#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS // It throws Exception System.InvalidCastException: 'Unable to cast object of type 'Microsoft.Maui.Controls.Page' to type 'Microsoft.Maui.IContentView
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla30324 : _IssuesUITest
{
	public Bugzilla30324(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Detail view of FlyoutPage does not get appearance events on Android when whole FlyoutPage disappears/reappears";

	[Test]
	[Category(UITestCategories.FlyoutPage)]
	public void Bugzilla30324Test()
	{
		App.WaitForElement("navigate");
		App.Tap("navigate");
		App.Tap("navigateback");
		App.WaitForElement("Disappeardetail");
		App.Tap("navigate");
		App.Tap("navigateback");
		App.WaitForElement("Appeardetail");
	}
}
#endif