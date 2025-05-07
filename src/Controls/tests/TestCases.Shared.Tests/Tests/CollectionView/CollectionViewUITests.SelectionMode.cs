using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewSelectionModeUITests : CollectionViewUITests
	{
		public CollectionViewSelectionModeUITests(TestDevice device)
			: base(device)
		{
		}
		protected override bool ResetAfterEachTest => true;

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void SelectionModeNone()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("SelectionModes");

			App.WaitForElement("cover1.jpg, 0");
			App.Tap("cover1.jpg, 0");
			App.WaitForElement("Selection (event): [none]");
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void SelectionModeSingle()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("SelectionModes");

			App.WaitForElement("None");
			App.Tap("None");
			App.WaitForElement("Single");
			App.Tap("Single");

			App.WaitForElement("cover1.jpg, 0");
			App.Tap("cover1.jpg, 0");
			App.WaitForElement("Selection (event): cover1.jpg, 0");
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void SelectionModeMultiple()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("Selection Modes");

			App.WaitForElement("None");
			App.Tap("None");
			App.WaitForElement("Multiple");
			App.Tap("Multiple");

			App.WaitForElement("cover1.jpg, 0");
			App.Tap("cover1.jpg, 0");
			App.WaitForElement("Selection (event): cover1.jpg, 0");
			App.Tap("oasis.jpg, 1");
			App.WaitForElement("Selection (event): cover1.jpg, 0, oasis.jpg, 1");
		}
	}
}