using NUnit.Framework;
using UITest.Appium;
using UITest.Core;


namespace Microsoft.Maui.TestCases.Tests;

public class SelectionFeatureTests : UITest
{
    public const string SelectionFeatureMatrix = "CollectionView Feature Matrix";
    public const string ItemsSourceGroupedList = "ItemsSourceGroupedList";
    public const string ItemsSourceObservableCollection25 = "ItemsSourceObservableCollection25";
    public const string ItemsSourceNone = "ItemsSourceNone";
    public const string IsGroupedTrue = "IsGroupedTrue";
    public const string IsGroupedFalse = "IsGroupedFalse";
    public const string SelectionModeNone = "SelectionModeNone";
    public const string SelectionModeSingle = "SelectionModeSingle";
    public const string SelectionModeMultiple = "SelectionModeMultiple";
    public const string Apply = "Apply";
    public const string Options = "Options";
    public const string SelectedSingle = "SelectedSingle";
    public const string SelectedMultiple = "SelectedMultiple";
    public const string ItemsLayoutVerticalList = "ItemsLayoutVerticalList";
    public const string ItemsLayoutHorizontalList = "ItemsLayoutHorizontalList";
    public const string ItemsLayoutVerticalGrid = "ItemsLayoutVerticalGrid";
    public const string ItemsLayoutHorizontalGrid = "ItemsLayoutHorizontalGrid";
    public const string CurrentSelectionTextLabel = "CurrentSelectionTextLabel";
    public const string PreviousSelectionTextLabel = "PreviousSelectionTextLabel";
    public const string SelectionChangedEventCountLabel = "SelectionChangedEventCountLabel";
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
    public void VerifySelectionModeNoneWhenItemsSourceNone()
    {
        App.WaitForElement("SelectionPageButton");
        App.Tap("SelectionPageButton");
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsSourceNone);
        App.Tap(ItemsSourceNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsSourceNone()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsSourceNone);
        App.Tap(ItemsSourceNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link:https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsSourceNone()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsSourceNone);
        App.Tap(ItemsSourceNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsSourceObservableCollection5()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsSourceObservableCollection5()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemSourceObservableCollection5()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("2"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsSourceObservableCollection25()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsSourceObservableCollection25);
        App.Tap(ItemsSourceObservableCollection25);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.WaitForElement("Cucumber");
        App.Tap("Cucumber");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsSourceObservableCollection25()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsSourceObservableCollection25);
        App.Tap(ItemsSourceObservableCollection25);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.WaitForElement("Cucumber");
        App.Tap("Cucumber");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Cucumber"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsSourceObservableCollection25()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsSourceObservableCollection25);
        App.Tap(ItemsSourceObservableCollection25);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.WaitForElement("Cucumber");
        App.Tap("Cucumber");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Cucumber"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("2"));
    }
#endif

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //In CV2 related issue link: https://github.com/dotnet/maui/issues/28509 and In windows, relates issue: https://github.com/dotnet/maui/issues/28824
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsSourceGroupList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsSourceGroupedList);
        App.Tap(ItemsSourceGroupedList);
        App.WaitForElement(IsGroupedTrue);
        App.Tap(IsGroupedTrue);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Fruits");
        App.WaitForElement("Vegetables");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsSourceGroupList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsSourceGroupedList);
        App.Tap(ItemsSourceGroupedList);
        App.WaitForElement(IsGroupedTrue);
        App.Tap(IsGroupedTrue);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Carrot");
        App.Tap("Carrot");
        App.WaitForElement("Fruits");
        App.WaitForElement("Vegetables");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Carrot"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsSourceGroupList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsSourceGroupedList);
        App.Tap(ItemsSourceGroupedList);
        App.WaitForElement(IsGroupedTrue);
        App.Tap(IsGroupedTrue);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Carrot");
        App.Tap("Carrot");
        App.WaitForElement("Apple");
        App.Tap("Apple");
        App.ScrollDown("CollectionViewControl", ScrollStrategy.Gesture, 0.9, 500);
        App.WaitForElement("Spinach");
        App.Tap("Spinach");
        App.WaitForElement("Potato");
        App.Tap("Potato");
        App.WaitForElement("Fruits");
        App.WaitForElement("Vegetables");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("5"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Carrot, Apple, Spinach, Potato"));
    }
#endif
#endif

