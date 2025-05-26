using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class ProgressBarFeatureTests : UITest
	{
		public const string ProgressBarFeatureMatrix = "ProgressBar Feature Matrix";

		public ProgressBarFeatureTests(TestDevice device)
			: base(device)
		{
		}

		protected override void FixtureSetup()
		{
			base.FixtureSetup();
			App.NavigateToGallery(ProgressBarFeatureMatrix);
		}

		[Test, Order(1)]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_ValidateDefaultValues_VerifyLabels()
		{
			App.WaitForElement("Options");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("0.50"));
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressValue_VerifyValueLabel()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "0.75");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("0.75"));
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressOutOfRange_VerifyClampedValue()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "1.5");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("1.00"));
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressNegative_VerifyClampedValue()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "-0.5");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("0.00"));
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_ChangeProgressColorToGreen_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressColorGreenButton");
			App.Tap("ProgressColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_ChangeBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BackgroundColorLightBlueButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetEnabledStateToFalse_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetVisibilityToFalse_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleFalseRadio");
			App.Tap("IsVisibleFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("Options");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_ChangeFlowDirection_RTL_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "0.75");
			App.PressEnter();
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressAndProgressColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "0.75");
			App.PressEnter();
			App.Tap("ProgressColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressColorAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressColorGreenButton");
			App.Tap("ProgressColorGreenButton");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetFlowDirectionAndProgressColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.Tap("ProgressColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetIsEnabledAndProgressColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.Tap("ProgressColorGreenButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			VerifyScreenshot();
		}
	}
}
