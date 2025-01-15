﻿using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue12134 : _IssuesUITest
	{
		public Issue12134(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "[iOS] WkWebView does not handle cookies consistently";

		[Test]
		[Category(UITestCategories.WebView)]
		[Category(UITestCategories.Compatibility)]
	 
		public void CookiesCorrectlyLoadWithMultipleWebViews()
		{
			for (int i = 0; i < 10; i++)
			{
				App.WaitForElement("Success", $"Failied on: {i}");
				App.Tap("LoadNewWebView");
			}
		}
		public override void TestSetup()
		{
			base.TestSetup();

			try
			{
				App.WaitForElement("NoInternetAccessLabel", timeout: TimeSpan.FromSeconds(1));
				Assert.Inconclusive("This device doesn't have internet access");
			}
			catch (TimeoutException)
			{
				// Element not found within timeout, assume internet is available
				// Continue with the test
			}
		}
	}
}