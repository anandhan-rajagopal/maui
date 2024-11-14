#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST //while click back button, button is not wroking
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue9794 : _IssuesUITest
	{
		public Issue9794(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[iOS] Tabbar Disappears with linker";
		
		[Test]
		[Category(UITestCategories.Shell)]
		public void EnsureTabBarStaysVisibleAfterPoppingPage()
		{
			App.Tap("GoForward");
#if WINDOWS
			App.TapBackArrow();
#endif
			App.Back();
			App.Tap("tab2");
			App.Tap("tab1");
			App.Tap("tab2");
			App.Tap("tab1");
			App.Tap("tab2");
			App.Tap("tab1");
		}
	}
}
#endif