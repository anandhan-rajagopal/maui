using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class TabbedPageFeatureTests : UITest
{
	const string TabbedPageFeatureMatrix = "TabbedPage Feature Matrix";

	public TabbedPageFeatureTests(TestDevice testDevice) : base(testDevice)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(TabbedPageFeatureMatrix);
	}

	[Test, Order(1)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_InitialState_VerifyVisualState()
	{
		App.WaitForElement("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(2)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_Gradient_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("GradientBarBackgroundButton");
		App.Tap("GradientBarBackgroundButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(3)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_Solid_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("SolidBarBackgroundButton");
		App.Tap("SolidBarBackgroundButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(4)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_And_BarTextColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("SolidBarBackgroundButton");
		App.Tap("SolidBarBackgroundButton");
		App.WaitForElement("GreenBarTextButton");
		App.Tap("GreenBarTextButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(5)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_With_SelectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("SolidBarBackgroundButton");
		App.Tap("SolidBarBackgroundButton");
		App.WaitForElement("PurpleSelectedButton");
		App.Tap("PurpleSelectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(6)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_With_UnselectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("SolidBarBackgroundButton");
		App.Tap("SolidBarBackgroundButton");
		App.WaitForElement("DarkGrayUnselectedButton");
		App.Tap("DarkGrayUnselectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(7)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarTextColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("GreenBarTextButton");
		App.Tap("GreenBarTextButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(8)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarTextColor_And_SelectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("GreenBarTextButton");
		App.Tap("GreenBarTextButton");
		App.WaitForElement("PurpleSelectedButton");
		App.Tap("PurpleSelectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(9)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarTextColor_And_UnselectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("GreenBarTextButton");
		App.Tap("GreenBarTextButton");
		App.WaitForElement("DarkGrayUnselectedButton");
		App.Tap("DarkGrayUnselectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(10)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_SelectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("OrangeSelectedButton");
		App.Tap("OrangeSelectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(11)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_UnselectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("DarkGrayUnselectedButton");
		App.Tap("DarkGrayUnselectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test, Order(12)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_SelectedAndUnselectedTabColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("PurpleSelectedButton");
		App.Tap("PurpleSelectedButton");
		App.WaitForElement("LightGrayUnselectedButton");
		App.Tap("LightGrayUnselectedButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
		App.WaitForElement("SECOND PAGE");
		App.Tap("SECOND PAGE");
		VerifyScreenshot();
	}

#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST // Issue Link - 

	[Test, Order(13)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_FlowDirection_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("RightToLeftFlowRadio");
		App.Tap("RightToLeftFlowRadio");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}
#endif

	[Test, Order(14)]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_IsEnabled_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForNoElement("ApplyButton");
	}
}