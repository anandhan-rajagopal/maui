#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST //The test fails on iOS and macOS with a TimeoutException in WaitForElement("cat").
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2499 : _IssuesUITest
{
	public Issue2499(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Binding Context set to Null in Picker";

	[Test]
	[Category(UITestCategories.Picker)]
	public void Issue2499Test()
	{
		App.WaitForElement("picker");
		App.Tap("picker");
		App.WaitForElement("cat");
		App.WaitForElement("mouse");
		App.Tap("mouse");

	// #if __IOS__
	// 		System.Threading.Tasks.Task.Delay(500).Wait();
	// 		var cancelButtonText = "Done";
	// 		App.WaitForElement(cancelButtonText);
	// 		App.Tap(cancelButtonText);
	// 		System.Threading.Tasks.Task.Delay(1000).Wait();
	// #endif

		App.WaitForNoElement("cat");
	}
}
#endif