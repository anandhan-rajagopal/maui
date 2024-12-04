//fails on ios , its working on automationId only
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue11214 : _IssuesUITest
{
	public Issue11214(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "When adding FlyoutItems during Navigating only first one is shown";

	[Test]
	[Category(UITestCategories.Shell)]

	public void FlyoutItemChangesPropagateCorrectlyToPlatformForShellElementsNotCurrentlyActive()
	{
		App.WaitForElement("Open the Flyout");
		App.TapInShellFlyout("Click Me and You Should see 2 Items show up");
#if WINDOWS
		App.TapInShellFlyout("Click Me and You Should see 2 Items show up");
#endif
		for (int i = 0; i < 2; i++)
			App.WaitForElement($"Some Item: {i}");
		App.Tap("Click Me and You Should see 2 Items show up");
#if ANDROID
		App.TapShellFlyoutIcon();
#endif
		for (int i = 0; i < 2; i++)
			App.WaitForNoElement($"Some Item: {i}");
	}

}