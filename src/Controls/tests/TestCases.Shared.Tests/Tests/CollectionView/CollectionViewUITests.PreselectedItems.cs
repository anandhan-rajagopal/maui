using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewPreselectedItemsUITests : CollectionViewUITests
	{
		public CollectionViewPreselectedItemsUITests(TestDevice device)
			: base(device)
		{
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void PreselectedItems_AreDisplayedOnLoad()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Preselected Items");

			VerifyScreenshot();
		}
	}
}