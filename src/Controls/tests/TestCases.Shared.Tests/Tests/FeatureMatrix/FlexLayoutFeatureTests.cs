using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests;

[Category(UITestCategories.Layout)]
public class FlexLayoutFeatureTests : UITest
{
    public const string FlexLayoutFeatureMatrix = "FlexLayout Feature Matrix";

    public FlexLayoutFeatureTests(TestDevice device) : base(device) { }

    protected override void FixtureSetup()
    {
        base.FixtureSetup();
        App.NavigateToGallery(FlexLayoutFeatureMatrix);
    }

    [Test, Order(1)]
    public void FlexLayout_ValidateDefaultValues()
    {
        App.WaitForElement("AlignContentLabel");
        Assert.That(App.FindElement("AlignContentLabel").GetText(), Is.EqualTo("Stretch"));
        Assert.That(App.FindElement("AlignItemsLabel").GetText(), Is.EqualTo("Stretch"));
        Assert.That(App.FindElement("DirectionLabel").GetText(), Is.EqualTo("Row"));
        Assert.That(App.FindElement("JustifyContentLabel").GetText(), Is.EqualTo("Start"));
        Assert.That(App.FindElement("WrapLabel").GetText(), Is.EqualTo("NoWrap"));
        Assert.That(App.FindElement("Child1AlignSelfLabel").GetText(), Is.EqualTo("Auto"));
    }

    [Test]
    public void FlexLayout_SetDirectionAndJustifyContent()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("DirectionColumnButton");
        App.Tap("DirectionColumnButton");
        App.WaitForElement("JustifyContentCenterButton");
        App.Tap("JustifyContentCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElementTillPageNavigationSettled("AlignContentLabel");
        Assert.That(App.FindElement("DirectionLabel").GetText(), Is.EqualTo("Column"));
        Assert.That(App.FindElement("JustifyContentLabel").GetText(), Is.EqualTo("Center"));
        VerifyScreenshot();
    }

    [Test]
    public void FlexLayout_SetWrapAlignContentAlignItems()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("WrapWrapButton");
        App.Tap("WrapWrapButton");
        App.WaitForElement("AlignContentCenterButton");
        App.Tap("AlignContentCenterButton");
        App.WaitForElement("AlignItemsCenterButton");
        App.Tap("AlignItemsCenterButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElementTillPageNavigationSettled("WrapLabel");
        Assert.That(App.FindElement("WrapLabel").GetText(), Is.EqualTo("Wrap"));
        Assert.That(App.FindElement("AlignContentLabel").GetText(), Is.EqualTo("Center"));
        Assert.That(App.FindElement("AlignItemsLabel").GetText(), Is.EqualTo("Center"));
        VerifyScreenshot();
    }

    [Test]
    public void FlexLayout_SetChild1GrowOrderShrinkBasisPosition()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("Child1GrowEntry");
        App.ClearText("Child1GrowEntry");
        App.EnterText("Child1GrowEntry", "2");
        App.PressEnter();
        App.ClearText("Child1OrderEntry");
        App.EnterText("Child1OrderEntry", "2");
        App.PressEnter();
        App.ClearText("Child1ShrinkEntry");
        App.EnterText("Child1ShrinkEntry", "2");
        App.PressEnter();
        App.WaitForElement("Child1BasisFixed100Button");
        App.Tap("Child1BasisFixed100Button");
        App.WaitForElement("Child1PositionAbsoluteButton");
        App.Tap("Child1PositionAbsoluteButton");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElementTillPageNavigationSettled("Child1GrowLabel");
        Assert.That(App.FindElement("Child1GrowLabel").GetText(), Is.EqualTo("2"));
        Assert.That(App.FindElement("Child1OrderLabel").GetText(), Is.EqualTo("2"));
        Assert.That(App.FindElement("Child1ShrinkLabel").GetText(), Is.EqualTo("2"));
        Assert.That(App.FindElement("Child1BasisLabel").GetText(), Is.EqualTo("Fixed100"));
        Assert.That(App.FindElement("Child1PositionLabel").GetText(), Is.EqualTo("Absolute"));
        VerifyScreenshot();
    }
}
