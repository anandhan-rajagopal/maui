#if TEST_FAILS_ON_WINDOWS // AutomationId is not working for stacklayout More Information:https://github.com/dotnet/maui/issues/4715
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue12429 : _IssuesUITest
{
	public Issue12429(TestDevice testDevice) : base(testDevice)
	{
	}

#if ANDROID
	const string SmallFlyoutItem = "SmallFlyoutItem";
#else
    const string SmallFlyoutItem="I'm set to specific height: ";
#endif
    const string ResizeMe = "Default Flyout Item. Height is 44 on iOS and UWP. Height is 50 on Android)";

#if IOS
    double SmallFlyoutItemValue=35d;
#elif ANDROID
	double SmallFlyoutItemValue = 93d;
#elif MACCATALYST
    double SmallFlyoutItemValue=28d;
#endif

#if IOS
    double SizeToModifyBy=20d;
#elif MACCATALYST
    double SizeToModifyBy=15d;
#endif
	public override string Issue => "[Bug] Shell flyout items have a minimum height";

	[Test, Order(1)]
	[Category(UITestCategories.Shell)]
	public void FlyoutItemSizesToExplicitHeight()
	{
		App.WaitForElement("PageLoaded");
		App.ShowFlyout();
		var height = App.WaitForElement(SmallFlyoutItem).GetRect();
		Assert.That(height.Height, Is.EqualTo(SmallFlyoutItemValue).Within(1));
	}
#if !ANDROID
    [Test, Order(2)]
    [Category(UITestCategories.Shell)]
    public void FlyoutItemHeightAndWidthIncreaseAndDecreaseCorrectly()
    {
        App.WaitForElement(ResizeMe);
        var initialHeight = App.WaitForElement(ResizeMe).GetRect().Y;
 
        App.Tap("ResizeFlyoutItem");
        var newHeight = App.WaitForElement(ResizeMe).GetRect().Y;
        Assert.That(newHeight - initialHeight, Is.EqualTo(SizeToModifyBy).Within(1));
 
        App.Tap("ResizeFlyoutItemDown");
        newHeight = App.WaitForElement(ResizeMe).GetRect().Y;
        Assert.That(initialHeight, Is.EqualTo(newHeight).Within(1));
      
        App.Tap("ResizeFlyoutItemDown");
        newHeight = App.WaitForElement(ResizeMe).GetRect().Y;
        Assert.That(initialHeight - newHeight, Is.EqualTo(SizeToModifyBy).Within(1));
 
    }
#endif
}
#endif
