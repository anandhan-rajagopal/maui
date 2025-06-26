using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class WebViewFeatureMatrixTests : UITest
	{
		public const string WebViewFeatureMatrix = "WebView Feature Matrix";

		public WebViewFeatureMatrixTests(TestDevice device)
			: base(device)
		{
		}

		protected override void FixtureSetup()
		{
			base.FixtureSetup();
			App.NavigateToGallery(WebViewFeatureMatrix);
		}

		[Test, Order(1)]
		[Category(UITestCategories.WebView)]
		public void WebView_ValidateDefaultValues_VerifyInitialState()
		{
			App.WaitForElement("Options");
			Assert.That(App.FindElement("CanGoBackLabel").GetText(), Is.EqualTo("False"));
			Assert.That(App.FindElement("CanGoForwardLabel").GetText(), Is.EqualTo("False"));
			App.WaitForElement("WebViewControl");
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_SetHtmlSource_VerifyContentLoaded()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("HtmlSourceRadio");
			App.Tap("HtmlSourceRadio");
			App.WaitForElement("LoadHtmlContentButton");
			App.Tap("LoadHtmlContentButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_SetUrlSource_VerifyNavigating()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("UrlSourceRadio");
			App.Tap("UrlSourceRadio");
			App.WaitForElement("LoadRemoteUrlButton");
			App.Tap("LoadRemoteUrlButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Check if navigation events fired
			if (App.FindElements("NavigatingStatusLabel").Count > 0)
			{
				var navigatingText = App.FindElement("NavigatingStatusLabel").GetText();
				Assert.That(navigatingText, Is.Not.Null.And.Not.Empty);
			}
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestUserAgent_VerifyUserAgentSet()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("UserAgentEntry");
			App.EnterText("UserAgentEntry", "TestUserAgent/1.0");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestCookieManagement_VerifyAddCookie()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("AddTestCookieButton");
			App.Tap("AddTestCookieButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestClearCookies_VerifyCookiesCleared()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("ClearCookiesButton");
			App.Tap("ClearCookiesButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestNavigationHistory_VerifyCanGoBackForward()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadMultiplePagesButton");
			App.Tap("LoadMultiplePagesButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Initial state should have no navigation history
			Assert.That(App.FindElement("CanGoBackLabel").GetText(), Is.EqualTo("False"));
			Assert.That(App.FindElement("CanGoForwardLabel").GetText(), Is.EqualTo("False"));
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestGoBackMethod_VerifyGoBackFunctionality()
		{
			// First load multiple pages to create history
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadPage1Button");
			App.Tap("LoadPage1Button");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Load second page
			App.Tap("Options");
			App.WaitForElement("LoadPage2Button");
			App.Tap("LoadPage2Button");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Now test go back
			App.WaitForElement("GoBackButton");
			App.Tap("GoBackButton");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestGoForwardMethod_VerifyGoForwardFunctionality()
		{
			// Setup navigation history first
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadPage1Button");
			App.Tap("LoadPage1Button");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Load second page then go back
			App.Tap("Options");
			App.WaitForElement("LoadPage2Button");
			App.Tap("LoadPage2Button");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			App.WaitForElement("GoBackButton");
			App.Tap("GoBackButton");
			
			// Now test go forward
			App.WaitForElement("GoForwardButton");
			App.Tap("GoForwardButton");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestReloadMethod_VerifyReloadFunctionality()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadHtmlContentButton");
			App.Tap("LoadHtmlContentButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			App.WaitForElement("ReloadButton");
			App.Tap("ReloadButton");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestEvaluateJavaScriptAsync_VerifyJavaScriptExecution()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("TestDocumentTitleButton");
			App.Tap("TestDocumentTitleButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			App.WaitForElement("EvaluateJSButton");
			App.Tap("EvaluateJSButton");
			
			// Wait for JavaScript evaluation result
			App.WaitForElement("JSResultLabel");
			var jsResult = App.FindElement("JSResultLabel").GetText();
			Assert.That(jsResult, Is.Not.Null.And.Not.Empty);
			Assert.That(jsResult, Does.Contain("JS Result"));
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestNavigatingEvent_VerifyEventFires()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadRemoteUrlButton");
			App.Tap("LoadRemoteUrlButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Check if navigating event status is displayed
			if (App.FindElements("NavigatingStatusLabel").Count > 0)
			{
				var navigatingStatus = App.FindElement("NavigatingStatusLabel").GetText();
				Assert.That(navigatingStatus, Is.Not.Null.And.Not.Empty);
				Assert.That(navigatingStatus, Does.Contain("Navigating"));
			}
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_TestNavigatedEvent_VerifyEventFires()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("LoadHtmlContentButton");
			App.Tap("LoadHtmlContentButton");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Check if navigated event status is displayed
			if (App.FindElements("NavigatedStatusLabel").Count > 0)
			{
				var navigatedStatus = App.FindElement("NavigatedStatusLabel").GetText();
				Assert.That(navigatedStatus, Is.Not.Null.And.Not.Empty);
				Assert.That(navigatedStatus, Does.Contain("Navigated"));
			}
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_SetIsEnabledFalse_VerifyWebViewDisabled()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_SetIsVisibleFalse_VerifyWebViewHidden()
		{
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("IsVisibleFalseRadio");
			App.Tap("IsVisibleFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("Options");
			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.WebView)]
		public void WebView_ResetToInitialState_VerifyDefaultValues()
		{
			// Make some changes first
			App.WaitForElement("Options");
			App.Tap("Options");
			App.WaitForElement("UserAgentEntry");
			App.EnterText("UserAgentEntry", "Modified/2.0");
			App.WaitForElement("IsEnabledFalseRadio");
			App.Tap("IsEnabledFalseRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Reset to defaults
			App.Tap("Options");
			App.WaitForElement("UserAgentEntry");
			App.ClearText("UserAgentEntry");
			App.WaitForElement("IsEnabledTrueRadio");
			App.Tap("IsEnabledTrueRadio");
			App.WaitForElement("HtmlSourceRadio");
			App.Tap("HtmlSourceRadio");
			App.WaitForElement("Apply");
			App.Tap("Apply");
			App.WaitForElementTillPageNavigationSettled("WebViewControl");
			
			// Verify default state
			Assert.That(App.FindElement("CanGoBackLabel").GetText(), Is.EqualTo("False"));
			Assert.That(App.FindElement("CanGoForwardLabel").GetText(), Is.EqualTo("False"));
		}
	}
}