#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_ANDROID // Orientation not support in windows and mac , MainPage was not updated as tile in Android
 // Setting orientation is not supported on Windows
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla34632 : _IssuesUITest
{
	public Bugzilla34632(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Can't change IsPresented when setting SplitOnLandscape ";


	[Test]
	[Category(UITestCategories.FlyoutPage)]
	public void Bugzilla34632Test()
	{

		App.SetOrientationPortrait();
		App.Tap("btnModal");
		App.SetOrientationLandscape();
		App.Tap("btnDismissModal");
		App.Tap("btnModal");
		App.SetOrientationPortrait();
		App.Tap("btnDismissModal");
		App.Tap("Main Page");
		App.Tap("btnFlyout");
		App.WaitForNoElement("btnFlyout");

	}

	[TearDown]
	public void TearDown()
	{
		App.SetOrientationPortrait();
	}
}
#endif