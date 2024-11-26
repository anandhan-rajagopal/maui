#if TEST_FAILS_ON_CATALYST // TouchAndHold is not working on catalyst
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue8291 : _IssuesUITest
{
	public Issue8291(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Android] Editor - Text selection menu does not appear when selecting text on an editor placed within a ScrollView";

	[Test]
	[Category(UITestCategories.Editor)]
	public void ContextMenuShowsUpWhenPressAndHoldTextOnEditorAndEntryField()
	{
		App.WaitForElement("PressEditor");
		App.LongPress("PressEditor");
		TestForPopup();
		App.Tap("PressEntry");
		App.LongPress("PressEntry");
		TestForPopup();
	}

	void TestForPopup()
	{
		var result = App.QueryUntilPresent(() =>
		{
			return "Paste"
					.Union("Share")
					.Union("Copy")
					.Union("Cut")
					.Union("Select All")
					.ToArray();
		});

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Length, Is.GreaterThan(0));
	}
}
#endif