#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST // TapFlyoutIcon not working in Android and timed out exception in mac when third time tap flyouicon
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue7339 : _IssuesUITest
{
	public Issue7339(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[iOS] Material frame renderer not being cleared";

	 
	[Test]
	[Category(UITestCategories.Shell)]
	public void MaterialFrameDisposesCorrectly()
	{
		App.TapFlyoutIcon();
		App.Tap("Item1");
		App.TapFlyoutIcon();
		App.Tap("Item2");
		App.TapFlyoutIcon();
		App.Tap("Item1");
		App.TapFlyoutIcon();
		App.Tap("Item2");

	}
}
#endif