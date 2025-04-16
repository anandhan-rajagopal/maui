using System;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

public class TimePickerFeatureTests : UITest
{
    public const string TimePickerFeatureMatrix = "Time Picker Feature Matrix";
    public TimePickerFeatureTests(TestDevice testDevice) : base(testDevice)
    {
    }
    protected override void FixtureSetup()
    {
        base.FixtureSetup();
        App.NavigateToGallery(TimePickerFeatureMatrix);
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndCharacterSpacing_VerifyVisualState()
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
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndFontAttributes_VerifyVisualState()
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
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndFontFamily_VerifyVisualState()
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
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndFontSize_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndFormat_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FormatEntry");
        App.ClearText("FormatEntry");
        App.EnterText("FormatEntry", "HH:mm:ss");
        App.WaitForElement("SetFormatButton");
        App.Tap("SetFormatButton");
        App.WaitForElement("TimeEntry");
        App.ClearText("TimeEntry");
        App.EnterText("TimeEntry", "17:00:00");
        App.WaitForElement("SetTimeButton");
        App.Tap("SetTimeButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        Task.Delay(2000).Wait();
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetTimeAndTextColor_VerifyVisualState()
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
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontAttributesAndFontFamily_VerifyVisualState()
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
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontAttributesAndFontSize_VerifyVisualState()
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
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontAttributesAndFormat_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontAttributesItalicButton");
        App.Tap("FontAttributesItalicButton");
        App.WaitForElement("FormatEntry");
        App.ClearText("FormatEntry");
        App.EnterText("FormatEntry", "HH:mm:ss");
        App.WaitForElement("SetFormatButton");
        App.Tap("SetFormatButton");
        App.WaitForElement("TimeEntry");
        App.ClearText("TimeEntry");
        App.EnterText("TimeEntry", "17:00:00");
        App.WaitForElement("SetTimeButton");
        App.Tap("SetTimeButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontFamilyAndFontSize_VerifyVisualState()
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
        // VerifyScreenshot();
    }

    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontFamilyAndFormat_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontFamilyDokdoButton");
        App.Tap("FontFamilyDokdoButton");
        App.WaitForElement("FormatEntry");
        App.ClearText("FormatEntry");
        App.EnterText("FormatEntry", "HH:mm:ss");
        App.WaitForElement("SetFormatButton");
        App.Tap("SetFormatButton");
        App.WaitForElement("TimeEntry");
        App.ClearText("TimeEntry");
        App.EnterText("TimeEntry", "17:00:00");
        App.WaitForElement("SetTimeButton");
        App.Tap("SetTimeButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
    [Test]
    [Category(UITestCategories.TimePicker)]
    public void TimePicker_SetFontSizeAndFormat_VerifyVisualState()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("FontSizeEntry");
        App.ClearText("FontSizeEntry");
        App.EnterText("FontSizeEntry", "20");
        App.WaitForElement("FormatEntry");
        App.ClearText("FormatEntry");
        App.EnterText("FormatEntry", "hh:mm:ss");
        App.WaitForElement("SetFormatButton");
        App.Tap("SetFormatButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        // VerifyScreenshot();
    }
}
