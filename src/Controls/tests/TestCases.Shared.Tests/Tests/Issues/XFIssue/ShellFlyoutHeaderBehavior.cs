#if TEST_FAILS_ON_CATALYST // Scroll not supported on MacCatalyst
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class ShellFlyoutHeaderBehavior : _IssuesUITest
{
	public ShellFlyoutHeaderBehavior(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Shell Flyout Header Behavior";
#if !WINDOWS // AuomationId not working in Windows
	[Test]
	[Category(UITestCategories.Shell)]
	public void FlyoutHeaderBehaviorFixed()
	{
		App.WaitForElement("Fixed");
		App.Tap("Fixed");
		float startingHeight = GetFlyoutHeight();
		App.ScrollDown("Item 4", ScrollStrategy.Gesture);
		float endHeight = GetFlyoutHeight();

		Assert.That(startingHeight, Is.EqualTo(endHeight));
	}
#endif
#if !WINDOWS && !IOS // Rect value differs on IOS
    [Test]
    [Category(UITestCategories.Shell)]
    public void FlyoutHeaderBehaviorCollapseOnScroll()
    {
        App.WaitForElement("CollapseOnScroll");
        App.Tap("CollapseOnScroll");
        float startingHeight = GetFlyoutHeight();
        App.ScrollDown("Item 4", ScrollStrategy.Gesture);
        float endHeight = GetFlyoutHeight();
 
        Assert.That(startingHeight, Is.GreaterThan(endHeight));
    }
#endif
#if !IOS && !ANDROID // Rect value differs on IOS && Android
    [Test]
    [Category(UITestCategories.Shell)]
    public void FlyoutHeaderBehaviorScroll()
    {
        App.WaitForElement("Scroll");
        App.Tap("Scroll");
        var startingY = GetFlyoutY();
        App.ScrollDown("Item 5", ScrollStrategy.Gesture);
        var nextY = GetFlyoutY();
 
        while (nextY != null && startingY != null)
        {
            Assert.That(startingY.Value, Is.GreaterThan(nextY.Value));
            startingY = nextY;
            App.ScrollDown("Item 5", ScrollStrategy.Gesture);
            nextY = GetFlyoutY();
        }
    }
#endif
	float GetFlyoutHeight() =>
		App.WaitForElement("FlyoutHeaderId").GetRect().Height;

	float? GetFlyoutY()
	{
		var flyoutHeader =
			App.FindElements("FlyoutHeaderId");

		foreach (var element in flyoutHeader)
		{
			return element.GetRect().Y;
		}
		return null;
	}
}
#endif
