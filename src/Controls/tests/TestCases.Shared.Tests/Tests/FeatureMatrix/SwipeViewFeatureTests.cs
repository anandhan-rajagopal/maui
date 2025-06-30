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
		App.SwipeRightToLeft("SwipeViewControl");	
		App.WaitForElement("Label");
		App.Tap("Label");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		Assert.That(App.WaitForElement("SwipeStartedLabel").GetText(), Is.EqualTo("Swipe Started: Left"));
		Assert.That(App.WaitForElement("SwipeChangingLabel").GetText(), Is.EqualTo("Swipe Changing: Left"));
		Assert.That(App.WaitForElement("SwipeEndedLabel").GetText(), Is.EqualTo("Swipe Ended: Left, IsOpen: Open"));

		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		Assert.That(App.WaitForElement("SwipeStartedLabel").GetText(), Is.EqualTo("Swipe Started: Right"));
		Assert.That(App.WaitForElement("SwipeChangingLabel").GetText(), Is.EqualTo("Swipe Changing: Right"));
		Assert.That(App.WaitForElement("SwipeEndedLabel").GetText(), Is.EqualTo("Swipe Ended: Right, IsOpen: Open"));
	}

	[Test, Order(2)]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWhenProgrammaticActions()
	{
		App.WaitForElement("SwipeViewControl");
		App.WaitForElement("OpenLeft");
		App.Tap("OpenLeft");
		App.WaitForElement("Label");
		App.Tap("OpenRight");
		App.WaitForElement("Label");
		App.Tap("OpenTop");
		App.WaitForElement("Label");
		App.Tap("OpenBottom");
		App.WaitForElement("Label");
		App.Tap("Close");
		App.WaitForNoElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithImageContentChanged()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentChanged()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithThreshold()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThresholdEntry");
		App.ClearText("ThresholdEntry");
		App.EnterText("ThresholdEntry", "50");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("LightGreenBackground");
		App.Tap("LightGreenBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithFlowDirection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("FlowDirectionRightToLeft");
		App.Tap("FlowDirectionRightToLeft");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithShadow()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ShadowCheckBox");
		App.Tap("ShadowCheckBox");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithIsEnabledFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsEnabledFalse");
		App.Tap("IsEnabledFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForNoElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithIsVisibleFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("SwipeViewControl");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithSwipeMode()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("SwipeLabelItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithSwipeBehaviorOnInvoked()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("RemainOpenSwipeBehavior");
		App.Tap("RemainOpenSwipeBehavior");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("SwipeLabelItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithSwipeItemsBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("YellowSwipeItemBackground");
		App.Tap("YellowSwipeItemBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.ScrollDown("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithIconImageSwipeItemChanged()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IconImageSourceSwipeItem");
		App.Tap("IconImageSourceSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.ScrollDown("SwipeViewControl");
		App.WaitForElement("SwipeIconItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithButtonSwipeItemChanged()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ButtonSwipeItem");
		App.Tap("ButtonSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.ScrollDown("SwipeViewControl");
		App.WaitForElement("SwipeButtonItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyCollectionViewContentWithLabelSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("LabelSwipeItem");
		App.Tap("LabelSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("Item 3");
		App.SwipeRightToLeft("Item 6");
		App.WaitForElement("SwipeLabelItem");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyCollectionViewContentWithIconImageSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("IconImageSourceSwipeItem");
		App.Tap("IconImageSourceSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("Item 2");
		App.SwipeRightToLeft("Item 4");
		App.WaitForElement("SwipeIconItem");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyCollectionViewContentWithButtonSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("ButtonSwipeItem");
		App.Tap("ButtonSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("Item 1");
		App.SwipeRightToLeft("Item 5");
		App.WaitForElement("SwipeButtonItem");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyImageContentWithLabelSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("LabelSwipeItem");
		App.Tap("LabelSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("SwipeLabelItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyImageContentWithIconImageSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("IconImageSourceSwipeItem");
		App.Tap("IconImageSourceSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("SwipeIconItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyImageContentWithButtonSwipeItem()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("ButtonSwipeItem");
		App.Tap("ButtonSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("SwipeButtonItem");
	}
}