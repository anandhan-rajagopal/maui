#if TEST_FAILS_ON_IOS // App get freeze when press return key after entering text in Editor on iOS, issue: https://github.com/dotnet/maui/issues/26341 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue5500 : _IssuesUITest
{
	public Issue5500(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[iOS] Editor with material visuals value binding not working on physical device";

	[Test]
	[Category(UITestCategories.Editor)]
	public void VerifyEditorTextChangeEventsAreFiring()
	{
		App.WaitForElement("EditorAutomationId");
		App.EnterText("EditorAutomationId", "Test 1");

		Assert.That(App.WaitForElement("EditorAutomationId").ReadText(), Is.EqualTo("Test 1"));
		Assert.That(App.WaitForElement("EntryAutomationId").ReadText(), Is.EqualTo("Test 1"));
	
		App.ClearText("EntryAutomationId");
		App.EnterText("EntryAutomationId", "Test 2");

		Assert.That(App.WaitForElement("EditorAutomationId").ReadText(), Is.EqualTo("Test 2"));
		Assert.That(App.WaitForElement("EntryAutomationId").ReadText(), Is.EqualTo("Test 2"));
	}
}
#endif