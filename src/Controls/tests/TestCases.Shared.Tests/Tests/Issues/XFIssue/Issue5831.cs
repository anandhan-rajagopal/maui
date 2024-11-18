#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST//TAPfLYOUTiCON NOT WORK IN ANDROID AND SHOW NULL REFERENCE EXCEPION IN FLYOUTMAINTITLE

using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue5831 : _IssuesUITest
{
	const string flyoutMainTitle = "Main";
	const string flyoutOtherTitle = "Other Page";
	public Issue5831(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Navigating away from CollectionView and coming back leaves weird old items";

	[Test]
	[Category(UITestCategories.Shell)]
	public void CollectionViewRenderingWhenLeavingAndReturningViaFlyout()
	{
		App.TapFlyoutIcon();
		App.Tap(flyoutOtherTitle);
		App.TapFlyoutIcon();
		App.Tap(flyoutMainTitle);
	}
}
#endif