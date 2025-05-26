using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
    public class StepperFeatureTests : UITest
    {
        public const string StepperFeatureMatrix = "Stepper Feature Matrix";

        public StepperFeatureTests(TestDevice device)
            : base(device)
        {
        }

        protected override void FixtureSetup()
        {
            base.FixtureSetup();
            App.NavigateToGallery(StepperFeatureMatrix);
        }

        [Test, Order(1)]
        [Category(UITestCategories.Stepper)]
        public void Stepper_ValidateDefaultValues_VerifyLabels()
        {
            App.WaitForElement("Options");
            Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("0.00"));
            Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("10.00"));
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetMinimumValue_VerifyMinimumLabel()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.EnterText("MinimumEntry", "2");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("2.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetMaximumValue_VerifyMaximumLabel()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaximumEntry");
            App.EnterText("MaximumEntry", "20");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("20.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetValueWithinRange_VerifyValueLabel()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ValueEntry");
            App.EnterText("ValueEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetIncrementValue_VerifyIncrement()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IncrementEntry");
            App.EnterText("IncrementEntry", "2");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            App.IncreaseStepper("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("2.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetValueExceedsMaximum()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MaximumEntry");
            App.ClearText("MaximumEntry");
            App.EnterText("MaximumEntry", "100");
            App.PressEnter();
            App.ClearText("ValueEntry");
            App.EnterText("ValueEntry", "200");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("100.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetValueBelowMinimum()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.ClearText("MinimumEntry");
            App.EnterText("MinimumEntry", "10");
            App.PressEnter();
            App.ClearText("ValueEntry");
            App.EnterText("ValueEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("10.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_MinimumExceedsMaximum_SetsMinimumToMaximum()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.ClearText("MinimumEntry");
            App.EnterText("MinimumEntry", "50");
            App.PressEnter();
            App.ClearText("MaximumEntry");
            App.EnterText("MaximumEntry", "25");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("50.00"));
            Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("50.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetEnabledStateToFalse_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsEnabledFalseRadio");
            App.Tap("IsEnabledFalseRadio");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            App.IncreaseStepper("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetVisibilityToFalse_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IsVisibleFalseRadio");
            App.Tap("IsVisibleFalseRadio");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("Options");
            App.WaitForNoElement("StepperControl");
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetBackgroundColor_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("BackgroundColorRedRadio");
            App.Tap("BackgroundColorRedRadio");
            //App.Tap("Red");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_ChangeFlowDirection_RTL_VerifyVisualState()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("FlowDirectionRTLRadio");
            App.Tap("FlowDirectionRTLRadio");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_AtMinimumValue_DecrementButtonDisabled()
        {
            App.WaitForElement("Options");
            App.Tap("Options");

            App.WaitForElement("MinimumEntry");
            App.ClearText("MinimumEntry");
            App.EnterText("MinimumEntry", "10");
            App.PressEnter();

            App.WaitForElement("ValueEntry");
            App.ClearText("ValueEntry");
            App.EnterText("ValueEntry", "10");
            App.PressEnter();

            App.WaitForElement("Apply");
            App.Tap("Apply");

            App.WaitForElementTillPageNavigationSettled("StepperControl");

            var currentValue = App.FindElement("ValueLabel").GetText();
            Assert.That(currentValue, Is.EqualTo("10.00"));

            App.DecreaseStepper("StepperControl");

            var newValue = App.FindElement("ValueLabel").GetText();
            Assert.That(newValue, Is.EqualTo("10.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_AtMaximumValue_IncrementButtonDisabled()
        {
            App.WaitForElement("Options");
            App.Tap("Options");

            App.WaitForElement("MaximumEntry");
            App.EnterText("MaximumEntry", "10");
            App.PressEnter();

            App.WaitForElement("ValueEntry");
            App.EnterText("ValueEntry", "10");
            App.PressEnter();

            App.WaitForElement("Apply");
            App.Tap("Apply");

            App.WaitForElementTillPageNavigationSettled("StepperControl");

            var currentValue = App.FindElement("ValueLabel").GetText();
            Assert.That(currentValue, Is.EqualTo("10.00"));

            App.IncreaseStepper("StepperControl");

            var newValue = App.FindElement("ValueLabel").GetText();
            Assert.That(newValue, Is.EqualTo("10.00"));
        }

        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_SetIncrementAndVerifyValueChange()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("IncrementEntry");
            App.EnterText("IncrementEntry", "5");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            App.IncreaseStepper("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("5.00"));
            App.IncreaseStepper("StepperControl");
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("10.00"));
        }


        [Test]
        [Category(UITestCategories.Stepper)]
        public void Stepper_ResetToInitialState_VerifyDefaultValues()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("MinimumEntry");
            App.EnterText("MinimumEntry", "10");
            App.PressEnter();
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            App.Tap("Options");
            App.WaitForElement("Apply");
            App.Tap("Apply");
            App.WaitForElementTillPageNavigationSettled("StepperControl");
            Assert.That(App.FindElement("MinimumLabel").GetText(), Is.EqualTo("0.00"));
            Assert.That(App.FindElement("MaximumLabel").GetText(), Is.EqualTo("10.00"));
            Assert.That(App.FindElement("ValueLabel").GetText(), Is.EqualTo("0.00"));
        }
    }
}
