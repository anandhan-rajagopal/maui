#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST // The sample needs redefining due to a Handler not found exception, as it involves a custom class requiring handlers.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2976 : _IssuesUITest
{
	public Issue2976(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Sample 'WorkingWithListviewNative' throw Exception on Xam.Android project.";

	[Test]
	[Category(UITestCategories.ListView)]
	public void Issue1Test()
	{
		App.Tap("DEMOA");
		App.Tap("DEMOB");
		App.Tap("DEMOC");
		App.Tap("DEMOD");
	}
}
#endif