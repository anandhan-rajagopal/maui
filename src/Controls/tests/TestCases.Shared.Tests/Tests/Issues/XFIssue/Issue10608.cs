#if TEST_FAILS_ON_WINDOWS
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue10608 : _IssuesUITest
{
	public Issue10608(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] [Shell] [iOS] Locked flyout causes application to freezes when quickly switching between tabs";

	[Test]
	[Category(UITestCategories.Shell)]
	public void ShellWithTopTabsFreezesWhenNavigatingFlyoutItems()
	{
#if ANDROID
		App.Tap("Let me click for you");
#else
        App.Tap("FlyoutItem6");
#endif
		App.Tap("FlyoutItem0");
		for (int i = 0; i < 5; i++)
		{
#if ANDROID
			App.WaitForElement("TAB 1");
#else
            App.WaitForElement("Tab1AutomationId");
#endif
			App.WaitForElement("LearnMoreButton");
			App.Tap("FlyoutItem0");
			App.Tap("FlyoutItem1");
			App.Tap("FlyoutItem0");
			App.WaitForElement("LearnMoreButton");
		}
#if ANDROID
		App.WaitForElement("TAB 1");
#else
        App.WaitForElement("Tab1AutomationId");
#endif
		App.WaitForElement("LearnMoreButton");
		App.Tap("FlyoutItem1");
#if ANDROID
		App.WaitForElement("TAB 2");
#else
        App.WaitForElement("Tab2AutomationId");
#endif
		App.WaitForElement("LearnMoreButton");
		App.Tap("FlyoutItem0");
#if ANDROID
		App.WaitForElement("TAB 1");
#else
        App.WaitForElement("Tab1AutomationId");
#endif
		App.WaitForElement("LearnMoreButton");
	}
}
#endif