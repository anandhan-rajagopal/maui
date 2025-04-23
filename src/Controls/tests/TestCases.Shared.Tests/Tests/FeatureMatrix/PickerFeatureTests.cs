using System;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

public class PickerFeatureTests : UITest
{
    public const string PickerFeatureMatrix = "Picker Feature Matrix";
    public PickerFeatureTests(TestDevice testDevice) : base(testDevice)
    {
    }
    protected override void FixtureSetup()
    {
        base.FixtureSetup();
        App.NavigateToGallery(PickerFeatureMatrix);
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetCharacterSpacing_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "5");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontAttributes_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetHorizontalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetHorizontalTextAlignmentAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTextColor_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TextColorGreenButton");
        App.Tap("TextColorGreenButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontAttributesAndFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontAttributesAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontFamilyAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS // Picker ItemDisplayBinding doesn't support MVVM properly. Issue Link - https://github.com/dotnet/maui/issues/25634
    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetItemDisplayBinding()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemDisplayBindingIdButton");
        App.Tap("ItemDisplayBindingIdButton");        
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("PickerControl");
        var pickerText = App.WaitForElement("PickerControl").GetText();
        Assert.That(pickerText, Is.EqualTo("2"));
    }
#endif

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetSelectedIndex_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "3");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("SelectedIndexLabel");
        var selectedIndexText = App.WaitForElement("SelectedIndexLabel").GetText();
        Assert.That(selectedIndexText, Is.EqualTo("3"));
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetSelectedItem()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "2");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("PickerControl");
        var pickerText = App.WaitForElement("PickerControl").GetText();
        Assert.That(pickerText, Is.EqualTo("Item 2"));
        // VerifyScreenshot();
    }

#if TEST_FAILS_ON_CATALYST // In Mac picker items not shown when title is set. Issue link - https://github.com/dotnet/maui/issues/27474
    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitle_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "New Picker Title");
        App.WaitForElement("Apply");
        App.Tap("Apply");
#if MACCATALYST
        App.WaitForElement("PickerControl");
        App.Tap("PickerControl");
        App.TapDisplayAlertButton("Done");
#endif
        // VerifyScreenshot();
    }
#endif

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndFontAttributes_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndHorizontalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS // In Mac and iOS title color not set to picker. Issue link - https://github.com/dotnet/maui/issues/19191
    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndTitleColor_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("TitleColorGreenButton");
        App.Tap("TitleColorGreenButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
#endif

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "-1");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
}
