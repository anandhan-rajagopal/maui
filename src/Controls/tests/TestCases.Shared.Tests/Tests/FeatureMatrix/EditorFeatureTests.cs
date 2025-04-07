using System;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

public class EditorFeatureTests : UITest
{
    public const string EditorFeatureMatrix = "Editor Feature Matrix";

    public EditorFeatureTests(TestDevice device)
        : base(device)
    {
    }

    protected override void FixtureSetup()
    {
        base.FixtureSetup();
        App.NavigateToGallery(EditorFeatureMatrix);
    }

    //2O
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetAutoSizeAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("AutoSizeTextChangesButton");
        App.Tap("AutoSizeTextChangesButton");
        App.WaitForElement("TextEntry");
        string testParagraph = "This is a long paragraph of text used to test the AutoSizeTextChange property of the Editor control. "
            + "The purpose is to determine whether the text resizes appropriately when a large amount of content is entered. "
            + "As more text is added, the font size may shrink to fit the text within the bounds of the editor, depending on the auto-size settings. "
            + "This behavior helps ensure that all the content remains visible without requiring scrolling or clipping.";
        App.EnterText("TextEntry", testParagraph);
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }
    //(2F)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetCharacterSpacingAndPlaceholder_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "2");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "PlaceholderText");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(2I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetCharacterSpacingAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "2");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(3D)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAtributesAndFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesBoldButton");
        App.Tap("FontAttributesBoldButton");
        App.WaitForElement("FontFamilyMontserratBoldButton");
        App.Tap("FontFamilyMontserratBoldButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Button Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(3E)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAtributesAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesBoldButton");
        App.Tap("FontAttributesBoldButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Button Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(3G)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAtributesAndPlaceholder_VerifyVisualState()
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

    //(3I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAtributesAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(3k)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAtributesAndTextTransform_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesBoldButton");
        App.Tap("FontAttributesBoldButton");
        App.WaitForElement("TextTransformUppercaseButton");
        App.Tap("TextTransformUppercaseButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(4E
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontFamilyAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(4G)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontFamilyAndPlaceholder_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyMontserratBoldButton");
        App.Tap("FontFamilyMontserratBoldButton");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    //(4I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontFamilyAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyMontserratBoldButton");
        App.Tap("FontFamilyMontserratBoldButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(4K)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontFamilyAndTextTransform_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyMontserratBoldButton");
        App.Tap("FontFamilyMontserratBoldButton");
        App.WaitForElement("TextTransformUppercaseButton");
        App.Tap("TextTransformUppercaseButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    //(5G)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontSizeAndPlaceholder_VerifyVisualState()
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

    //(5I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontSizeAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(5K)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontSizeAndTextTransform_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("TextTransformUppercaseButton");
        App.Tap("TextTransformUppercaseButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    //(6I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetMaxLengthAndText()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("MaxLengthEntry");
        App.ClearText("MaxLengthEntry");
        App.EnterText("MaxLengthEntry", "5");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "EditorText");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        var text = string.Empty;
#if ANDROID
        text = App.WaitForElement("EditorControl").GetText();
#elif IOS || MACCATALYST
        text = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeTextView")).GetText();
#else
        text = App.WaitForElement("EditorControl").GetText();
#endif
        Assert.That(text, Is.EqualTo("Edito"));
    }

    //(7M)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetHorizontalTextAlignmentAndPlaceholder_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Centered Placeholder");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(7O)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetHorizontalTextAlignmentAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Centered Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(8O)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetIsReadOnlyAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("IsReadOnlyTrueButton");
        App.Tap("IsReadOnlyTrueButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "ReadOnly Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");

        var initialText = string.Empty;
#if ANDROID
        initialText = App.WaitForElement("EditorControl").GetText();
#elif IOS || MACCATALYST
        initialText = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeTextView")).GetText();
#else
        initialText = App.WaitForElement("EditorControl").GetText();
#endif

        App.EnterText("EditorControl", "Attempted Change");

        var finalText = string.Empty;
#if ANDROID
        finalText = App.WaitForElement("EditorControl").GetText();
#elif IOS || MACCATALYST
        finalText = App.WaitForElement(AppiumQuery.ByXPath("//XCUIElementTypeTextView")).GetText();
#else
        finalText = App.WaitForElement("EditorControl").GetText();
#endif

        Assert.That(initialText, Is.EqualTo("ReadOnly Text"));
        Assert.That(finalText, Is.EqualTo(initialText));
        // VerifyScreenshot();
    }

    //(9O)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetIsSpellCheckEnabledAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("IsSpellCheckEnabledTrueButton");
        App.Tap("IsSpellCheckEnabledTrueButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("EditorControl");
        App.EnterText("EditorControl", "Ths is a spleling eror");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    //(10O)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetIsTextPredictionEnabledAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("IsTextPredictionEnabledTrueButton");
        App.Tap("IsTextPredictionEnabledTrueButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("EditorControl");
        App.EnterText("EditorControl", "t");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    //(11O)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetKeyboardAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("KeyboardNumericButton");
        App.Tap("KeyboardNumericButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("EditorControl");
        App.EnterText("EditorControl", "1234567890");

        // VerifyScreenshot();
    }
    //(7I)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    //(7K)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderAndTextTransform_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text");
        App.WaitForElement("TextTransformLowercaseButton");
        App.Tap("TextTransformLowercaseButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(8L)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    //(8J)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderColorAndTextColor_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("PlaceholderColorRedButton");
        App.Tap("PlaceholderColorRedButton");
        App.WaitForElement("TextColorGreenButton");
        App.Tap("TextColorGreenButton");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    //(9K)
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetTextAndTextTransform_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("TextTransformUppercaseButton");
        App.Tap("TextTransformUppercaseButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
}
