using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
    public class CollectionViewGroupingTests : CollectionViewUITests
    {
        protected override bool ResetAfterEachTest => true;

        public CollectionViewGroupingTests(TestDevice device)
            : base(device)
        {
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingAndHeaderWorks()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Basic Grouping");

            // header
            App.WaitForElement("This is a header");
            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 12");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingAndHeaderWorksWithEmptyGroup()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, some empty groups");

            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 0");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithNoTemplate()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, no templates");

            App.WaitForElement("Black Panther");
            App.WaitForElement("Thor");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithSelection()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, with selection");

            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 12");

            App.WaitForElement("Black Panther");
            App.Tap("Black Panther");
            VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndRemoveSelected()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("Ant-Man");
            App.Tap("Ant-Man");
            App.WaitForElement("RemoveItem");
            App.Tap("RemoveItem");
            App.WaitForNoElement("Ant-Man");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndReplaceSelected()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("Iron Man");
            App.Tap("Iron Man");
            App.WaitForNoElement("Spider-Man");
            App.WaitForElement("ReplaceItem");
            App.Tap("ReplaceItem");
            App.WaitForNoElement("Iron Man");
            App.WaitForElement("Spider-Man");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndAddAfterSelected()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("The Hulk");
            App.Tap("The Hulk");
            App.WaitForNoElement("Spider-Man");
            App.WaitForElement("AddItem");
            App.Tap("AddItem");
            App.WaitForElement("Spider-Man");
            VerifyScreenshot();
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndRemoveGroup()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("Avengers");
            App.WaitForElement("RemoveGroup");
            App.Tap("RemoveGroup");
            App.WaitForNoElement("Avengers");
            App.WaitForElement("Fantastic Four");
            App.WaitForElement("RemoveGroup");
            App.Tap("RemoveGroup");
            App.WaitForNoElement("Fantastic Four");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndMoveSelectedItemToAnotherGroup()
        {
            Exception? exception = null;

            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("The Thing");
            App.Tap("The Thing");
            VerifyScreenshotOrSetException(ref exception, "SelectedItemWhenBeforeMoving");
            App.WaitForElement("MoveItem");
            App.Tap("MoveItem");
            VerifyScreenshotOrSetException(ref exception, "SelectedItemWhenAfterMoving");

            if (exception != null)
            {
                throw exception;
            }
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndAddGroup()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForNoElement("Excalibur");
            App.WaitForElement("AddGroup");
            App.Tap("AddGroup");
            App.WaitForElement("Excalibur");
            App.WaitForElement("Total members: 0");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndMoveGroupToAnotherPositioin()
        {
            Exception? exception = null;
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("Defenders");
            App.WaitForElement("Avengers");
            VerifyScreenshotOrSetException(ref exception, "GroupBeforeMoving");
            App.WaitForElement("MoveGroup");
            App.Tap("MoveGroup");
            VerifyScreenshotOrSetException(ref exception, "GroupAfterMoving");

            if (exception != null)
            {
                throw exception;
            }
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWithObservableAndReplaceSecondGroup()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Observable");

            // header
            App.WaitForElement("This is a header");
            App.WaitForElement("Fantastic Four");
            App.WaitForElement("The Thing");
            App.WaitForElement("The Invisible Woman");
            App.WaitForElement("Total members: 4");
            App.Tap("ReplaceGroup");
            App.WaitForElement("Alpha Flight");
            App.WaitForElement("Guardian");
            App.WaitForElement("Sasquatch");
            App.WaitForElement("Total members: 3");
            App.WaitForNoElement("Fantastic Four");
            App.WaitForNoElement("The Thing");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorksWith()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Grouping, Grid");

            App.WaitForElement("This is a header");
            App.WaitForElement("Avengers");
            VerifyScreenshot();
        }
    }
}