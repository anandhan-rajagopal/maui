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
            + "The purpose is to determine whether the text resizes appropriately when a large amount of content is entered.";
        App.EnterText("TextEntry", testParagraph);
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetAutoSizeAndPlaceholder_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("AutoSizeTextChangesButton");
        App.Tap("AutoSizeTextChangesButton");
        App.WaitForElement("PlaceholderEntry");
        string testParagraph = "This is a long paragraph of text used to test the AutoSizeTextChange property of the Editor control. "
            + "The purpose is to determine whether the text resizes appropriately when a large amount of content is entered.";
        App.EnterText("PlaceholderEntry", testParagraph);
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetCharacterSpacingAndPlaceholder_VerifyVisualState()  // for windows CharacterSpacing not set to placeholder
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "4");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "PlaceholderText");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetCharacterSpacingAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "4");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAttributesAndFontFamily_VerifyVisualState()
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

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAttributesAndFontSize_VerifyVisualState()
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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAttributesAndPlaceholder_VerifyVisualState()
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
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAttributesAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Editor Text");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetFontAttributesAndTextTransform_VerifyVisualState()
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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetMaxLengthAndText()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "EditorText");
        App.WaitForElement("MaxLengthEntry");
        App.ClearText("MaxLengthEntry");
        App.EnterText("MaxLengthEntry", "5");
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

#if TEST_FAILS_ON_ANDROID // In Android, HorizontalTextAlignment is not working. Issue Link - https://github.com/dotnet/maui/issues/10987
    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetHorizontalTextAlignmentAndPlaceholder_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentEndButton");
        App.Tap("HorizontalTextAlignmentEndButton");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text Horizontally End");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }
#endif

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetHorizontalTextAlignmentAndText_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Text Horizontally Center");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

#if TEST_FAILS_ON_ANDROID // While automation Android does not prevent text input when IsReadOnly is set to true
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
#endif

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

#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST // keyboard not supported on Windows and MacCatalyst
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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }
#endif

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderAndPlaceholderColor_VerifyVisualState()
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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetPlaceholderAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("PlaceholderEntry");
        App.EnterText("PlaceholderEntry", "Placeholder Text Vertically End");
        App.WaitForElement("VerticalTextAlignmentEndButton");
        App.Tap("VerticalTextAlignmentEndButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

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
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Editor)]
    public void Editor_SetTextAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("VerticalTextAlignmentEndButton");
        App.Tap("VerticalTextAlignmentEndButton");
        App.WaitForElement("TextEntry");
        App.EnterText("TextEntry", "Text Vertically End");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(4000).Wait();
        // VerifyScreenshot();
    }
}
