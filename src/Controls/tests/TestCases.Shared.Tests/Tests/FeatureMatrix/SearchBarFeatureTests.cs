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

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetCancelButtonAndTextColor_VerifyVisualState()
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
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetHorizontalTextAlignmentAndPlaceholder_VerifyVisualState() // For ios, Mac placeholder text not set the with horizontal text alignment
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetHorizontalTextAlignmentAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("VerticalTextAlignmentEndButton");
            App.Tap("VerticalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            // VerifyScreenshot();
        }

#if TEST_FAILS_ON_ANDROID
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetIsReadOnlyAndText_VerifyVisualState() // For android IsReadOnly not prevent typing text during automation
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
#endif

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetIsSpellCheckEnabledAndText_VerifyVisualState()
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
        public void SearchBar_SetIsTextPredictionEnabledAndText_VerifyVisualState() // In android, ios, Mac while automation nothing happens for prediction
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

#if TestFailsOnMacCatalyst && TestFailsOnWindows // For MacCatalyst and Windows, the virtual keyboard is not displayed
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetKeyboardAndText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("KeyboardNumericButton");
            App.Tap("KeyboardNumericButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.Tap("SearchBar");
            App.EnterText("SearchBar", "1234567890");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }
#endif

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

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetPlaceholderAndCharacterSpacing_VerifyVisualState() // For windows characterSpacing not set to placeholder text
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
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetPlaceholderAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.WaitForElement("VerticalTextAlignmentEndButton");
            App.Tap("VerticalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetTextAndCharacterSpacing_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
#if ANDROID
            App.WaitForElement("CharacterSpacingEntry");
            App.ClearText("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "10");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "SearchText");
#else
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "SearchText");
            App.WaitForElement("CharacterSpacingEntry");
            App.ClearText("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "10");
            App.WaitForElement("Apply");
            App.Tap("Apply");
#endif
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

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
            App.EnterText("SearchBar", "SearchText");
            App.WaitForElement("SearchBar");
            var text = string.Empty;
#if ANDROID
            text = App.WaitForElement("SearchBar").GetText();
#elif IOS || MACCATALYST
            text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeSearchField")).GetText();
#else
            text = App.WaitForElement("TextBox").GetText();
#endif
            Assert.That(text, Is.EqualTo("SEARCHTEXT"));
        }

        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SetTextAndVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("VerticalTextAlignmentEndButton");
            App.Tap("VerticalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            App.EnterText("SearchBar", "Search Text");
            App.WaitForElement("SearchBar");
            // VerifyScreenshot();
        }
    }
}
