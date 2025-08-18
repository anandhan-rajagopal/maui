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
		public void BindableUpdatesFromBackgroundThreadDoNotCrashAndPropagate()
		{
            App.WaitForElement("Success", timeout: TimeSpan.FromSeconds(3));
		}
	}
}
