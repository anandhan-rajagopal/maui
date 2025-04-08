using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
    public class SearchBarFeatureTests : UITest
    {
        public const string SearchBarFeatureMatrix = "Search Bar Feature Matrix";

        public SearchBarFeatureTests(TestDevice testDevice) : base(testDevice)
        {
        }

        protected override void FixtureSetup()
        {
            base.FixtureSetup();
            App.NavigateToGallery(SearchBarFeatureMatrix);
        }

        //(Excel-2V) Checking the Cancell button color and Search Text color
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetCancellButtonAndColorTextColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("CancelButtonGreenColor");
            App.Tap("CancelButtonGreenColor");
            App.WaitForElement("TextColorRedButton");
            App.Tap("TextColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5H) Checking the FontAttributes and Font Familly of Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndFontFamily_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("FontFamilyMontserratBoldButton");
            App.Tap("FontFamilyMontserratBoldButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5I) Checking the FontAttributes and FontSize
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndFontSize_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");
            App.WaitForElement("FontSizeEntry");
            App.ClearText("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5J) Checking the FontAttributes and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndHorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5P) Checking the FontAttributes and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndPlaceholderText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }

        //(Excel-5U) Checking the FontAttributes and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5W) Checking the FontAttributes and TextTransform
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndTextTransform_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("TextTransformUppercaseButton");
            App.Tap("TextTransformUppercaseButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-5X) Checking the FontAttributes and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontAttributesAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("VerticalTextAlignmentEndButton");
            App.Tap("VerticalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-7I) Checking the FontFamily and FontSize
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontFamilyAndFontSize_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyDokdoButton");
            App.Tap("FontFamilyDokdoButton");
            App.WaitForElement("FontSizeEntry");
            App.ClearText("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-7J) Checking the FontFamily and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontFamilyAndHorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyDokdoButton");
            App.Tap("FontFamilyDokdoButton");
            App.WaitForElement("HorizontalTextAlignmentEndButton");
            App.Tap("HorizontalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-7P) Checking the FontFamily and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontFamilyAndPlaceholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyDokdoButton");
            App.Tap("FontFamilyDokdoButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }

        //(Excel-7U) Checking the FontFamily and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontFamilyAndText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyDokdoButton");
            App.Tap("FontFamilyDokdoButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-7X) Checking the FontFamily and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontSizeAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyDokdoButton");
            App.Tap("FontFamilyDokdoButton");
            App.WaitForElement("VerticalTextAlignmentCenterButton");
            App.Tap("VerticalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-8J) Checking the FontSize and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontSizeAndHorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontSizeEntry");
            App.ClearText("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-8P) Checking the FontSize and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontSizeAndPlaceholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontSizeEntry");
            App.ClearText("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }

        //(Excel-8U) Checking the FontSize and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetFontSizeAndText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontSizeEntry");
            App.ClearText("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-9P) Checking the HorizontalTextAlignment and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetHorizontalTextAlignmentAndPlaceholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }
        //(Excel-9U) Checking the HorizontalTextAlignment and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetHorizontalTextAlignmentAndText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentEndButton");
            App.Tap("HorizontalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-9X) Checking the HorizontalTextAlignment and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetHorizontalTextAlignmentAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("VerticalTextAlignmentCenterButton");
            App.Tap("VerticalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

        //(Excel-13U) Checking the IsReadOnly and Text property
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetIsReadOnlyTextAndVerifyVisualState()  //IsReadOnly not privent typing text during automation
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsReadOnlyTrueButton");
            App.Tap("IsReadOnlyTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "ReadOnly");
            var text = string.Empty;
#if ANDROID
            text = App.WaitForElement("SearchBar").GetText();
#elif IOS || MACCATALYST
            text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeSearchField")).GetText();
#else
            text = App.WaitForElement("TextBox").GetText();
#endif
            Assert.That(text, Is.EqualTo(string.Empty));
            // VerifyScreenshot();
        }

        //(Excel-13V) Checking the IsSpellCheckEnabled and Text property
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetIsSpellCheckEnabledTextAndVerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsSpellCheckEnabledTrueButton");
            App.Tap("IsSpellCheckEnabledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Ths is a spleling eror");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetIsTextPredictionEnabledAndTextAndVerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsTextPredictionEnabledTrueButton");
            App.Tap("IsTextPredictionEnabledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "t");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        //(11O)
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetKeyboardAndTextAndVerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("KeyboardNumericButton");
            App.Tap("KeyboardNumericButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "1234567890");

            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.SearchBar)]           // placeholder text not reflecting the maxlength
        public void SearchBar_SetMaxLengthAndPlaceholder()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.ClearText("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
        }

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetMaxLengthAndSelectionLength()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.ClearText("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.WaitForElement("SelectionLengthEntry");
            App.ClearText("SelectionLengthEntry");
            App.EnterText("SelectionLengthEntry", "5");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
            App.WaitForElement("SelectionLengthLabel");
            var selectionLength = App.WaitForElement("SelectionLengthLabel").GetText();
            Assert.That(selectionLength, Is.EqualTo("5"));
        }

        //(Excel-14U) Checking the MaxLength and Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetMaxLengthAndText()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.ClearText("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
            App.WaitForElement("SearchBar");
            var text = string.Empty;
#if ANDROID
            text = App.WaitForElement("SearchBar").GetText();
#elif IOS || MACCATALYST
            text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeSearchField")).GetText();
#else
            text = App.WaitForElement("TextBox").GetText();
#endif
            var textLength = text?.Length;
            Assert.That(textLength, Is.EqualTo(10));
        }

        //(Excel-15D) Checking the Placeholder and CharacterSpacing
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetPlaceholderAndCharacterSpacingVerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("CharacterSpacingEntry");
            App.ClearText("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "10");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }
        //(Excel-15Q) Checking the Placeholder and PlaceholderColor
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetPlaceholderAndPlaceholderColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("PlaceholderColorRedButton");
            App.Tap("PlaceholderColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }

        //(Excel-16V) Checking the Placeholder Color and Text Color
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetPlaceholderColorAndTextColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextColorGreenButton");
            App.Tap("TextColorGreenButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("PlaceholderColorRedButton");
            App.Tap("PlaceholderColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            // VerifyScreenshot();
        }

        //(Excel-20E) Checking the Text and CharacterSpacing
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetTextAndCharacterSpacing_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("CharacterSpacingEntry");
            App.ClearText("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "5");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "SearchText");
            // VerifyScreenshot();
        }
        //(Excel-20W) Checking the Text and TextTransform
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetTextAndTextTransform()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextTransformUppercaseButton");
            App.Tap("TextTransformUppercaseButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            App.WaitForElement("SearchBar");
            var text = string.Empty;
#if ANDROID
            text = App.WaitForElement("SearchBar").GetText();
#elif IOS || MACCATALYST
            text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeSearchField")).GetText();
#else
            text = App.WaitForElement("TextBox").GetText();
#endif
            Assert.That(text, Is.EqualTo("SEARCH TEXT"));
        }
    }
}
