using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests
{
	public class CollectionViewSingleBoundSelectionUITests : _IssuesUITest
	{
		public CollectionViewSingleBoundSelectionUITests(TestDevice device)
			: base(device)
		{
		}
		public override string Issue => "CollectionView: Single Selection Binding";
		
		[Test]
		[Category(UITestCategories.CollectionView)]
		[Description("Single Selection Binding")]
		public void SelectionShouldUpdateBinding()
		{
			App.WaitForElement("Selected: Item: 2");
			App.WaitForElement("Item 1");
			App.Tap("Item 1");	
			App.WaitForElement("Selected: Item: 1");
		}
		
	}
}