#if TEST_FAILS_ON_CATALYST // Swipe, ScrollDown not working on MacCatalyst
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class ShellGestures : _IssuesUITest
{
	public ShellGestures(TestDevice testDevice) : base(testDevice)
	{
	}
	const string SwipeTitle = "Swipe";
	const string SwipeGestureSuccess = "SwipeGesture Success";
	const string SwipeGestureSuccessId = "SwipeGestureSuccessId";
	const string TableViewTitle = "Table View";
	const string TableViewId = "TableViewId";
	const string ListViewTitle = "List View";
	const string ListViewId = "ListViewId";


	public override string Issue => "Shell Gestures Test";
	[Test]
	[Category(UITestCategories.Gestures)]
	public void SwipeGesture()
	{
		App.TapInShellFlyout(SwipeTitle);
		App.WaitForElement(SwipeGestureSuccessId);
		App.SwipeLeftToRight(SwipeGestureSuccessId);
#if IOS // On iOS, SwipeLeftToRight over the elements leads opens the flyout.
        App.Tap(SwipeTitle);
#endif
		Assert.That(App.WaitForElement(SwipeGestureSuccessId).GetText(), Is.EqualTo(SwipeGestureSuccess));
	}

	[Test]
	[Category(UITestCategories.TableView)]
	public void TableViewScroll()
	{
		App.TapInShellFlyout(TableViewTitle);
		App.WaitForElement(TableViewId);
		App.ScrollDown(TableViewId, ScrollStrategy.Gesture, 0.20, 200);
		App.WaitForElement("entry10");
	}

	[Test]
	[Category(UITestCategories.ListView)]
	public void ListViewScroll()
	{
		App.TapInShellFlyout(ListViewTitle);
		App.WaitForElement(ListViewId);
		App.ScrollDown(ListViewId, ScrollStrategy.Gesture, 0.20, 200);
		App.WaitForElement("10 Entry");
	}
}
#endif