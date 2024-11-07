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

			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("Minimum: 0"));
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("Maximum: 1"));
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 0"));
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMinimumValue_VerifyMaximumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "3");
			App.PressEnter();
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("Minimum: 3"));
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetMaximumValue_VerifyMinimumLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MaximumEntry", "20");
			App.PressEnter();
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("Maximum: 20"));
		}
		[Test]
		[Category(UITestCategories.Slider)]
		public void Slider_SetCurrentValue_VerifyValueLabel()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("ValueEntry", "1");
			App.PressEnter();
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 1"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 100"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 50"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: -2"));
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
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("Maximum: 25"));
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
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("Maximum: 50"));
		}

		[Test]
		[Category(UITestCategories.Slider)]
		public void MinimumIsSetNegativeMaximumShouldNotChangeDefaultValue()
		{
			App.WaitForElement("ResetButton");
			App.Tap("ResetButton");
			App.EnterText("MinimumEntry", "-1");
			App.PressEnter();
			Assert.That(App.FindElement("MaximumValueLabel").GetText(), Is.EqualTo("Maximum: 1"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 50"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 20"));
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
			Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("Value: 20"));
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
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("Minimum: 60"));
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
			Assert.That(App.FindElement("MinimumValueLabel").GetText(), Is.EqualTo("Minimum: 20"));
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
#elif ANDROID
            App.TouchAndHold("SliderControl");     
#endif
			Task.Delay(TimeSpan.FromSeconds(15)).Wait();
			Assert.That(App.FindElement("DragStartStatusLabel").GetText(), Is.EqualTo("Drag Started"));
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
#elif ANDROID
        App.TouchAndHold("SliderControl");  
#endif
			App.Tap("DragCompletedStatusLabel");
			Assert.That(App.FindElement("DragCompletedStatusLabel").GetText(), Is.EqualTo("Drag Completed"));
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









