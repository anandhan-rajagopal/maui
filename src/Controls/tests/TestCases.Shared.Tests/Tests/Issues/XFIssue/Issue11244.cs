#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_ANDROID // The text in Android is partially visible More Information:https://github.com/dotnet/maui/issues/19747 and the text is not overridden in windows More information:https://github.com/dotnet/maui/issues/1625
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue11244 : _IssuesUITest
{
	public Issue11244(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] BackButtonBehavior no longer displays on the first routed page in 4.7";

	 
	[Test]
	[Category(UITestCategories.Shell)]
	public void LeftToolbarItemTextDisplaysWhenFlyoutIsDisabled()
	{
		App.WaitForElement("Logout");
	}
	
}
#endif