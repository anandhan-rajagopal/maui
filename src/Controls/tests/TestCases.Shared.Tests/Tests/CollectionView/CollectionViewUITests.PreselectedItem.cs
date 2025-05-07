using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewPreselectedItemUITests : CollectionViewUITests
	{
		public CollectionViewPreselectedItemUITests(TestDevice device)
			: base(device)
		{
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void PreselectedItem()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Preselected Item");

			VerifyScreenshot();
		}
	}
}