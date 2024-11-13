#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_WINDOWS // Timeout exception in the element - Button
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla56710 : _IssuesUITest
{
	public Bugzilla56710(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "ContextActionsCell.OnMenuItemPropertyChanged throws NullReferenceException";

	[Test]
	[Category("Bugzilla56710")]
	public void Bugzilla56710Test()
	{
		App.WaitForElement("Go to Test Page");
		App.Tap("Go to Test Page");
		App.WaitForElement("Item 3");
	}
}
#endif