#if TEST_FAILS_ON_CATALYST //Sample not renders in Android.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue18716 : _IssuesUITest
	{
		public Issue18716(TestDevice device)
			: base(device)
		{ }

		public override string Issue => "Touch events are not working on WebView when a PDF is displayed";

		
  		//There's an issue getting the mouse interactions to work with Appium.
		[Test]
		[Category(UITestCategories.WebView)]
		public void CanScrollWebView()
		{
			App.WaitForElement("WaitForStubControl");
			App.ScrollDown("WaitForStubControl", ScrollStrategy.Gesture, 0.75);
			App.Screenshot("Scrolling has been done correctly.");
		}
  
	}
}
#endif