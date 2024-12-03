#if TEST_FAILS_ON_WINDOWS
//When tap the button to go to the Tab 4, it shows the exception like a System.InvalidOperationException: 'Collection was modified; enumeration operation may not execute.'
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue4303 : _IssuesUITest
{
	public Issue4303(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[Android] TabbedPage's child is appearing before it should be";

	[Test]
	[Category(UITestCategories.LifeCycle)]
	public void Issue4303Test()
	{
		Assert.That(App.WaitForElement("lblAssert").GetText(), Is.EqualTo("Success"));
		App.WaitForElement("Go to Tab4");
		App.Tap("Go to Tab4");
		Assert.That(App.WaitForElement("lblChildAssert").GetText(), Is.EqualTo("ChildSuccess"));
	}
}
#endif