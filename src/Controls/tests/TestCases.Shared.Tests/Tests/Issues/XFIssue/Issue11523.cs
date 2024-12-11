#if TEST_FAILS_ON_CATALYST //Back button doesn't working on the MacCatalyst.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue11523 : _IssuesUITest
{
	public Issue11523(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] FlyoutBehavior.Disabled removes back-button from navbar";

	[Test]
	[Category(UITestCategories.Shell)]
	public void BackButtonStillVisibleWhenFlyoutBehaviorDisabled()
	{
		App.WaitForElement("PageLoaded");
		TapBack();
		FlyoutIcon();
	}

	void TapBack()
	{
#if IOS
		App.Back();
#else
		App.TapBackArrow();
#endif
	}
	
	void FlyoutIcon()
	{
#if Android
		App.WaitForElement(AppiumQuery.ByXPath("//android.widget.ImageButton[@content-desc='Open navigation drawer']"));
#else
		App.WaitForElement(FlyoutIconAutomationId);
#endif
	}
}
#endif