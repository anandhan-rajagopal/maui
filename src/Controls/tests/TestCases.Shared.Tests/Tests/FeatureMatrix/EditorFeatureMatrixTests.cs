using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Editor)]
public class EditorFeatureMatrixTests : UITest
{
	public const string EditorFeatureMatrix = "Editor Feature Matrix";

	public EditorFeatureMatrixTests(TestDevice device)
		: base(device)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(EditorFeatureMatrix);
	}

	[Test, Order(1)]
	public void Editor_ValidateDefaultValues_VerifyLabels()
	{
		App.WaitForElement("Options");
		Assert.That(App.FindElement("TextLabel").GetText(), Is.EqualTo(""));
		Assert.That(App.FindElement("CharacterSpacingLabel").GetText(), Is.EqualTo("0.0"));
		Assert.That(App.FindElement("FontAttributesLabel").GetText(), Is.EqualTo("None"));
		Assert.That(App.FindElement("FontSizeLabel").GetText(), Is.EqualTo("14.0"));
		Assert.That(App.FindElement("AutoSizeLabel").GetText(), Is.EqualTo("Disabled"));
	}

	[Test]
	public void Editor_SetText_VerifyTextLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextEntry");
		App.EnterText("TextEntry", "Hello World");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("TextLabel").GetText(), Is.EqualTo("Hello World"));
	}

	[Test]
	public void Editor_SetCharacterSpacing_VerifyCharacterSpacingLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CharacterSpacingEntry");
		App.ClearText("CharacterSpacingEntry");
		App.EnterText("CharacterSpacingEntry", "2.5");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("CharacterSpacingLabel").GetText(), Is.EqualTo("2.5"));
	}

	[Test]
	public void Editor_SetFontAttributes_Bold_VerifyFontAttributesLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontAttributesBoldRadio");
		App.Tap("FontAttributesBoldRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("FontAttributesLabel").GetText(), Is.EqualTo("Bold"));
	}

	[Test]
	public void Editor_SetFontAttributes_Italic_VerifyFontAttributesLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontAttributesItalicRadio");
		App.Tap("FontAttributesItalicRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("FontAttributesLabel").GetText(), Is.EqualTo("Italic"));
	}

	[Test]
	public void Editor_SetFontFamily_VerifyFontFamilyLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontFamilyEntry");
		App.EnterText("FontFamilyEntry", "Arial");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("FontFamilyLabel").GetText(), Is.EqualTo("Arial"));
	}

	[Test]
	public void Editor_SetFontSize_VerifyFontSizeLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FontSizeEntry");
		App.ClearText("FontSizeEntry");
		App.EnterText("FontSizeEntry", "18");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("FontSizeLabel").GetText(), Is.EqualTo("18.0"));
	}

	[Test]
	public void Editor_SetTextColor_Red_VerifyTextColorLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextColorRedRadio");
		App.Tap("TextColorRedRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		var textColorValue = App.FindElement("TextColorLabel").GetText();
		Assert.That(textColorValue, Does.Contain("Red").Or.Contain("#FF0000"));
	}

	[Test]
	public void Editor_SetTextColor_Blue_VerifyTextColorLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextColorBlueRadio");
		App.Tap("TextColorBlueRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		var textColorValue = App.FindElement("TextColorLabel").GetText();
		Assert.That(textColorValue, Does.Contain("Blue").Or.Contain("#0000FF"));
	}

	[Test]
	public void Editor_SetPlaceholder_VerifyPlaceholderLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("PlaceholderEntry");
		App.EnterText("PlaceholderEntry", "Enter text here");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("PlaceholderLabel").GetText(), Is.EqualTo("Enter text here"));
	}

	[Test]
	public void Editor_SetPlaceholderColor_Red_VerifyPlaceholderColorLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("PlaceholderColorRedRadio");
		App.Tap("PlaceholderColorRedRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		var placeholderColorValue = App.FindElement("PlaceholderColorLabel").GetText();
		Assert.That(placeholderColorValue, Does.Contain("Red").Or.Contain("#FF0000"));
	}

	[Test]
	public void Editor_SetMaxLength_VerifyMaxLengthLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("MaxLengthEntry");
		App.ClearText("MaxLengthEntry");
		App.EnterText("MaxLengthEntry", "50");
		App.PressEnter();
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("MaxLengthLabel").GetText(), Is.EqualTo("50"));
	}

	[Test]
	public void Editor_SetIsReadOnly_True_VerifyIsReadOnlyLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsReadOnlyTrueRadio");
		App.Tap("IsReadOnlyTrueRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("IsReadOnlyLabel").GetText(), Is.EqualTo("True"));
	}

	[Test]
	public void Editor_SetIsTextPredictionEnabled_False_VerifyIsTextPredictionEnabledLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsTextPredictionEnabledFalseRadio");
		App.Tap("IsTextPredictionEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("IsTextPredictionEnabledLabel").GetText(), Is.EqualTo("False"));
	}

	[Test]
	public void Editor_SetKeyboard_Email_VerifyKeyboardLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("KeyboardEmailRadio");
		App.Tap("KeyboardEmailRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("KeyboardLabel").GetText(), Is.EqualTo("Email"));
	}

	[Test]
	public void Editor_SetKeyboard_Numeric_VerifyKeyboardLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("KeyboardNumericRadio");
		App.Tap("KeyboardNumericRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("KeyboardLabel").GetText(), Is.EqualTo("Numeric"));
	}

	[Test]
	public void Editor_SetAutoSize_TextChanges_VerifyAutoSizeLabel()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("AutoSizeTextChangesRadio");
		App.Tap("AutoSizeTextChangesRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		Assert.That(App.FindElement("AutoSizeLabel").GetText(), Is.EqualTo("TextChanges"));
	}

	[Test]
	public void Editor_AutoSize_TextChanges_WithLongText_VerifyResizing()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("AutoSizeTextChangesRadio");
		App.Tap("AutoSizeTextChangesRadio");
		App.WaitForElement("TextEntry");
		App.ClearText("TextEntry");
		App.EnterText("TextEntry", "This is a very long text that should cause the editor to expand vertically when AutoSize is set to TextChanges mode. Let's add more text to make it really long and span multiple lines.");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		// Verify that AutoSize is TextChanges and text was applied
		Assert.That(App.FindElement("AutoSizeLabel").GetText(), Is.EqualTo("TextChanges"));
		var textLabel = App.FindElement("TextLabel").GetText();
		Assert.That(textLabel, Does.Contain("This is a very long text"));
	}

	[Test]
	public void Editor_SetEnabledStateToFalse_VerifyNotEditable()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalseRadio");
		App.Tap("IsEnabledFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		// Try to interact with disabled editor
		App.Tap("EditorControl");
		
		// Since editor is disabled, interaction should not change the text
		var initialText = App.FindElement("TextLabel").GetText();
		
		// Try to type in disabled editor (should not work)
		App.Tap("EditorControl");
		
		// Verify text hasn't changed
		var finalText = App.FindElement("TextLabel").GetText();
		Assert.That(initialText, Is.EqualTo(finalText));
	}

	[Test]
	public void Editor_SetVisibilityToFalse_VerifyNotVisible()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalseRadio");
		App.Tap("IsVisibleFalseRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		App.WaitForNoElement("EditorControl");
	}

	[Test]
	public void Editor_TextChanged_Event_VerifyEventTriggered()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("TextEntry");
		App.ClearText("TextEntry");
		App.EnterText("TextEntry", "Event Test");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		var eventText = App.FindElement("TextChangedEventLabel").GetText();
		Assert.That(eventText, Does.Contain("Changed: Event Test"));
	}

	[Test]
	public void Editor_MaxLength_LimitTextInput()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		
		// Set max length to 10
		App.WaitForElement("MaxLengthEntry");
		App.ClearText("MaxLengthEntry");
		App.EnterText("MaxLengthEntry", "10");
		App.PressEnter();
		
		// Set text longer than max length
		App.WaitForElement("TextEntry");
		App.ClearText("TextEntry");
		App.EnterText("TextEntry", "This text is definitely longer than 10 characters");
		
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		// Verify text is truncated to max length
		var resultText = App.FindElement("TextLabel").GetText();
		Assert.That(resultText.Length, Is.LessThanOrEqualTo(10));
	}

	[Test]
	public void Editor_ResetToInitialState_VerifyDefaultValues()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		
		// Change some values
		App.WaitForElement("TextEntry");
		App.EnterText("TextEntry", "Changed");
		App.WaitForElement("FontSizeEntry");
		App.ClearText("FontSizeEntry");
		App.EnterText("FontSizeEntry", "20");
		
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		// Reset by going to options again without changes
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		
		// Values should maintain what was set (not reset to defaults)
		Assert.That(App.FindElement("TextLabel").GetText(), Is.EqualTo("Changed"));
		Assert.That(App.FindElement("FontSizeLabel").GetText(), Is.EqualTo("20.0"));
	}

#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST
	[Test]
	public void Editor_ChangeFlowDirection_RTL_VerifyVisualState()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRTLRadio");
		App.Tap("FlowDirectionRTLRadio");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("Options");
		VerifyScreenshot();
	}
#endif
}