using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests
{
	public class SelectionFeatureTests : UITest
	{
		public const string SelectionFeatureMatrix = "CollectionView Feature Matrix";

		public SelectionFeatureTests(TestDevice device)
			: base(device)
		{
		}

		protected override void FixtureSetup()
		{
			base.FixtureSetup();
			App.NavigateToGallery(SelectionFeatureMatrix);
		}

        [Test(Order(1))]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstItemSourceList_WhenItemSourceList()
        {
            App.WaitForElement("SelectionPageButton");
            App.Tap("SelectionPageButton");
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstItemSourceList_WhenItemSourceList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstItemSourceList_WhenItemSourceList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstItemsSourceObservableCollection_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstItemsSourceObservableCollection_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstItemsSourceObservableCollection_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstSelectionMode_WhenItemsSourceObservableCollection()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("ItemsSourceObservableCollection");
            App.Tap("ItemsSourceObservableCollection");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstItemsSourceGroupedList_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstItemsSourceGroupedList_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstItemsSourceGroupedList_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstSelectionMode_WhenItemsSourceGroupedList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("ItemsSourceGroupedList");
            App.Tap("ItemsSourceGroupedList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstItemsSourceEmptyList_WhenItemsSourceEmptyList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceEmptyList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeNone");
            App.Tap("SelectionModeNone");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstItemsSourceEmptyList_WhenItemsSourceEmptyList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceEmptyList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeSingle");
            App.Tap("SelectionModeSingle");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyView()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("EmptyViewGrid");
            App.Tap("EmptyViewGrid");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

        [Test]
        [Category(UICategoryType.CollectionView)]
        public void SelectionModeMultiple_FirstSelectionMode_WhenItemsSourceEmptyList()
        {
            App.WaitForElement("Options");
            App.Tap("Options");
            App.WaitForElement("SelectionModeMultiple");
            App.Tap("SelectionModeMultiple");
            App.WaitForElement("ItemsSourceEmptyList");
            App.Tap("ItemsSourceEmptyList");
            App.WaitForElement("Apply");
            App.Tap("Apply");
        }

    }
}