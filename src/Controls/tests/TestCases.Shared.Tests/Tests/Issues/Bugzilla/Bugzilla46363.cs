using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
public class Bugzilla46363 : _IssuesUITest
{
	public Bugzilla46363(TestDevice testDevice) : base(testDevice)
	{
	}
	const string ContextAction = "Context Action";
	const string ContextSuccess = "Context Menu Success";
	public override string Issue => "TapGestureRecognizer blocks List View Context Actions";
 
	[Test]
	[Category(UITestCategories.ListView)]
	public void _46363_Tap_Succeeds()
	{
		App.WaitForElement("TestingLabel");
		App.Tap("Two");
		Assert.That(App.WaitForElement("TestingLabel").GetText(), Is.EqualTo("Tap Success"));
		App.WaitForNoElement(ContextAction);
	}
	[Test]
	[Category(UITestCategories.ListView)]
	public void _46363_ContextAction_Succeeds()
	{
		App.WaitForElement("TestingLabel");
		App.ContextActions("Two");
		App.WaitForElement(ContextAction);
		App.Tap(ContextAction);
		App.WaitForElement(ContextSuccess);
	}
}