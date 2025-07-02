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
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		Assert.That(App.WaitForElement("SwipeStartedLabel").GetText(), Is.EqualTo("Swipe Started: Right"));
		Assert.That(App.WaitForElement("SwipeChangingLabel").GetText(), Is.EqualTo("Swipe Changing: Right"));
		Assert.That(App.WaitForElement("SwipeEndedLabel").GetText(), Is.EqualTo("Swipe Ended: Right, IsOpen: Open"));

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
	public void VerifySwipeViewWhenLabelContentAndProgrammaticActions()
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

	[Test, Order(3)]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithImageContentAndProgrammaticActions()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewImage");
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

	[Test, Order(4)]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentAndProgrammaticActions()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewCollectionItem");
		App.WaitForElement("OpenLeft");
		App.Tap("OpenLeft");
		App.WaitForNoElement("Label");
		App.Tap("OpenRight");
		App.WaitForNoElement("Label");
		App.SwipeLeftToRight("Item 4");
		App.WaitForElement("Label");
		App.WaitForElement("Close");
		App.Tap("Close");
		App.WaitForElement("Label");
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
		App.WaitForElement("SwipeViewImage");
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
		App.WaitForElement("SwipeViewCollectionItem");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentAndThreshold()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThresholdEntry");
		App.ClearText("ThresholdEntry");
		App.EnterText("ThresholdEntry", "30");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewLabel");
		App.SwipeLeftToRight("SwipeViewLabel");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithImageContentAndThreshold()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("ThresholdEntry");
		App.ClearText("ThresholdEntry");
		App.EnterText("ThresholdEntry", "30");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewImage");
		App.SwipeLeftToRight("SwipeViewImage");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentAndThreshold()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("ThresholdEntry");
		App.ClearText("ThresholdEntry");
		App.EnterText("ThresholdEntry", "30");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewCollectionItem");
		App.SwipeLeftToRight("Item 4");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentAndBackgroundColor()
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
	public void VerifySwipeViewWithImageContentAndBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("LightGreenBackground");
		App.Tap("LightGreenBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentAndBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("LightPinkBackground");
		App.Tap("LightPinkBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentAndFlowDirection()
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
	public void VerifySwipeViewWithImageContentAndFlowDirection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("FlowDirectionRightToLeft");
		App.Tap("FlowDirectionRightToLeft");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentAndFlowDirection()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("FlowDirectionRightToLeft");
		App.Tap("FlowDirectionRightToLeft");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentAndShadow()
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
	public void VerifySwipeViewWithImageContentAndShadow()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("ShadowCheckBox");
		App.Tap("ShadowCheckBox");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentAndIsEnabledFalse()
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
	public void VerifySwipeViewWithImageContentAndIsEnabledFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
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
	public void VerifySwipeViewWithCollectionViewContentAndIsEnabledFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
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
	public void VerifySwipeViewWithLabelContentAndIsVisibleFalse()
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
	public void VerifySwipeViewWithImageContentAndIsVisibleFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("SwipeViewControl");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentAndIsVisibleFalse()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("IsVisibleFalse");
		App.Tap("IsVisibleFalse");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForNoElement("SwipeViewControl");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelContentSwipeMode()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithImageContentSwipeMode()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithCollectionViewContentSwipeMode()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("CollectionViewContent");
		App.Tap("CollectionViewContent");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyLabelWithSwipeRevealAndSwipeBehaviorOnInvokedAuto()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		App.WaitForNoElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyImageWithSwipeRevealAndSwipeBehaviorOnInvokedAuto()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ImageContent");
		App.Tap("ImageContent");
		App.WaitForElement("ImageSwipeItem");
		App.Tap("ImageSwipeItem");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeRightToLeft("SwipeViewControl");
		App.WaitForElement("SwipeIconItem");
		App.Tap("SwipeIconItem");
		App.WaitForNoElement("SwipeIconItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyCollectionViewWithSwipeRevealAndSwipeBehaviorOnInvokedAuto()
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
		App.SwipeRightToLeft("Item 3");
		App.WaitForElement("SwipeButtonItem");
		App.Tap("SwipeButtonItem");
		App.WaitForNoElement("SwipeButtonItem");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeModeRevealWithSwipeBehaviorOnInvokedRemainOpen()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("SwipeBehaviorOnInvokedRemainOpen");
		App.Tap("SwipeBehaviorOnInvokedRemainOpen");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		App.WaitForElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeModeRevealWithSwipeBehaviorOnInvokedClose()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("SwipeBehaviorOnInvokedClose");
		App.Tap("SwipeBehaviorOnInvokedClose");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		App.WaitForNoElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeModeExecuteWithSwipeBehaviorOnInvokedAuto()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeModeExecuteWithSwipeBehaviorOnInvokedRemainOpen()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("SwipeBehaviorOnInvokedRemainOpen");
		App.Tap("SwipeBehaviorOnInvokedRemainOpen");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		App.WaitForElement("Label");
		App.Tap("Label");
		App.WaitForElement("Label");
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeModeExecuteWithSwipeBehaviorOnInvokedClose()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("SwipeBehaviorOnInvokedClose");
		App.Tap("SwipeBehaviorOnInvokedClose");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("EventInvokedLabel").GetText(), Is.EqualTo("Label Invoked"));
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithLabelSwipeItemsBackgroundColor()
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
	public void VerifySwipeViewWithIconImageSwipeItemsBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("IconImageSourceSwipeItem");
		App.Tap("IconImageSourceSwipeItem");
		App.WaitForElement("YellowSwipeItemBackground");
		App.Tap("YellowSwipeItemBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		VerifyScreenshot();
	}

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifySwipeViewWithButtonSwipeItemsBackgroundColor()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ButtonSwipeItem");
		App.Tap("ButtonSwipeItem");
		App.WaitForElement("YellowSwipeItemBackground");
		App.Tap("YellowSwipeItemBackground");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
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
		App.WaitForElement("Label");
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
		App.WaitForElement("Label");
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

	[Test]
	[Category(UITestCategories.SwipeView)]
	public void VerifyThresholdWithSwipeMode()
	{
		App.WaitForElement("Options");
		App.Tap("Options");
		App.WaitForElement("ThresholdEntry");
		App.ClearText("ThresholdEntry");
		App.EnterText("ThresholdEntry", "20");
		App.WaitForElement("ExecuteSwipeMode");
		App.Tap("ExecuteSwipeMode");
		App.WaitForElement("Apply");
		App.Tap("Apply");
		App.WaitForElement("SwipeViewControl");
		App.SwipeLeftToRight("SwipeViewControl");
		Assert.That(App.WaitForElement("SwipeStartedLabel").GetText(), Is.EqualTo("Swipe Started: Right"));
	}
}