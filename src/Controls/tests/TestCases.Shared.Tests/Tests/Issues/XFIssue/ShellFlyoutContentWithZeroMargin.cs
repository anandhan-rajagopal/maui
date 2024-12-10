#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_ANDROID // Flyout content with zero margin does not get offset by the safe area, and this is enabled only for iOS.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.Shell)]
public class ShellFlyoutContentWithZeroMargin : _IssuesUITest
{
	public ShellFlyoutContentWithZeroMargin(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Shell Flyout Content With Zero Margin offsets correctly";

	[Test]
	public void FlyoutContentIgnoresSafeAreaWithZeroMargin()
	{
		App.WaitForElement("PageLoaded");
		App.ShowFlyout();
		var flyoutLoc = App.WaitForElement("FlyoutLabel").GetRect().Y;
		Assert.That(flyoutLoc, Is.EqualTo(0));
	}
}
#endif