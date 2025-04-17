using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests;

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

    [Test, Order(1)]
    [Category(UITestCategories.CollectionView)]
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
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstItemSourceList_WhenItemSourceList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("Banana"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeMultiple_FirstItemSourceList_WhenItemSourceList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeMultiple");
        App.Tap("SelectionModeMultiple");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("2"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("Banana"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("Banana"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("2"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("2"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstItemsSourceGroupList_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstItemsSourceGroupList_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("Orange"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("Orange"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeMultiple_FirstItemsSourceGroupList_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("SelectionModeMultiple");
        App.Tap("SelectionModeMultiple");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("2"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeMultiple_FirstSelectionMode_WhenItemsSourceGroupList()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeMultiple");
        App.Tap("SelectionModeMultiple");
        App.WaitForElement("ItemsSourceGroupList");
        App.Tap("ItemsSourceGroupList");
        App.WaitForElement("IsGroupedTrue");
        App.Tap("IsGroupedTrue");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        App.WaitForElement("Group A");
        App.WaitForElement("Group B");
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("2"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyView()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewGrid");
        App.Tap("EmptyViewGrid");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyString()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewString");
        App.Tap("EmptyViewString");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(String)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceEmptyListWithEmptyView()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewGrid");
        App.Tap("EmptyViewGrid");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeNone_FirstSelectionMode_WhenItemsSourceEmptyListWithEmptyString()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeNone");
        App.Tap("SelectionModeNone");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewString");
        App.Tap("EmptyViewString");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(String)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyView()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewGrid");
        App.Tap("EmptyViewGrid");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyString()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewString");
        App.Tap("EmptyViewString");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(String)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceEmptyListWithEmptyView()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewGrid");
        App.Tap("EmptyViewGrid");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeSingle_FirstSelectionMode_WhenItemsSourceEmptyListWithEmptyString()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeSingle");
        App.Tap("SelectionModeSingle");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewString");
        App.Tap("EmptyViewString");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(String)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
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
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeMultiple_FirstItemsSourceEmptyList_WhenItemsSourceEmptyListWithEmptyViewString()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewString");
        App.Tap("EmptyViewString");
        App.WaitForElement("SelectionModeMultiple");
        App.Tap("SelectionModeMultiple");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(String)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void SelectionModeMultiple_FirstSelectionMode_WhenItemsSourceEmptyListAndEmptyView()
    {
        App.WaitForElement("Options");
        App.Tap("Options");
        App.WaitForElement("SelectionModeMultiple");
        App.Tap("SelectionModeMultiple");
        App.WaitForElement("ItemsSourceEmptyList");
        App.Tap("ItemsSourceEmptyList");
        App.WaitForElement("EmptyViewGrid");
        App.Tap("EmptyViewGrid");
        App.WaitForElement("Apply");
        App.Tap("Apply");
        App.WaitForElement("No Items Available(Grid View)");
        Assert.That(App.WaitForElement("SelectedSingle").GetText(), Is.EqualTo("No item selected"));
        Assert.That(App.WaitForElement("SelectedMultiple").GetText(), Is.EqualTo("0"));
    }
}