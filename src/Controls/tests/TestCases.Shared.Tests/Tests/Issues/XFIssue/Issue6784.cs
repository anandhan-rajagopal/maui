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

	[Test]
	public void CurrentItemIsSetWhenSelectingShellSectionAggregatedInMoreTab()
	{
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.WaitForElementTillPageNavigationSettled("Success");
	}

	[Test]
	public void OneMoreControllerOpensOnFirstClick()
	{
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		App.Tap("Tab 5");
		App.Tap("Tab 4");
		App.WaitForElement("Tab 4");
		App.Tap("More");
		App.WaitForElement("Tab 6");
		App.Tap("Tab 6");
	}

	[Test]
	public void TwoMoreControllerDoesNotShowEditButton()
	{
		App.WaitForElement("More");
		App.Tap("More");
		App.WaitForElement("Tab 5");
		Assert.That(App.FindElements("Edit").Count(), Is.EqualTo(0));
	}
}
