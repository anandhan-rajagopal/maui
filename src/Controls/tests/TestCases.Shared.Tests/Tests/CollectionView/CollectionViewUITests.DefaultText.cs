using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewDefaultTextTests : CollectionViewUITests
	{
		protected override bool ResetAfterEachTest => true;

		public CollectionViewDefaultTextTests(TestDevice device)
			: base(device)
		{
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DefaultText_VerticalList_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Default Text");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Vertical List (Code) ");

			App.WaitForElement("entryUpdate");
			App.EnterText("entryUpdate", "10");

			App.WaitForElement("btnUpdate");
			App.Tap("btnUpdate");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DefaultText_HorizontalList_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Default Text");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Horizontal List (Code) ");

			App.WaitForElement("entryUpdate");
			App.EnterText("entryUpdate", "5");

			App.WaitForElement("btnUpdate");
			App.Tap("btnUpdate");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DefaultText_VerticalGrid_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Default Text");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Grid (Code) ");

			App.WaitForElement("entryUpdate");
			App.EnterText("entryUpdate", "20");

			App.WaitForElement("btnUpdate");
			App.Tap("btnUpdate");

			VerifyScreenshot();
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void DefaultText_HorizontalGrid_DisplaysCorrectly()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Default Text");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Horizontal Grid (Code) ");

			App.WaitForElement("entryUpdate");
			App.EnterText("entryUpdate", "10");

			App.WaitForElement("btnUpdate");
			App.Tap("btnUpdate");

			VerifyScreenshot();
		}
	}
}