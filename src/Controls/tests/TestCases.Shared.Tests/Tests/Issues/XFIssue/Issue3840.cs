//Blank UI in all platforms.
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

	// TODO: The _ variables need to be AutomationId values
			[Test]
			[FailsOnIOSWhenRunningOnXamarinUITest]
			[Category(UITestCategories.ScrollView)]
			public void TranslatingViewKeepsScrollViewPosition()
			{
				App.WaitForElement(_failedText);
				App.Tap(_button1);
				App.Tap(_button2);
	#if WINDOWS
				var label = App.WaitForElement(_failedText);
				Assert.AreEqual(0, label[0].Rect.Height);
				Assert.AreEqual(0, label[0].Rect.Width);
	#else
			var result = App.QueryUntilNotPresent(() => App.WaitForElement(_failedText));
	#endif
		}
}