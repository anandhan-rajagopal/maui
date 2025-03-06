using System;
using System.Collections.ObjectModel;
namespace Microsoft.Maui.TestCases.Tests.Issues
{
	[Issue(IssueTracker.None,000, "Image Leak Test")]
    public class ImageLeakTestPage : ContentPage
    {
        private WeakReference handlerReference;
        private WeakReference platformViewReference;
        private Image testImage;

        public ImageLeakTestPage()
        {
            Title = "Image Leak Test";

            var layout = new VerticalStackLayout
            {
                Padding = new Thickness(20),
                Spacing = 20
            };

            testImage = new Image
            {
                Source = "red.png",
                BackgroundColor = Colors.Black,
                HeightRequest = 200,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                AutomationId = "LeakTestImage"
            };

            var testButton = new Button
            {
                Text = "Test Image Load",
                Command = new Command(OnTestButtonClicked),
                AutomationId = "TestButton"
            };

            var backButton = new Button
            {
                Text = "Go Back",
                Command = new Command(async () => await Navigation.PopAsync()),
                AutomationId = "BackButton"
            };

            layout.Add(new Label { Text = "Image Leak Test Page", FontSize = 20, FontAttributes = FontAttributes.Bold });
            layout.Add(testImage);
            layout.Add(testButton);
            layout.Add(backButton);

            Content = layout;
        }

        private void OnTestButtonClicked()
        {
            handlerReference = new WeakReference(testImage.Handler);
            platformViewReference = new WeakReference(testImage.Handler?.PlatformView);
        }

        // Backdoor method for UI tests
        public void EnsureImageLoaded(string automationId)
        {
            if (testImage != null)
            {
                handlerReference = new WeakReference(testImage.Handler);
                platformViewReference = new WeakReference(testImage.Handler?.PlatformView);
            }
        }

        // Backdoor method for UI tests
        public void ForceGC()
        {
            testImage = null; // Release our reference
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        // Backdoor method for UI tests
        public bool CheckImageReferencesCollected()
        {
            bool handlerCollected = handlerReference != null && !handlerReference.IsAlive;
            bool platformViewCollected = platformViewReference != null && !platformViewReference.IsAlive;
            
            return handlerCollected && platformViewCollected;
        }
    }
}