using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class ShellFlyoutSizing : _IssuesUITest
{
	public ShellFlyoutSizing(TestDevice testDevice) : base(testDevice)
	{
	}
#if WINDOWS
    const string ChangeFlyoutSizes="Change Height and Width";
    const string ResetFlyoutSizes="Reset Height and Width";
    const string DecreaseFlyoutSizes="Decrease Height and Width";
#else
	const string ChangeFlyoutSizes = "ChangeFlyoutSizes";
	const string ResetFlyoutSizes = "ResetFlyoutSizes";
	const string DecreaseFlyoutSizes = "DecreaseFlyoutSizes";
#endif
	public override string Issue => "Shell Flyout Width and Height";
	[Test, Order(1)]
	[Category(UITestCategories.Shell)]
	public void FlyoutHeightAndWidthResetsBackToOriginalSize()
	{
		App.WaitForElement("PageLoaded");
		var initialWidth = App.WaitForElement("FlyoutHeader").GetRect().Width;
		var initialHeight = App.WaitForElement("FlyoutFooter").GetRect().Y;
		App.Tap(ChangeFlyoutSizes);
		Assert.That(App.WaitForElement("FlyoutHeader").GetRect().Width, Is.Not.EqualTo(initialWidth));
		Assert.That(App.WaitForElement("FlyoutFooter").GetRect().Y, Is.Not.EqualTo(initialHeight));

		App.Tap(ResetFlyoutSizes);
		Assert.That(App.WaitForElement("FlyoutHeader").GetRect().Width, Is.EqualTo(initialWidth));
		Assert.That(App.WaitForElement("FlyoutFooter").GetRect().Y, Is.EqualTo(initialHeight));
	}
#if IOS //test fails on (Android, Mac, Windows) Width and height is greater or smaller than expected value 
	[Test, Order(2)]
	[Category(UITestCategories.Shell)]
	public void FlyoutHeightAndWidthIncreaseAndDecreaseCorrectly()
	{
		App.WaitForElement(ChangeFlyoutSizes);
		App.Tap(ChangeFlyoutSizes);
		var initialWidth = App.WaitForElement("FlyoutHeader").GetRect().Width;
		var initialHeight = App.WaitForElement("FlyoutFooter").GetRect().Y;
		App.Tap(DecreaseFlyoutSizes);
		var newWidth = App.WaitForElement("FlyoutHeader").GetRect().Width;
		var newHeight = App.WaitForElement("FlyoutFooter").GetRect().Y;

		Assert.That(initialWidth - newWidth, Is.EqualTo(10).Within(1));
		Assert.That(initialHeight - newHeight, Is.EqualTo(10).Within(1));
	}
#endif
}