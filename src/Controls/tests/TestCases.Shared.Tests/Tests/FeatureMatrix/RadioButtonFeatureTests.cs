using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class RadioButtonFeatureTests : UITest
	{
		public const string RadioButtonFeatureMatrix = "RadioButton Feature Matrix";

		public RadioButtonFeatureTests(TestDevice device)
			: base(device)
		{
		}

		protected override void FixtureSetup()
		{
			base.FixtureSetup();
			App.NavigateToGallery(RadioButtonFeatureMatrix);
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetIsCheckedAndTextColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsCheckedTrueRadio");
			App.Tap("IsCheckedTrueRadio");
			App.WaitForElement("TextColorRedButton");
			App.Tap("TextColorRedButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetTextColorAndBorderColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("TextColorRedButton");
			App.Tap("TextColorRedButton");
			App.WaitForElement("BorderColorPurpleButton");
			App.Tap("BorderColorPurpleButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontAttributesAndTextColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontAttributesBold");
			App.Tap("FontAttributesBold");
			App.WaitForElement("TextColorBlueButton");
			App.Tap("TextColorBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontFamilyAndFontSize_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontFamilyMontserratBold");
			App.Tap("FontFamilyMontserratBold");
			App.WaitForElement("FontSizeEntry");
			App.ClearText("FontSizeEntry");
			App.EnterText("FontSizeEntry", "16");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetBorderWidthAndCornerRadius_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("BorderWidthEntry");
			App.ClearText("BorderWidthEntry");
			App.EnterText("BorderWidthEntry", "4");
			App.PressEnter();
			App.WaitForElement("CornerRadiusEntry");
			App.ClearText("CornerRadiusEntry");
			App.EnterText("CornerRadiusEntry", "12");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontFamilyAndTextTransform_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontFamilyMontserratBold");
			App.Tap("FontFamilyMontserratBold");
			App.WaitForElement("TextTransformUpper");
			App.Tap("TextTransformUpper");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetContentAndTextColor_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ContentEntry");
			App.ClearText("ContentEntry");
			App.EnterText("ContentEntry", "Colored Text");
			App.PressEnter();
			App.WaitForElement("TextColorBlueButton");
			App.Tap("TextColorBlueButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetContentAndFontSize_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ContentEntry");
			App.ClearText("ContentEntry");
			App.EnterText("ContentEntry", "Large Text");
			App.PressEnter();
			App.WaitForElement("FontSizeEntry");
			App.ClearText("FontSizeEntry");
			App.EnterText("FontSizeEntry", "24");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetContentAndFontAttributes_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ContentEntry");
			App.ClearText("ContentEntry");
			App.EnterText("ContentEntry", "Bold Option");
			App.PressEnter();
			App.WaitForElement("FontAttributesBold");
			App.Tap("FontAttributesBold");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetContentAndTextTransform_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ContentEntry");
			App.ClearText("ContentEntry");
			App.EnterText("ContentEntry", "transform this");
			App.PressEnter();
			App.WaitForElement("TextTransformUpper");
			App.Tap("TextTransformUpper");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetIsCheckedAndContent_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsCheckedTrueRadio");
			App.Tap("IsCheckedTrueRadio");
			App.WaitForElement("ContentEntry");
			App.ClearText("ContentEntry");
			App.EnterText("ContentEntry", "Checked Option");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetIsCheckedAndBorderWidth_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsCheckedTrueRadio");
			App.Tap("IsCheckedTrueRadio");
			App.WaitForElement("BorderWidthEntry");
			App.ClearText("BorderWidthEntry");
			App.EnterText("BorderWidthEntry", "3");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontSizeAndCharacterSpacing_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontSizeEntry");
			App.ClearText("FontSizeEntry");
			App.EnterText("FontSizeEntry", "18");
			App.PressEnter();
			App.WaitForElement("CharacterSpacingEntry");
			App.ClearText("CharacterSpacingEntry");
			App.EnterText("CharacterSpacingEntry", "2");
			App.PressEnter();
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontFamilyAndFontAttributes_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontFamilyMontserratBold");
			App.Tap("FontFamilyMontserratBold");
			App.WaitForElement("FontAttributesBold");
			App.Tap("FontAttributesBold");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.RadioButton)]
		public void RadioButton_SetFontSizeAndFontAttributes_VerifyVisualState()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("FontSizeEntry");
			App.ClearText("FontSizeEntry");
			App.EnterText("FontSizeEntry", "20");
			App.PressEnter();
			App.WaitForElement("FontAttributesItalic");
			App.Tap("FontAttributesItalic");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("RadioButtonControl");
			// VerifyScreenshot();
		}
	}
}
