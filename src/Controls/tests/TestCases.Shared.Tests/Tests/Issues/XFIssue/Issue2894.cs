using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2894 : _IssuesUITest
{
	const string kGesture1 = "Sentence 1: ";
	const string kGesture2 = "Sentence 2: ";
	const string kLabelAutomationId = "kLabelAutomationId";

	public Issue2894(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Gesture Recognizers added to Span after it's been set to FormattedText don't work and can cause an NRE";

	[Test]
	[Category(UITestCategories.Gestures)]
	public void VariousSpanGesturePermutation()
	{
		App.WaitForElement($"{kGesture1}0");
		App.WaitForElement($"{kGesture2}0");
		var labelId = App.WaitForElement(kLabelAutomationId);
		var target = labelId.GetRect();

		for (int i = 1; i < 5; i++)
		{
			App.Tap($"TestSpan{i}");
			App.WaitForElement(kLabelAutomationId);
#if MACCATALYST
            App.ClickCoordinates(target.X + 5, target.Y + 5);
#else
			App.TapCoordinates(target.X + 5, target.Y + 5);
#endif

#if ANDROID
            App.TapCoordinates(target.X + target.Width / 2, target.Y + 2);
#elif MACCATALYST
            App.ClickCoordinates(target.X + target.Width - 10, target.Y + 2);
#else
			App.TapCoordinates(target.X + target.Width - 10, target.Y + 2);
#endif
		}

		App.Tap($"TestSpan5");
#if MACCATALYST
        App.ClickCoordinates(target.X + 5, target.Y + 5);
#else
		App.TapCoordinates(target.X + 5, target.Y + 5);
#endif

#if ANDROID
            App.TapCoordinates(target.X + target.Width /2, target.Y + 2);
#elif MACCATALYST
            App.ClickCoordinates(target.X + target.Width - 10, target.Y + 2);
#else
		App.TapCoordinates(target.X + target.Width - 10, target.Y + 2);
#endif
		App.WaitForElement($"{kGesture1}4");
		App.WaitForElement($"{kGesture2}4");
	}
}