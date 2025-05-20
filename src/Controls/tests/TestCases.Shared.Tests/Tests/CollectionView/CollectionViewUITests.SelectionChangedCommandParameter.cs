using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectioinViewSelectionChangedCommandParameterUITests : CollectionViewUITests
	{
		public CollectioinViewSelectionChangedCommandParameterUITests(TestDevice device)
			: base(device)
		{
		}

		[Test]
		[Category(UITestCategories.CollectionView)]
		public void CollectionView_SelectionChangedCommandParameter_UpdatesResultLabel()
		{
			// Navigate to the selection galleries
			VisitInitialGallery("Selection");

			// Navigate to the specific sample inside selection galleries
			VisitSubGallery("SelectionChangedCommandParameter");

			App.WaitForElement("Pending...");
			App.WaitForElement("Item 2");
			App.Tap("Item 2");
			App.WaitForElement("Success");
		}
	}
}