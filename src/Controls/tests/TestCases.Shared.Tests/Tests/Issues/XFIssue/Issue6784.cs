#if TEST_FAILS_ON_CATALYST // null reference exception 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.Shell)]
public class Issue6784 : _IssuesUITest
{
	public Issue6784(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "ShellItem.CurrentItem is not set when selecting shell section aggregated in more tab";

	public void CurrentItemIsSetWhenSelectingShellSectionAggregatedInMoreTab()
	{
#if ANDROID || IOS
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.WaitForElement("Success");
#else
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.WaitForElement("Success");
#endif
	}

	[Test]
	public void MoreControllerOpensOnFirstClick()
	{
#if ANDROID || IOS
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.Tap("Tab 4");
		App.WaitForElement("Tab 4");
		App.Tap("More");
		App.WaitForElement("Tab 6");
#else
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.Tap("Tab 4");
		App.WaitForElement("Tab 4");
		App.WaitForElement("Tab 6");
#endif

	}

	[Test]
	public void MoreControllerDoesNotShowEditButton()
	{
#if ANDROID || IOS
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		Assert.That(App.FindElement("Edit"), Is.Null);
#else
		App.WaitForElement("Tab 5");
		Assert.That(App.FindElement("Edit"), Is.Null);
#endif

	}
}
#endif