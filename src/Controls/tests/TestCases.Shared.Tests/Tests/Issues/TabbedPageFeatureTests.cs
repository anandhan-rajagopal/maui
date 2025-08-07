using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class TabbedPageFeatureTests : _IssuesUITest
{
	const string TabbedPageFeatureTestsGalleryName = "TabbedPage Feature Matrix";

	public TabbedPageFeatureTests(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => TabbedPageFeatureTestsGalleryName;

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageLoadsCorrectly()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageNavigationWorks()
	{
		// Verify we can navigate to different tabs
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Test tab switching
		App.Tap("Settings");
		App.WaitForElement("Settings");
		VerifyScreenshot();

		App.Tap("Profile");
		App.WaitForElement("Profile");
		VerifyScreenshot();

		App.Tap("About");
		App.WaitForElement("About");
		VerifyScreenshot();

		// Return to Home tab
		App.Tap("Home");
		App.WaitForElement("Home");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageOptionsPageNavigation()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		VerifyScreenshot();

		// Navigate back
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageBarBackgroundColorTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test BarBackgroundColor changes
		App.Tap("BlueBarBackgroundColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Red color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("RedBarBackgroundColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Green color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("GreenBarBackgroundColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageBarTextColorTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test BarTextColor changes
		App.Tap("BlackBarTextColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test White color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("WhiteBarTextColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Red color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("RedBarTextColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageSelectedTabColorTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test SelectedTabColor changes
		App.Tap("BlueSelectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Orange color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("OrangeSelectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Purple color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("PurpleSelectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageUnselectedTabColorTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test UnselectedTabColor changes
		App.Tap("GrayUnselectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test LightGray color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("LightGrayUnselectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test DarkGray color
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("DarkGrayUnselectedTabColorButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageBarBackgroundBrushTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test Gradient brush
		App.Tap("GradientBarBackgroundBrushButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test Solid brush
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("SolidBarBackgroundBrushButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test None (default)
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("NoneBarBackgroundBrushButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageIsVisibleTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test IsVisible = False
		App.Tap("IsVisibleFalseRadioButton");
		App.Tap("ApplyButton");
		
		// TabbedPage should not be visible
		App.WaitForNoElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Navigate back to options and set IsVisible = True
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("IsVisibleTrueRadioButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageIsEnabledTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test IsEnabled = False
		App.Tap("IsEnabledFalseRadioButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test IsEnabled = True
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("IsEnabledTrueRadioButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPageFlowDirectionTest()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Navigate to options page
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");

		// Test FlowDirection = RightToLeft
		App.Tap("FlowDirectionRTLRadioButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();

		// Test FlowDirection = LeftToRight
		App.Tap("OptionsButton");
		App.WaitForElement("TabbedPageOptionsPage");
		App.Tap("FlowDirectionLTRRadioButton");
		App.Tap("ApplyButton");
		App.WaitForElement("TabbedPageFeatureTestPage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void TabbedPagePropertyValuesDisplayCorrectly()
	{
		App.WaitForElement("TabbedPageFeatureTestPage");
		
		// Verify initial property values are displayed
		App.WaitForElement("PropertyValuesDisplay");
		
		var propertyValues = App.WaitForElement("PropertyValuesDisplay").GetText();
		Assert.That(propertyValues, Does.Contain("BarBackgroundColor"));
		Assert.That(propertyValues, Does.Contain("BarTextColor"));
		Assert.That(propertyValues, Does.Contain("SelectedTabColor"));
		Assert.That(propertyValues, Does.Contain("UnselectedTabColor"));
		Assert.That(propertyValues, Does.Contain("IsVisible"));
		Assert.That(propertyValues, Does.Contain("IsEnabled"));
		Assert.That(propertyValues, Does.Contain("FlowDirection"));
		
		VerifyScreenshot();
	}
}
