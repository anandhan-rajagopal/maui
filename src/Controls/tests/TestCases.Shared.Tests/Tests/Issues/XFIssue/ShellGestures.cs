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

	const string TouchListenerTitle = "IOnTouchListener";
	public const string TouchListenerSuccess = "TouchListener Success";
	const string TouchListenerSuccessId = "TouchListenerSuccessId";

	const string TableViewTitle = "Table View";
	const string TableViewId = "TableViewId";

	const string ListViewTitle = "List View";
	const string ListViewId = "ListViewId";


	public override string Issue => "Shell Gestures Test";
#if !ANDROID // Test fails on Android while swipe it closes the app
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
#endif

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

#if !ANDROID && !WINDOWS && !MACCATALYST && !IOS // This test case is only enabled for Android, but in the sample code, there is no logic to update the status to "Success" when a swipe action occurs.
	[Test]
	[Category(UITestCategories.CustomRenderers)]
	public void TouchListener()
	{
		App.TapInShellFlyout(TouchListenerTitle);
		App.WaitForElement(TouchListenerSuccessId);
		App.SwipeLeftToRight(TouchListenerSuccessId);
		App.WaitForElement(TouchListenerSuccess);
	}
#endif
}
#endif