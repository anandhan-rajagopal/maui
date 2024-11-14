#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS
//The secondary toolbar icon does not work correctly on both MacCatalyst and iOS.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue6127 : _IssuesUITest
{
	public Issue6127(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Bug] ToolbarItem Order property ignored";

	[Test]
	[Category(UITestCategories.ToolbarItem)]
	public void Issue6127Test()
	{
		App.WaitForElement("PrimaryToolbarIcon");

		App.TapMoreButton();
		App.WaitForElement("SecondaryToolbarIcon");

		App.Screenshot("There is a secondary toolbar menu and item");
	}
}
#endif