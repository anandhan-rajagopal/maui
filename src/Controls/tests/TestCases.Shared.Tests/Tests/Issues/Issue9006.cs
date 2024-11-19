using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue9006 : _IssuesUITest
	{
		public Issue9006(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[Bug] Unable to open a new Page for the second time in Xamarin.Forms Shell Tabbar";

		[Test]
		[Category(UITestCategories.Shell)]
		[Category(UITestCategories.Compatibility)]
		public void ClickingOnTabToPopToRootDoesntBreakNavigation()
		{
			App.Tap("Click Me");
			App.WaitForElement("FinalLabel");
			App.TapBackArrow();
			App.TapBackArrow();
			App.Tap("Click Me");
			App.WaitForElement("Success");
		}
	}
}