#if TEST_FAILS_ON_IOS //In IOS platform,Issue31333FocusEditorInTableViewCell test case was failed
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
using System.Diagnostics;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	[Category(UITestCategories.TableView)]
	public class Bugzilla31333 : _IssuesUITest
	{
		public Bugzilla31333(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Focus() on Entry in ViewCell brings up keyboard, but doesn't have cursor in EditText";

		[Test]
		public void Issue31333FocusEntryInListViewCell()
		{
			App.Tap("Focus Entry in ListView");
			WaitForFocus();

			App.EnterText("EntryListView", "Entry in ListView Success");

			WaitForTextQuery("EntryListView", "Entry in ListView Success");

			App.Tap("Focus Entry in ListView");
		}

		[Test]
		public void Issue31333FocusEditorInListViewCell()
		{
			App.Tap("Focus Editor in ListView");
			WaitForFocus();

			App.EnterText("EditorListView", "Editor in ListView Success");

			WaitForTextQuery("EditorListView", "Editor in ListView Success");

			App.Tap("Focus Editor in ListView");
		}

		[Test]
		public void Issue31333FocusEntryInTableViewCell()
		{
			App.Tap("Focus Entry in Table");
			WaitForFocus();

			App.EnterText("EntryTable", "Entry in TableView Success");

			WaitForTextQuery("EntryTable", "Entry in TableView Success");

			App.Tap("Focus Entry in Table");
		}

		[Test]
		public void Issue31333FocusEditorInTableViewCell()
		{
			App.Tap("Focus Editor in Table");
			WaitForFocus();

			App.EnterText("EditorTable", "Editor in TableView Success");

			WaitForTextQuery("EditorTable", "Editor in TableView Success");

			App.Tap("Focus Editor in Table");
		}

		private void WaitForFocus()
		{
			Task.Delay(1000).Wait();
		}

		void WaitForTextQuery(string automationId, string expectedText)
		{
			var watch = new Stopwatch();
			watch.Start();
			bool textFound = false;

			while (watch.ElapsedMilliseconds < 5000 && !textFound)
			{
					var element = App.FindElement(automationId).GetText();
					if (element != null)
					{
						var text = element;
						if (text == expectedText)
						{
							textFound = true;
							break;
						}
					}		

				Task.Delay(500).Wait();
			}

			watch.Stop();
			Assert.That(textFound, Is.True, $"Failed to find text '{expectedText}'");
		}
	}
}
#endif