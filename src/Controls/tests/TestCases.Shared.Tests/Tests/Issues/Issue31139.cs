using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue31139 : _IssuesUITest
	{
		public Issue31139(TestDevice device) : base(device) { }

		public override string Issue => "Issue31139";

		[Test]
		[Category(UITestCategories.Dispatcher)]
		[Category(UITestCategories.Page)]
		public void BindableUpdatesFromBackgroundThreadDoNotCrashAndPropagate()
		{
			// Navigate happens in FixtureSetup
			App.WaitForElement("StartButton");
			App.Tap("StartButton");

			// Wait for status to become Updated indicating background thread updates processed
			App.WaitForElement("UpdatedLabel");
			var text = App.FindElement("UpdatedLabel").GetText();
			Assert.That(text, Does.Contain("Updated"));

			// And ensure Picker has items populated
			App.WaitForElement("Picker");
		}
	}
}
