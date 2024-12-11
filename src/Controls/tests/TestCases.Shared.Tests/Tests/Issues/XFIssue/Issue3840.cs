using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
namespace Microsoft.Maui.TestCases.Tests.Issues;
public class Issue3840 : _IssuesUITest
{
	public Issue3840(TestDevice testDevice) : base(testDevice)
	{
		
	}
	const string _failedText = "Test Failed if Visible";
	const string _button1 = "FirstClick";
	const string _button2 = "SecondClick";	
	public override string Issue => "[iOS] Translation change causes ScrollView to reset to initial position (0, 0)";

	[Test]
	[Category(UITestCategories.ScrollView)]
	public void TranslatingViewKeepsScrollViewPosition()
	{
		App.WaitForElement(_failedText);
		App.Tap(_button1);
		App.Tap(_button2);
		App.WaitForNoElement(_failedText);
	}
}