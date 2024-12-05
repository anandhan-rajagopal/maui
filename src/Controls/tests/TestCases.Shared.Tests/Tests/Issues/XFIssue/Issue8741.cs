using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
public class Issue8741 : _IssuesUITest
{
	public Issue8741(TestDevice testDevice) : base(testDevice)
	{
	}
 
	public override string Issue => "[Bug] [Shell] [Android] ToolbarItem Enabled/Disabled behavior does not work for Shell apps";
 
	[Test]
	[Category(UITestCategories.Shell)]
	public void Issue8741Test()
	{
		App.WaitForElement("Add");
		App.Tap("Add");

		//Note: these methods were commented because Appium doesn't provide a reliable way to access the exact color values of UI elements across different platforms and devices.
		//var toolbarItemColorValue = GetToolbarItemColorValue();
		//int disabledAlpha = GetAlphaValue(toolbarItemColorValue);
 
		Assert.That(App.WaitForElement("ClickCount").ReadText(), Is.EqualTo("0"));
 
		App.Tap("ToggleEnabled");
		App.Tap("Add");
 
		//toolbarItemColorValue = GetToolbarItemColorValue();
		//int enabledAlpha = GetAlphaValue(toolbarItemColorValue);
		//Assert.That(disabledAlpha, Is.LessThan(enabledAlpha));
 
		Assert.That(App.WaitForElement("ClickCount").ReadText(), Is.EqualTo("1"));
 
		App.Tap("ToggleEnabled");
		App.Tap("Add");
 
		Assert.That(App.WaitForElement("ClickCount").ReadText(), Is.EqualTo("1"));
	}
}