using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests
{
	public class SliderFeatureTests : UITest
	{
		public const string SliderFeatureMatrix = "Slider Feature Matrix";

		public SliderFeatureTests(TestDevice device)
			: base(device)
		{
		}

		protected override void FixtureSetup()
		{
			base.FixtureSetup();
			App.NavigateToGallery(SliderFeatureMatrix);
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ValidateDefaultValues_VerifyLabels()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			Assert.That(App.WaitForTextToBePresentInElement("MinimumValueLabel", "Minimum: 0"), Is.True, "Default Value for Minimum should be 0.");
			Assert.That(App.WaitForTextToBePresentInElement("MaximumValueLabel", "Maximum: 1"), Is.True, "Default Value for Maximum should be 1.");
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 0"), Is.True, "Default value for Value should be 0.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinimumValue_VerifyMaximumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "3");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MinimumValueLabel", "Minimum: 3"), Is.True, "Minimum value should be updated to 3.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaximumValue_VerifyMinimumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "20");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MaximumValueLabel", "Maximum: 20"), Is.True, "Maximum value should be updated to 20.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetCurrentValue_VerifyValueLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 1"), Is.True, "Current value should be updated to 1.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueExceedsMaximum()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "100");
			App.PressEnter();
			App.EnterText("ValueEntry", "150");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 100"), Is.True, "The value should not exceed the maximum and should be capped at 100.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueWithinRange()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "100");
			App.PressEnter();
			App.EnterText("ValueEntry", "50");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 50"), Is.True, "The current value should be set to 50.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinimumValue_CheckValueLabel()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "-5");
			App.PressEnter();
			App.EnterText("ValueEntry", "-2");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: -2"),
						Is.True, "The value label should display the correct value of 30.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_MinimumExceedsMaximum_SetsMaximumToMinimum()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "50");
			App.PressEnter();
			App.EnterText("MaximumEntry", "25");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MaximumValueLabel", "Maximum: 25"), Is.True, "Updated maximum value should match new minimum, 20.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ValueAboveMaximum_CheckMaximumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("ValueEntry", "70");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MaximumValueLabel", "Maximum: 50"), Is.True, "The maximum label should display the correct maximum value of 50.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void MinimumIsSetNegativeMaximumShouldNotChangeDefaultValue()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "-1");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MaximumValueLabel", "Maximum: 1"), Is.True, " maximum value should not change from Default Value, 1.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void SliderCurrentValueHigherThanMinimumAndMaximumTest()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("ValueEntry", "60");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 50"), Is.True, "Current value should be updated to 60.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void SliderCurrentValueLowerThanMinimumAndMaximumTest()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "20");
			App.PressEnter();
			App.EnterText("MaximumEntry", "30");
			App.PressEnter();
			App.EnterText("ValueEntry", "10");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 20"), Is.True, "Current value should be updated to 60.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void CurrentValueIsSetToMinimum()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.EnterText("MaximumEntry", "20");
			App.PressEnter();
			App.EnterText("ValueEntry", "15");
			App.PressEnter();
			App.ClearText("MinimumEntry");
			App.EnterText("MinimumEntry", "20");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("ValueLabel", "Value: 20"), Is.True, "Updated value should match  minimum, 20.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinimumAboveMaximum()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.EnterText("MinimumEntry", "60");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MinimumValueLabel", "Minimum: 60"), Is.True, "The updated minimum value should be set to 60.");
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ValueBelowMinimum_CheckMinimumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "20");
			App.PressEnter();
			App.EnterText("ValueEntry", "10");
			App.PressEnter();
			Assert.That(App.WaitForTextToBePresentInElement("MinimumValueLabel", "Minimum: 20"), Is.True, "The minimum label should display the correct minimum value of 20.");
		}

#if !MACCATALYST

		[Test]
		[Category(UITestCategories.Slider)]
		public void SliderDisplaysDragStartedStatusLabelOnHold()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
#if WINDOWS 
			App.DragCoordinates(550,240,580,240);
#elif IOS 
            App.DragCoordinates(50,65,130,200);
#endif 
			Task.Delay(TimeSpan.FromSeconds(15)).Wait();
			Assert.That(App.WaitForTextToBePresentInElement("DragStartStatusLabel", "Drag Started"),
			Is.True, "DragStartStatusLabel should display 'Drag Started' when dragging.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void SliderDisplaysDragCompletedStatusLabelOnRelease()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ResetButton");
#if WINDOWS
			App.DragCoordinates(550, 240, 580, 240);
#elif IOS 
            App.DragCoordinates(50,65,130,200);
#endif
			App.Tap("DragCompletedStatusLabel");
			Assert.That(App.WaitForTextToBePresentInElement("DragCompletedStatusLabel", "Drag Completed"),
						Is.True, "DragCompletedStatusLabel should display 'Drag Completed' after dragging.");
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetEnabledStateToFalse_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeFlowDirection_RTL_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetVisibilityToFalse_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsVisibleFalseRadio");
			App.WaitForNoElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_ChangeThumbImageSource_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinimumAndChangeFlowDirection_RTL()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
	
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaximumAndChangeFlowDirection_RTL()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
 
	
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueAndMinTrackColor_VerifyVisualState()
		{ 
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueAndMaxTrackColor_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueAndThumbImageSource_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetValueAndFlowDirection_RTL_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetThumbAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbColorButton");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetThumbAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbColorButton");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetThumbAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbColorButton");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetThumbColorAndThumbImageSource_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbColorButton");
			App.Tap("ThumbImageSourceButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinTrackColorAndValue_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinTrackAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinTrackAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinTrackAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinTrackColorTestFlowDirection_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MinTrackColorButton");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaxTrackColorAndValue_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaxTrackAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaxTrackAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaxTrackAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaxTrackColorTestFlowDirection_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("MaxTrackColorButton");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsEnableAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsEnableAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsEnableAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsEnableAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsEnabledTrueRadio");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
	
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsVisibleAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsVisibleAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsVisibleAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetIsVisibleAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("IsVisibleTrueRadio");
			App.Tap("BackgroundColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetBackgroundColorAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("BackgroundColorButton");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetBackgroundColorAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("BackgroundColorButton");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetBackgroundColorAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("BackgroundColorButton");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetBackgroundColorAndIsEnable_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("BackgroundColorButton");
			App.Tap("IsEnabledTrueRadio");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();

		}

		[Test]
		[Category(UITestCategories.Slider)]
		
		public void Slider_SetThumbImageSourceAndThumbColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("ThumbImageSourceButton");
			App.Tap("ThumbColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_FlowDirection_RTL_SetMinimumValue_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.EnterText("MinimumEntry", "10");
			App.PressEnter();
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_FlowDirection_RTL_SetMaximumValue_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.EnterText("MaximumEntry", "50");
			App.PressEnter();
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_FlowDirection_RTL_SetValue_VerifyVisualState()
		{

			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.EnterText("ValueEntry", "0");
			App.PressEnter();
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetFlowDirectionAndMinTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.Tap("MinTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
		
		[Test]
		[Category(UITestCategories.Slider)]
 
		public void Slider_SetFlowDirectionAndMaxTrackColor_VerifyVisualState()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.Tap("FlowDirectionRTL");
			App.Tap("MaxTrackColorButton");
			App.WaitForElement("SliderControl", timeout: TimeSpan.FromSeconds(5));
			VerifyScreenshot();
		}
#endif

		}
	}