#if TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //In CV2, related issue link: https://github.com/dotnet/maui/issues/28030 and In windows, relates issue:https://github.com/dotnet/maui/issues/27946                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsLayoutVerticalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsLayoutVerticalList);
        App.Tap(ItemsLayoutVerticalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsLayoutVerticalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsLayoutVerticalList);
        App.Tap(ItemsLayoutVerticalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Grapes");
        App.Tap("Grapes");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Grapes"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsLayoutVerticalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsLayoutVerticalList);
        App.Tap(ItemsLayoutVerticalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Apple");
        App.Tap("Apple");
        App.WaitForElement("Mango");
        App.Tap("Mango");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("3"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Apple, Mango"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsLayoutHorizontalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsLayoutHorizontalList);
        App.Tap(ItemsLayoutHorizontalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsLayoutHorizontalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsLayoutHorizontalList);
        App.Tap(ItemsLayoutHorizontalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Mango");
        App.Tap("Mango");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Mango"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsLayoutHorizontalList()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsLayoutHorizontalList);
        App.Tap(ItemsLayoutHorizontalList);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Apple");
        App.Tap("Apple");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("2"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Apple"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsLayoutVerticalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsLayoutVerticalGrid);
        App.Tap(ItemsLayoutVerticalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsLayoutVerticalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsLayoutVerticalGrid);
        App.Tap(ItemsLayoutVerticalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsLayoutVerticalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsLayoutVerticalGrid);
        App.Tap(ItemsLayoutVerticalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Grapes");
        App.Tap("Grapes");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("3"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Grapes, Banana"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenItemsLayoutHorizontalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(ItemsLayoutHorizontalGrid);
        App.Tap(ItemsLayoutHorizontalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenItemsLayoutHorizontalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(ItemsLayoutHorizontalGrid);
        App.Tap(ItemsLayoutHorizontalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenItemsLayoutHorizontalGrid()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(ItemsLayoutHorizontalGrid);
        App.Tap(ItemsLayoutHorizontalGrid);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        App.WaitForElement("Banana");
        App.Tap("Banana");
        App.WaitForElement("Apple");
        App.Tap("Apple");
        App.WaitForElement("Grapes");
        App.Tap("Grapes");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("4"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Banana, Apple, Grapes"));
    }
#endif
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenProgrammaticSelectionWorks()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement("Mango");
        App.Tap("Mango");
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("0"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenProgrammaticSelectionWorks()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement("Mango");
        App.Tap("Mango");
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Mango"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenProgrammaticSelectionWorks()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement("Mango");
        App.Tap("Mango");
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Mango"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Mango, Banana"));
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("2"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelecctionModeSingleWhenCurrentSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(CurrentSelectionTextLabel).GetText(), Is.EqualTo("Banana"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(CurrentSelectionTextLabel).GetText(), Is.EqualTo("Orange"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenCurrentSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(CurrentSelectionTextLabel).GetText(), Is.EqualTo("Banana"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(CurrentSelectionTextLabel).GetText(), Is.EqualTo("Banana, Orange"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenCurrentSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(CurrentSelectionTextLabel).GetText(), Is.EqualTo("No current items"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleWhenPreviousSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("No previous items"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("Banana"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWhenPreviousSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("No previous items"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("Banana"));
        App.WaitForElement("Apple");
        App.Tap("Apple");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("Banana, Orange"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeNoneWhenPreviousSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeNone);
        App.Tap(SelectionModeNone);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("No previous items"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(PreviousSelectionTextLabel).GetText(), Is.EqualTo("No previous items"));
    }

#if TEST_FAILS_ON_CATALYST //related issue link: https://github.com/dotnet/maui/issues/18028
    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleWithToggleSelection()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange"));
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("2"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Banana"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(SelectedMultiple).GetText(), Is.EqualTo("1"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
    }

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeMultipleSelectionChangedEventCount()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeMultiple);
        App.Tap(SelectionModeMultiple);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("2 times"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("3 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange"));
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("4 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange, Banana"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("5 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
    }
#endif

    [Test]
    [Category(UITestCategories.CollectionView)]
    public void VerifySelectionModeSingleSelectionChangedEventCount()
    {
        App.WaitForElement(Options);
        App.Tap(Options);
        App.WaitForElement(SelectionModeSingle);
        App.Tap(SelectionModeSingle);
        App.WaitForElement(Apply);
        App.Tap(Apply);
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("2 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("No items selected"));
        App.WaitForElement("Orange");
        App.Tap("Orange");
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("3 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Orange"));
        App.WaitForElement("Banana");
        App.Tap("Banana");
        Assert.That(App.WaitForElement(SelectionChangedEventCountLabel).GetText(), Is.EqualTo("4 times"));
        Assert.That(App.WaitForElement(SelectedSingle).GetText(), Is.EqualTo("Banana"));
    }
}