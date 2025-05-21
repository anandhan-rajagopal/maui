using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
using System;
using System.Threading;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
    [TestFixture]
    public class Issue4807 : _IssuesUITest
    {
        public override string Issue => "HTML5 video not working on MAUI WebView";

        public Issue4807(TestDevice testDevice) : base(testDevice)
        {
        }

        [Test]
        [Category(UITestCategories.WebView)]
        [Order(1)]
        public void WebViewHTML5VideoInitialLoad()
        {
            // Wait for the WebView to load
            App.WaitForElement("videoWebView", timeout: TimeSpan.FromSeconds(30));
            
            // Wait a bit for the navigation to complete
            Thread.Sleep(2000);
            
            // Verify the page is visible by checking for the buttons
            App.WaitForElement("playButton");
            App.WaitForElement("checkStatusButton");
            
            // Verify we can see the navigation status label
            App.WaitForElement("navigationStatusLabel");
            
            // Take a screenshot to verify the page loaded
            VerifyScreenshot("InitialLoad");
        }

        [Test]
        [Category(UITestCategories.WebView)]
        [Order(2)]
        public void WebViewHTML5VideoPlayFunctionality()
        {
            // Wait for the WebView and button to be present
            App.WaitForElement("videoWebView", timeout: TimeSpan.FromSeconds(30));
            App.WaitForElement("playButton");
            
            // Try to play the video by clicking the play button
            App.Tap("playButton");
            
            // Wait a bit for the video to start playing
            Thread.Sleep(3000);
            
            // Check the status label is updated
            App.WaitForElement("statusLabel");
            
            // Now check the video status
            App.Tap("checkStatusButton");
            
            // Wait for status update
            Thread.Sleep(1000);
            
            // Check the updated status is visible
            App.WaitForElement("statusLabel");
            
            // Take a screenshot to verify the state after playing
            VerifyScreenshot("AfterPlay");
        }

        [Test]
        [Category(UITestCategories.WebView)]
        [Order(3)]
        public void WebViewHTML5VideoNoErrors()
        {
            // This tests that the WebView doesn't crash or show errors
            // which was one of the issues in the original bug report
            
            App.WaitForElement("videoWebView");
            App.WaitForElement("playButton");
            App.WaitForElement("checkStatusButton");
            
            // Try to play the video
            App.Tap("playButton");
            
            // Wait for video to start
            Thread.Sleep(2000);
            
            // Check status
            App.Tap("checkStatusButton");
            
            // Wait for status update
            Thread.Sleep(1000);
            
            // Check the status label is visible
            App.WaitForElement("statusLabel");
            
            // Take a final screenshot showing the video should be playing
            VerifyScreenshot("NoErrors");
        }

#if __IOS__
        [Test]
        [Category(UITestCategories.WebView)]
        [Order(4)]
        public void WebViewHTML5VideoConfiguredCorrectlyOniOS()
        {
            // This test is specific to iOS, as the issue was primarily on that platform
            // The fix in PR #11075 made changes to the WKWebView configuration to enable HTML5 video playback
            
            App.WaitForElement("videoWebView");
            App.WaitForElement("playButton");
            App.WaitForElement("checkStatusButton");
            
            // Try to play the video
            App.Tap("playButton");
            
            // Wait for video to start
            Thread.Sleep(3000);
            
            // Check status
            App.Tap("checkStatusButton");
            
            // Wait for status update
            Thread.Sleep(1000);
            
            // Make sure UI is still responsive
            App.WaitForElement("statusLabel");
            
            // On iOS, with the fix in PR #11075, the video should play inline
            // Before the fix, this would not work correctly
            
            // Take a screenshot for visual verification
            VerifyScreenshot("iOS-WebView-Video");
        }
#endif

#if ANDROID
        [Test]
        [Category(UITestCategories.WebView)]
        [Order(5)]
        public void WebViewHTML5VideoWorksOnAndroid()
        {
            // Android has always supported HTML5 video in WebView
            // This test verifies that the functionality still works correctly
            
            App.WaitForElement("videoWebView");
            App.WaitForElement("playButton");
            App.WaitForElement("checkStatusButton");
            
            // Try to play the video
            App.Tap("playButton");
            
            // Wait for video to start
            Thread.Sleep(3000);
            
            // Check status
            App.Tap("checkStatusButton");
            
            // Wait for status update
            Thread.Sleep(1000);
            
            // Make sure UI is still responsive
            App.WaitForElement("statusLabel");
            
            // Take a screenshot for comparison with iOS
            VerifyScreenshot("Android-WebView-Video");
        }
#endif
    }
}
