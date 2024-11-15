//Working fine with the Android
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla46363 : _IssuesUITest
{
	public Bugzilla46363(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TapGestureRecognizer blocks List View Context Actions";

	[Test]
	[Category(UITestCategories.ListView)]
	public void _46363_Tap_Succeeds()
	{
		App.WaitForElement("TestingLabel");
		App.Tap("Two");
		Assert.That(App.WaitForElement("TestingLabel").GetText(), Is.EqualTo("Tap Success"));

		// First run at fixing this caused the context menu to open on a regular tap
		// So this check is to ensure that doesn't happen again
		App.WaitForNoElement("Context Action");
	}

	[Test]
	[Category(UITestCategories.ListView)]
	public void _46363_ContextAction_Succeeds()
	{
		App.WaitForElement("TestingLabel");
		App.ActivateContextMenu("Two");
		App.WaitForElement("Context Action");
		App.Tap("Context Action");
		App.WaitForElement("Context Menu Success");
	}
}