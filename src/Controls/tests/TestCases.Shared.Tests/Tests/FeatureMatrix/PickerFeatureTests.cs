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
    public void Picker_SetPickerAndTitle_VerifyVisualState() 
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
        App.WaitForElement("Options");                // In Android text can be entered in picker. https://github.com/dotnet/maui/issues/8265
        App.Tap("Options");                           // In Mac picker items not shown when title is set. https://github.com/dotnet/maui/issues/27474
        App.ClearText("TitleEntry");                  // In Windows title is shown above the picker. https://github.com/dotnet/maui/issues/6845
        App.EnterText("TitleEntry", "Picker Title");  // In Mac and iOS title not show again. Even when selected index is set to -1 or selected item set to null.(No bug issue raised for this)
        App.WaitForElement("TitleColorGreenButton");  // In Mac and iOS title color not set to picker. https://github.com/dotnet/maui/issues/19191
        App.WaitForElement("Apply");                  // In Mac When opening the Picker, the first item is selected instead of the currently selected item. https://github.com/dotnet/maui/issues/27519
        App.Tap("Apply");                             // In all platforms selected index set in the picker control not works. https://github.com/dotnet/maui/issues/22028
        Thread.Sleep(3000);                           // Picker ItemDisplayBinding doesn't support MVVM properly. https://github.com/dotnet/maui/issues/25634
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
