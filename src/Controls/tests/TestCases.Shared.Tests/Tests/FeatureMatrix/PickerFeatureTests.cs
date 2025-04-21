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
    public void Picker_SetPickerAndCharacterSpacing_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("CharacterSpacingEntry");
        App.ClearText("CharacterSpacingEntry");
        App.EnterText("CharacterSpacingEntry", "5");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndFontAttributes_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndTextColor_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("TextColorGreenButton");
        App.Tap("TextColorGreenButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontAttributesAndFontFamily_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontAttributesAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetFontFamilyAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "40");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndHorizontalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndTitle_VerifyVisualState() // On ios Title not shown when index is set to -1 and 
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }
    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndSelectedIndex_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("SelectedIndexLabel");
        var selectedIndexText = App.WaitForElement("SelectedIndexLabel").GetText();
        Assert.That(selectedIndexText, Is.EqualTo("1"));
    }
    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetPickerAndSelectedItem_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectedIndexEntry");
        App.ClearText("SelectedIndexEntry");
        App.EnterText("SelectedIndexEntry", "1");
        App.WaitForElement("SelectedItemEntry");
        App.ClearText("SelectedItemEntry");
        App.EnterText("SelectedItemEntry", "Item 2");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("SelectedItemLabel");
        var selectedItemText = App.WaitForElement("SelectedItemLabel").GetText();
        Assert.That(selectedItemText, Is.EqualTo("Item 2"));
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndTitleColor_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");  // Title not show title when index is set to -1 in ios and mac.
        App.WaitForElement("TitleColorGreenButton");  //Title color not set to picker in ios and mac. https://github.com/dotnet/maui/issues/19191
        App.Tap("TitleColorGreenButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndHorizontalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("HorizontalTextAlignmentCenterButton");
        App.Tap("HorizontalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.Picker)]
    public void Picker_SetTitleAndVerticalTextAlignment_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("TitleEntry");
        App.ClearText("TitleEntry");
        App.EnterText("TitleEntry", "Picker Title");
        App.WaitForElement("VerticalTextAlignmentCenterButton");
        App.Tap("VerticalTextAlignmentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Thread.Sleep(3000);
        // VerifyScreenshot();
    }

}
