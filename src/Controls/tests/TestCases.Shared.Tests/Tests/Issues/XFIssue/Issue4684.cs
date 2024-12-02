using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;
public class Issue4684 : _IssuesUITest
{
	public Issue4684(TestDevice testDevice) : base(testDevice)
	{
	}
#if ANDROID
    const string connect="CONNECT";
    const string control="CONTROL";
#else
	const string connect = "Connect";
	const string control = "Control";
#endif
	public override string Issue => "[Android] don't clear shell content because native page isn't visible";

	[Test]
	[Category(UITestCategories.Shell)]
	public void NavigatingBackAndForthDoesNotCrash()
	{
		App.TapInShellFlyout("Connect");
#if WINDOWS
        App.Tap("navViewItem");
#endif
		App.WaitForElementTillPageNavigationSettled("Connect");
		App.Tap(control);

		App.TapInShellFlyout("Home");
		App.WaitForElementTillPageNavigationSettled("Control");
		App.TapInShellFlyout("Connect");
#if WINDOWS
        App.Tap("navViewItem");
#endif
		App.Tap(connect);
		App.WaitForElement("Connect");
#if WINDOWS
     App.Tap("navViewItem");
#endif
		App.Tap(control);

		App.WaitForElement("Success");
	}
}