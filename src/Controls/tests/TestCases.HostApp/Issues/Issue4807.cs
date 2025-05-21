using Microsoft.Maui.Controls;
using System;

namespace Maui.Controls.Sample.Issues
{
    [Issue(IssueTracker.Github, 4807, "HTML5 video not working on MAUI WebView", PlatformAffected.iOS)]
    public class Issue4807 : TestContentPage
    {
        protected override void Init()
        {
            var layout = new VerticalStackLayout
            {
                Spacing = 10,
                Padding = new Thickness(20),
            };

            var descriptionLabel = new Label
            {
                Text = "This test verifies that HTML5 video works properly in WebView. " +
                       "If the video plays and shows a green indicator, the test passes.",
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };
            
            // Use HTML from the local resource file
            var htmlSource = new UrlWebViewSource
            {
                Url = "file:///issue4807_video.html"
            };

            var webView = new WebView
            {
                Source = htmlSource,
                HeightRequest = 400,
                AutomationId = "videoWebView"
            };
            
            var navigationStatusLabel = new Label
            {
                Text = "Waiting for navigation...",
                AutomationId = "navigationStatusLabel",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 12
            };
            
            // Set up event to monitor WebView navigation
            webView.Navigated += (s, e) => 
            {
                navigationStatusLabel.Text = $"Navigated to: {e.Url}";
            };

            var statusLabel = new Label
            {
                Text = "Waiting for video to start...",
                AutomationId = "statusLabel",
                HorizontalOptions = LayoutOptions.Center
            };

            var playButton = new Button
            {
                Text = "Play Video",
                AutomationId = "playButton", 
                HorizontalOptions = LayoutOptions.Center
            };
            
            var checkStatusButton = new Button
            {
                Text = "Check Video Status",
                AutomationId = "checkStatusButton",
                HorizontalOptions = LayoutOptions.Center
            };

            playButton.Clicked += async (s, e) =>
            {
                await webView.EvaluateJavaScriptAsync("document.getElementById('test-video').play();");
                statusLabel.Text = "Requested video to play";
            };
            
            checkStatusButton.Clicked += async (s, e) =>
            {
                // Get video state from the webview
                var result = await webView.EvaluateJavaScriptAsync(
                    @"(function() {
                        var video = document.getElementById('test-video');
                        if (!video) return 'Video element not found';
                        return video.paused ? 'paused' : 'playing';
                    })()");
                
                statusLabel.Text = $"Video status: {result}";
            };

            layout.Add(descriptionLabel);
            layout.Add(webView);
            layout.Add(navigationStatusLabel);
            layout.Add(statusLabel);
            layout.Add(playButton);
            layout.Add(checkStatusButton);

            Content = layout;
        }
    }
}
