#if ANDROID && IOS
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2948 : _IssuesUITest
{
	public Issue2948(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "FlyoutPage Detail is interactive even when Flyout is open when in Landscape";

	[Test]
	[Category(UITestCategories.FlyoutPage)]
		public void Issue2948Test()
		{
			App.SetOrientationLandscape();
			if (ShouldRunTest())
			{
				var btnRect = App.WaitForElement("btnOnDetail").GetRect();
				App.Tap("ShowFlyoutBtn");
				App.DragCoordinates(btnRect.X + btnRect.Width-10, btnRect.Y + btnRect.Height / 2,
				btnRect.X + btnRect.Width-10,btnRect.Y + btnRect.Height / 2);
				App.WaitForNoElement("Clicked", "Time out", new TimeSpan(0, 0, 1));
			}
		}

		public bool ShouldRunTest()
		{
			var isMasterVisible = App.FindElements("Leads").Count > 0;
			return !isMasterVisible;
		}
		[TearDown]
		public void TearDown()
		{
			App.SetOrientationPortrait();
		}
}
#endif