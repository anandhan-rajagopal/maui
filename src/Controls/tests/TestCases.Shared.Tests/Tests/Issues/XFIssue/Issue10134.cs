#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS // DragCoordinates is not supported on MacCatalyst; in Windows Tab12 is visible, while on Android tapping elements causes the top tabs to scroll back to the beginning.
using NUnit.Framework;
using NUnit.Framework.Legacy;
using UITest.Appium;
using UITest.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Github10134 : _IssuesUITest
{
	public Github10134(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Shell Top Tabbar focus issue";

	[Test]
	[Category(UITestCategories.Shell)]

	public void TopTabsDontScrollBackToStartWhenSelected()
	{
		App.WaitForElement("Tab 1");
		var element1 = App.WaitForElement("Tab 1").GetRect();
		App.WaitForNoElement("Tab 12");

		var element2 = element1;

		for (int i = 2; i < 20; i++)
		{
			var results = App.FindElements($"Tab {i}");

			foreach (var result in results)
			{
				element2 = result.GetRect();
				break;
			}

			if (results.Count == 0)
				break;
		}
		
		App.DragCoordinates(element2.CenterX(), element2.CenterY(), element1.CenterX(), element1.CenterY());

		App.WaitForNoElement("Tab 1");
		bool testPassed = false;
		for (int i = 20; i > 1; i--)
		{
			var results = App.FindElements($"Tab {i}");

			if (results.Count > 0)
			{
				App.Tap($"Tab {i}");
				App.WaitForElement($"Tab {i}");
				testPassed = true;
				break;
			}
		}
		App.WaitForNoElement("Tab 1");
		Assert.That(testPassed, Is.True);

	}
}
#endif