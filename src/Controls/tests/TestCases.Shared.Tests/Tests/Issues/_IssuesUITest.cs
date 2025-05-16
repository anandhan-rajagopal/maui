using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public abstract class _IssuesUITest : UITest
	{
#if ANDROID
		protected const string FlyoutIconAutomationId = "Open navigation drawer";
#else
		protected const string FlyoutIconAutomationId = "OK";
#endif
#if __IOS__ || WINDOWS
		protected const string BackButtonAutomationId = "Back";
#else
		protected const string BackButtonAutomationId = "Navigate up";
#endif

		public _IssuesUITest(TestDevice device) : base(device) { }

		protected override void FixtureSetup()
		{
			int retries = 0;
			while (true)
			{
				try
				{
					base.FixtureSetup();
#if ANDROID || MACCATALYST
					App.ToggleSystemAnimations(false);
#endif
					NavigateToIssue(Issue);
					break;
				}
				catch (Exception e)
				{
					TestContext.Error.WriteLine($">>>>> {DateTime.Now} The FixtureSetup threw an exception. Attempt {retries}/{SetupMaxRetries}.{Environment.NewLine}Exception details: {e}");
					if (retries++ < SetupMaxRetries)
					{
						App.Back();
#if ANDROID || MACCATALYST
						App.ToggleSystemAnimations(true);
#endif
						Reset();
					}
					else
					{
						throw;
					}
				}
			}
		}

		public abstract string Issue { get; }

		private void NavigateToIssue(string issue)
		{
			App.WaitForElement("GoToTestButton", issue);
			App.EnterText("SearchBar", issue);
			App.WaitForElement("GoToTestButton");
			App.Tap("GoToTestButton");
			var msg = "";
			try
			{
				var text = App.WaitForElement("SearchBar", timeout: TimeSpan.FromMilliseconds(10)).GetText();
				if (text == "Issue not found or Check the Issue description")
				{
					msg = $"The issue '{issue}' was not found. The search bar text is: {text}";
					throw new Exception($"The issue '{issue}' was not found. The search bar text is: {text}");
				}
			}
			catch (Exception e)
			{
				if (e.Message == msg)
				{
					throw;
				}
			}		
		}
	}
}