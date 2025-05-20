using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
#if IOS
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

            VisitSubGallery("Empty Group");

            // header
            App.WaitForElement("This is a header");
            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 0");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingAndHeaderWorksWithNoTemplate()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("No Template");

            // header
            App.WaitForElement("This is a header");
            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 12");
        }

        [Test]
        [Category(UITestCategories.CollectionView)]
        public void GroupingWorkWithSelection()
        {
            VisitInitialGallery("Grouping");

            VisitSubGallery("Selection");

            // header
            App.WaitForElement("This is a header");
            // group header
            App.WaitForElement("Avengers");
            // group footer
            App.WaitForElement("Total members: 12");

            App.WaitForElement("Black Panther");
            App.Tap("Black Panther");
            VerifyScreenshot();
        }
    }
#endif
}