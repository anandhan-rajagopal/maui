using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Editor)]
public class EditorFeatureTests : UITest
{
	public const string EditorFeatureMatrix = "Editor Feature Matrix";

#if IOS
	private const int CropBottomValue = 1550;
#elif ANDROID
	private const int CropBottomValue = 1150;
#elif WINDOWS
	private const int CropBottomValue = 400;
#else
	private const int CropBottomValue = 360;		
#endif

	public EditorFeatureTests(TestDevice device)
		: base(device)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(EditorFeatureMatrix);
	}

	[Test, Order(0)]
	public void VerifyInitialEventStates()
	{
		App.WaitForElement("TestEditor");
		Assert.That(App.WaitForElement("TextChangedLabel").GetText(), Is.EqualTo("TextChanged: Old='', New='Test Editor'"));
	}

	[Test, Order(2)]
	public void VerifyEditorTextChangedEvent()
	{
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.EnterText("TestEditor", "New Text");

#if !ANDROID
		Assert.That(App.WaitForElement("TextChangedLabel").GetText(), Is.EqualTo("TextChanged: Old='New Tex', New='New Text'"));
#else
		Assert.That(App.WaitForElement("TextChangedLabel").GetText(), Is.EqualTo("TextChanged: Old='', New='New Text'"));
#endif
	}

	[Test]
	public void VerifyTextWhenAlingnedHorizontally()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyTextEditorWhenSetAsReadOnly()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ReadOnlyTrue");
		App.Tap("ReadOnlyTrue");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		// On Android, using App.EnterText in UI tests (e.g., with Appium UITest) can programmatically enter text into an Editor control even if its IsReadOnly property is set to true.
		App.EnterText("TestEditor", "123");
		Assert.That(App.WaitForElement("TestEditor").GetText(), Is.EqualTo("Test Editor"));
	}

	[Test]
	public void VerifyTextWhenFontFamilySetValue()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontFamily");
		App.EnterText("FontFamily", "MontserratBold");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyTextWhenCharacterSpacingSetValues()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CharacterSpacing");
		App.ClearText("CharacterSpacing");
		App.EnterText("CharacterSpacing", "5");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyTextWhenMaxLengthSetValue()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextEntryChanged");
		App.ClearText("TextEntryChanged");
		App.EnterText("TextEntryChanged", "Test Entered Set MaxLenght");
		App.WaitForElement("MaxLength");
		App.ClearText("MaxLength");
		App.EnterText("MaxLength", "6");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		Assert.That(App.WaitForElement("TestEditor").GetText(), Is.EqualTo("Test E"));
	}

	[Test]
	public void VerifyTextWhenTextColorSetCorrectly()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextColorRed");
		App.Tap("TextColorRed");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyTextWhenFontSizeSetCorrectly()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontSizeEntry");
		App.ClearText("FontSizeEntry");
		App.EnterText("FontSizeEntry", "20");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyEditorControlWhenIsEnabledTrueOrFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.EnterText("TestEditor", "123");
		Assert.That(App.WaitForElement("TestEditor").GetText(), Is.EqualTo("123"));
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("EnabledFalse");
		App.Tap("EnabledFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.EnterText("TestEditor", "123");
		Assert.That(App.WaitForElement("TestEditor").GetText(), Is.EqualTo("Test Editor"));
	}

	[Test]
	public void VerifyEditorControlWhenIsVisibleTrueOrFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("VisibleFalse");
		App.Tap("VisibleFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("TestEditor");
	}

	[Test]
	public void VerifyEditorControlWhenFlowDirectionSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRightToLeft");
		App.Tap("FlowDirectionRightToLeft");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyPlaceholderWhenFlowDirectionSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRightToLeft");
		App.Tap("FlowDirectionRightToLeft");
		App.WaitForElement("TextEntryChanged");
		App.ClearText("TextEntryChanged");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyEditorControlWhenPlaceholderTextSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("PlaceholderText");
		App.ClearText("PlaceholderText");
		App.EnterText("PlaceholderText", "Enter your text");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.DismissKeyboard();
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyEditorControlWhenPlaceholderColorSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("PlaceholderColorRed");
		App.Tap("PlaceholderColorRed");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.DismissKeyboard();
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyEditorWhenTextChanged()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextEntryChanged");
		App.ClearText("TextEntryChanged");
		App.EnterText("TextEntryChanged", "New Text Changed");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		Assert.That(App.WaitForElement("TestEditor").GetText(), Is.EqualTo("New Text Changed"));
	}

	[Test]
	public void VerifyTextWhenFontAttributesSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontAttributesBold");
		App.Tap("FontAttributesBold");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_WINDOWS //keybord type is not supported on Windows and Maccatalyst platforms
	[Test]
	public void VerifyTextWhenKeyboardTypeSet()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Numeric");
		App.Tap("Numeric");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.Tap("TestEditor");
		VerifyScreenshotWithKeyboardHandling();
	}
#endif

	[Test]
	public void VerifyAutoSizeDisabled()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("AutoSizeDisabledRadio");
		App.Tap("AutoSizeDisabledRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	[Test]
	public void VerifyAutoSizeTextChanges()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("AutoSizeTextChangesRadio");
		App.Tap("AutoSizeTextChangesRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.EnterText("TestEditor", "This is a longer text that should cause the editor to expand automatically with AutoSize set to TextChanges. Let's add more text to see the auto-sizing behavior in action.");
		App.DismissKeyboard();
		VerifyScreenshot(cropBottom: CropBottomValue);
	}
	
	[Test]
	public void VerifyAutoSizeTextChangesWithShorterText()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("AutoSizeTextChangesRadio");
		App.Tap("AutoSizeTextChangesRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("TestEditor");
		App.ClearText("TestEditor");
		App.EnterText("TestEditor", "Short");
		App.DismissKeyboard();
		VerifyScreenshot(cropBottom: CropBottomValue);
	}

	/// <summary>
	/// Helper method to handle keyboard visibility and take a screenshot with appropriate cropping
	/// </summary>
	/// <param name="screenshotName">Optional name for the screenshot</param>
	private void VerifyScreenshotWithKeyboardHandling(string? screenshotName = null)
	{
#if ANDROID // Skip keyboard on Android to address CI flakiness, Keyboard is not needed validation.
		if (App.IsKeyboardShown())
			App.DismissKeyboard();
#endif

		// Using cropping instead of DismissKeyboard() on iOS to maintain focus during testing
		if (string.IsNullOrEmpty(screenshotName))
			VerifyScreenshot(cropBottom: CropBottomValue);
		else
			VerifyScreenshot(screenshotName, cropBottom: CropBottomValue);
	}

	/// <summary>
	/// Helper method to handle keyboard visibility and set exception if screenshot verification fails
	/// </summary>
	/// <param name="exception">Reference to exception variable</param>
	/// <param name="screenshotName">Name for the screenshot</param>
	private void VerifyScreenshotWithKeyboardHandlingOrSetException(ref Exception? exception, string screenshotName)
	{
#if ANDROID
		if (App.IsKeyboardShown())
			App.DismissKeyboard();
#endif
		VerifyScreenshotOrSetException(ref exception, screenshotName, cropBottom: CropBottomValue);

	}
}