using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
namespace Microsoft.Maui.TestCases.Tests;

public class SwipeViewFeatureTests : UITest
{
	public const string SwipeViewFeatureMatrix = "SwipeView Feature Matrix";

	public SwipeViewFeatureTests(TestDevice device)
		: base(device)
	{
	}

	protected override void FixtureSetup()
	{
		base.FixtureSetup();
		App.NavigateToGallery(SwipeViewFeatureMatrix);
	}

	[Test, Order(1)]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWhenEvents()
	{
		App.WaitForElement("SwipeViewControl");
		App.WaitForElement("SwipeView Content");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		Assert.That(App.WaitForElement("SwipeStartedLabel").GetText(), Is.EqualTo("Swipe Started: Right"));
		Assert.That(App.WaitForElement("SwipeChangingLabel").GetText(), Is.EqualTo("Swipe Changing: Right, Offset: 193.3333282470703"));
		Assert.That(App.WaitForElement("SwipeEndedLabel").GetText(), Is.EqualTo("Swipe Ended: Right, IsOpen: Open"));
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithThreshold()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Threshold");
		App.EnterText("Threshold", "100");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
	}
}