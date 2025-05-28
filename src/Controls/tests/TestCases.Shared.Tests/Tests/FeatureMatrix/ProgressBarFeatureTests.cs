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
		public void ProgressBar_SetProgressOutOfRange()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "1.44");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("1.00"));
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetProgressNegativeValue()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ProgressEntry");
			App.EnterText("ProgressEntry", "-0.44");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			Assert.That(App.FindElement("ProgressValueLabel").GetText(), Is.EqualTo("0.00"));
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
			// VerifyScreenshot();
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
			// VerifyScreenshot();
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
			// VerifyScreenshot();
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
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.ProgressBar)]
		public void ProgressBar_SetFlowDirectionAndBackgroundColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FlowDirectionRTL");
			App.Tap("FlowDirectionRTL");
			App.Tap("BackgroundColorLightBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("ProgressBarControl");
			// VerifyScreenshot();
		}
	}
}
