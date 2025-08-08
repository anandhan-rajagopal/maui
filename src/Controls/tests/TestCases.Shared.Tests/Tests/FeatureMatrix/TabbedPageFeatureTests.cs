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

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_InitialState_VerifyVisualState()
	{
		App.WaitForElement("HOME PAGE");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackground_Verify()
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

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarBackgroundColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("GreenBarBackgroundButton");
		App.Tap("GreenBarBackgroundButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_BarTextColor_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("RedBarTextButton");
		App.Tap("RedBarTextButton");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}

	[Test]
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

	[Test]
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

	[Test]
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

	[Test]
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
		VerifyScreenshot();
	}

	[Test]
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

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPage_IsVisible_Verify()
	{
		App.WaitForElement("THIRD PAGE");
		App.Tap("THIRD PAGE");
		App.WaitForElement("OptionsButton");
		App.Tap("OptionsButton");
		App.WaitForElement("IsVisibleFalseRadio");
		App.Tap("IsVisibleFalseRadio");
		App.WaitForElement("ApplyButton");
		App.Tap("ApplyButton");
		App.WaitForElement("HOME PAGE");
		App.Tap("HOME PAGE");
		VerifyScreenshot();
	}
}