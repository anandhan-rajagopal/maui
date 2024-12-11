#if TEST_FAILS_ON_WINDOWS //User clicks "Between" to view Tab 2. Rapid clicking occurs between this and the "Click" item.
//The app freezes and becomes unresponsive, requiring a force close. The issue only manifests during automated testing scenarios and cannot be reproduced through normal manual user interaction.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue10608 : _IssuesUITest
{
#if ANDROID
	const string Tab1 = "TAB 1";
	const string Tab2 = "TAB 2";
	const string FlyoutItem6 = "Let me click for you";
#else
	const string Tab1 = "Tab1AutomationId";
	const string Tab2 = "Tab2AutomationId";
	const string FlyoutItem6 = "FlyoutItem6";
#endif

	public Issue10608(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] [Shell] [iOS] Locked flyout causes application to freezes when quickly switching between tabs";

	[Test]
	[Category(UITestCategories.Shell)]
	public void ShellWithTopTabsFreezesWhenNavigatingFlyoutItems()
	{
        App.Tap(FlyoutItem6);
		App.Tap("FlyoutItem0");
		for (int i = 0; i < 5; i++)
		{
			App.WaitForElement(Tab1);
			App.WaitForElement("LearnMoreButton");
			App.Tap("FlyoutItem0");
			App.Tap("FlyoutItem1");
			App.Tap("FlyoutItem0");
			App.WaitForElement("LearnMoreButton");
		}

		App.WaitForElement(Tab1);
		App.WaitForElement("LearnMoreButton");
		App.Tap("FlyoutItem1");
		App.WaitForElement(Tab2);
		App.WaitForElement("LearnMoreButton");
		App.Tap("FlyoutItem0");
		App.WaitForElement(Tab1);
		App.WaitForElement("LearnMoreButton");
	}
}
#endif