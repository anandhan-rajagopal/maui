using System;
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
    public class SwitchFeatureTests : UITest
    {
        public const string SwitchFeatureMatrix = "Switch Feature Matrix";

        public SwitchFeatureTests(TestDevice device)
            : base(device)
        {
        }

        protected override void FixtureSetup()
        {
            base.FixtureSetup();
            App.NavigateToGallery(SwitchFeatureMatrix);
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetToggledAndOnColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("OnColorRedButton");
            App.Tap("OnColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetToggledAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("ThumbColorRedButton");
            App.Tap("ThumbColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetOnColorAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("OnColorRedButton");
            App.Tap("OnColorRedButton");
            App.WaitForElement("ThumbColorGreenButton");
            App.Tap("ThumbColorGreenButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetToggledAndFlowDirection_RTL_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetBackgroundColorAndOnColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("BackgroundColorBlueButton");
            App.Tap("BackgroundColorBlueButton");
            App.WaitForElement("OnColorGreenButton");
            App.Tap("OnColorGreenButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetBackgroundColorAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("BackgroundColorBlueButton");
            App.Tap("BackgroundColorBlueButton");
            App.WaitForElement("ThumbColorGreenButton");
            App.Tap("ThumbColorGreenButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetFlowDirectionAndOnColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("OnColorRedButton");
            App.Tap("OnColorRedButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetToggledAndBackgroundColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("BackgroundColorOrangeButton");
            App.Tap("BackgroundColorOrangeButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetFlowDirectionAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("ThumbColorRedButton");
            App.Tap("ThumbColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetBackgroundColorAndFlowDirection_RTL_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("BackgroundColorBlueButton");
            App.Tap("BackgroundColorBlueButton");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetEnabledAndToggled_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetEnabledAndBackgroundColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("BackgroundColorBlueButton");
            App.Tap("BackgroundColorBlueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetEnabledAndOnColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("OnColorRedButton");
            App.Tap("OnColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetEnabledAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("ThumbColorRedButton");
            App.Tap("ThumbColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetEnabledAndFlowDirection_RTL_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndToggled_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("IsToggledTrueButton");
            App.Tap("IsToggledTrueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndBackgroundColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("BackgroundColorBlueButton");
            App.Tap("BackgroundColorBlueButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndOnColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("OnColorRedButton");
            App.Tap("OnColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndThumbColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("ThumbColorRedButton");
            App.Tap("ThumbColorRedButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndFlowDirection_RTL_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("FlowDirectionRightToLeftButton");
            App.Tap("FlowDirectionRightToLeftButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Switch)]
        public void Switch_SetVisibleAndEnabled_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseButton");
            App.Tap("IsVisibleFalseButton");
            App.WaitForElement("IsEnabledFalseButton");
            App.Tap("IsEnabledFalseButton");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            Task.Delay(4000).Wait();
            // VerifyScreenshot();
        }
    }
}
