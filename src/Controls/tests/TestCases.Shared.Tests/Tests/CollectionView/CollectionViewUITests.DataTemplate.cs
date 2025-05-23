using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewDataTemplateTests : CollectionViewUITests
	{
		protected override bool ResetAfterEachTest => true;

		public CollectionViewDataTemplateTests(TestDevice device)
			: base(device)
		{
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DataTemplate_VerticalList_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("DataTemplate");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Vertical List (Code)");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DataTemplate_HorizontalList_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("DataTemplate");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Horizontal List (Code)");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DataTemplate_VerticalGrid_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("DataTemplate");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Vertical Grid (Code)");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DataTemplate_HorizontalGrid_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("DataTemplate");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Horizontal Grid (Code)");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DataTemplate_DataTemplateSelector_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("DataTemplate");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("DataTemplateSelector");

			VerifyScreenshot();
		}
	}
}