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
        App.WaitForElement("FontFamilyCourierNewButton");
        App.Tap("FontFamilyCourierNewButton");
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
        App.WaitForElement("FontFamilyTimesNewRomanButton");
        App.Tap("FontFamilyTimesNewRomanButton");
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
        App.WaitForElement("FontFamilyCourierNewButton");
        App.Tap("FontFamilyCourierNewButton");
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
        App.WaitForElement("FontFamilyCourierNewButton");
        App.Tap("FontFamilyCourierNewButton");
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
        App.WaitForElement("FontFamilyCourierNewButton");
        App.Tap("FontFamilyCourierNewButton");
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
