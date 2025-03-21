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
        public void SearchBar_CancellButtonColorTextColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("CancelButtonGreenColor");
            App.Tap("CancelButtonGreenColor");
            App.WaitForElement("TextColorRedButton");
            App.Tap("TextColorRedButton");            
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-3E) Checking the CharacterSpacing and Cursor Position
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_CharacterSpacingCursorPosition_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "10");
            App.PressEnter();
            App.WaitForElement("CursorPositionEntry");
            App.EnterText("CursorPositionEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("characterSpacingLabel");
            var characterSpacing = App.WaitForElement("characterSpacingLabel").GetText();
            Assert.That(characterSpacing, Is.EqualTo("10"));
            App.WaitForElement("CursorPositionLabel");
            var cursorPosition = App.WaitForElement("CursorPositionLabel").GetText();
            Assert.That(cursorPosition, Is.EqualTo("5"));
        }

        //(Excel-5H) Checking the FontAttributes and Font Familly of Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesFontFamily_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("FontFamilyCourierNewButton");
            App.Tap("FontFamilyCourierNewButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-5I) Checking the FontAttributes and FontSize
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesFontSize_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");
            App.WaitForElement("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.PressEnter();      
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }        

        //(Excel-5J) Checking the FontAttributes and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesHorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-5P) Checking the FontAttributes and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesPlaceholderText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");            
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-5U) Checking the FontAttributes and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesSearchText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesItalicButton");
            App.Tap("FontAttributesItalicButton");            
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-5W) Checking the FontAttributes and TextTransform
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesTextTransform_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("TextTransformUppercaseButton");
            App.Tap("TextTransformUppercaseButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-5X) Checking the FontAttributes and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontAttributesVerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontAttributesBoldButton");
            App.Tap("FontAttributesBoldButton");
            App.WaitForElement("VerticalTextAlignmentCenterButton");
            App.Tap("VerticalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-7I) Checking the FontFamily and FontSize
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontFamily_FontSize_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontFamilyTimesNewRomanButton");
            App.Tap("FontFamilyTimesNewRomanButton");
            App.WaitForElement("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.PressEnter();      
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-7J) Checking the FontFamily and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontFamily_HorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontFamilyTimesNewRomanButton");
            App.Tap("FontFamilyTimesNewRomanButton");
            App.WaitForElement("HorizontalTextAlignmentEndButton");
            App.Tap("HorizontalTextAlignmentEndButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-7P) Checking the FontFamily and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontFamily_Placeholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyTimesNewRomanButton");
            App.Tap("FontFamilyTimesNewRomanButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-7U) Checking the FontFamily and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontFamily_SearchText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontFamilyTimesNewRomanButton");
            App.Tap("FontFamilyTimesNewRomanButton");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-7X) Checking the FontFamily and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontSize_VerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontFamilyCourierNewButton");
            App.Tap("FontFamilyCourierNewButton");
            App.WaitForElement("VerticalTextAlignmentCenterButton");
            App.Tap("VerticalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-8J) Checking the FontSize and HorizontalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontSize_HorizontalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.PressEnter();
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }
        
        //(Excel-8P) Checking the FontSize and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontSize_Placeholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.PressEnter();
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-8U) Checking the FontSize and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_FontSize_SearchText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FontSizeEntry");
            App.EnterText("FontSizeEntry", "20");
            App.PressEnter();
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }
    
        //(Excel-9P) Checking the HorizontalTextAlignment and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_HorizontalTextAlignment_Placeholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }
        //(Excel-9U) Checking the HorizontalTextAlignment and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_HorizontalTextAlignment_SearchText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("HorizontalTextAlignmentEndButton");
            App.Tap("HorizontalTextAlignmentEndButton");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-9X) Checking the HorizontalTextAlignment and VerticalTextAlignment
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_HorizontalTextAlignment_VerticalTextAlignment_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("HorizontalTextAlignmentCenterButton");
            App.Tap("HorizontalTextAlignmentCenterButton");
            App.WaitForElement("VerticalTextAlignmentCenterButton");
            App.Tap("VerticalTextAlignmentCenterButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-14D) Checking the MaxLength and CharacterSpacing
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_MaxLengthCharacterSpacing_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.PressEnter();
            App.WaitForElement("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "2");
            App.PressEnter();
            App.WaitForElement("EntryText");
            App.EnterText("EntryText", "Search");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
            App.WaitForElement("CharacterSpacingLabel");
            var characterSpacing = App.WaitForElement("CharacterSpacingLabel").GetText();
            Assert.That(characterSpacing, Is.EqualTo("10"));
            VerifyScreenshot();
        }
        //(Excel-14P) Checking the MaxLength and Placeholder Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_MaxLengthPlaceholder_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.PressEnter();
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
        }
        //(Excel-14T) Checking the MaxLength and SelectionLength
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_MaxLengthSelectionLength_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.PressEnter();
            App.WaitForElement("SelectionLengthEntry");
            App.EnterText("SelectionLengthEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
            App.WaitForElement("SelectionLengthLabel");
            var selectionLength = App.WaitForElement("SelectionLengthLabel").GetText();
            Assert.That(selectionLength, Is.EqualTo("5"));
        }

        //(Excel-14U) Checking the MaxLength and Search Text
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_MaxLengthSearchText_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaxLengthEntry");
            App.EnterText("MaxLengthEntry", "10");
            App.PressEnter();
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("MaxLengthLabel");
            var maxLength = App.WaitForElement("MaxLengthLabel").GetText();
            Assert.That(maxLength, Is.EqualTo("10"));
            App.WaitForElement("SearchBar");
            var searchText = App.WaitForElement("SearchBar").GetText();
            var textLength = searchText?.Length;
            Assert.That(searchText, Is.EqualTo(10));
        }

        //(Excel-15Q) Checking the Placeholder and PlaceholderColor
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_Placeholder_PlaceholderColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("PlaceholderColorRedButton");
            App.Tap("PlaceholderColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-16V) Checking the Placeholder Color and Text Color
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_PlaceholderColorTextColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextColorGreenButton");
            App.Tap("TextColorGreenButton");
            App.WaitForElement("PlaceholderEntry");
            App.EnterText("PlaceholderEntry", "Placeholder Text");
            App.PressEnter();
            App.WaitForElement("PlaceholderColorRedButton");
            App.Tap("PlaceholderColorRedButton");            
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-20W) Checking the SearchBar Text and TextTransform
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SearchTextVerify()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "Search Text");
            App.PressEnter();
            App.WaitForElement("TextTransformUppercaseButton");
            App.Tap("TextTransformUppercaseButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElement("SearchBar");
            var text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeSearchField")).GetText();
            Assert.That(text, Is.EqualTo("SEARCH TEXT"));
        }

        //(Excel-20D) Checking the SearchBar Text and CharacterSpacing
        [Test]
        [Category(UITestCategories.SearchBar)]
        public void SearchBar_SearchTextCharacterSpacing_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("TextEntry");
            App.EnterText("TextEntry", "SearchText");
            App.PressEnter();
            App.WaitForElement("CharacterSpacingEntry");
            App.EnterText("CharacterSpacingEntry", "10");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            VerifyScreenshot();
        }

        //(Excel-20X) Checking the SearchBar Text and VerticalTextAlignment
        // [Test]
        // [Category(UITestCategories.SearchBar)]
        // public void SearchBar_SearchTextVerticalTextAlignment_VerifyVisualState() //VerticalTextAlignment not set correctly for start
        // {
        //     App.WaitForElement("Options");
        //     App.Tap("Options");
        //     App.WaitForElement("TextEntry");
        //     App.EnterText("TextEntry", "Search Text");
        //     App.PressEnter();
        //     App.WaitForElement("VerticalTextAlignmentStartButton");
        //     App.Tap("VerticalTextAlignmentStartButton");
        //     App.WaitForElement("Apply");
        //     App.Tap("Apply");
        //     VerifyScreenshot();
        // }
	}
}
