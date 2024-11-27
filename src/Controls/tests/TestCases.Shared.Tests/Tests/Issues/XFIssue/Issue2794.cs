//#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //TimeoutException - DataTemplate
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2794 : _IssuesUITest
{
	public Issue2794(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "TableView does not react on underlying collection change";

	[Test]
	[Category(UITestCategories.TableView)]
	public void Issue2794Test()
	{
		App.WaitForElement("Cell2");
#if MACCATALYST
		App.LongPress("Cell2");
#else
		App.TouchAndHold("Cell2");
#endif
		App.WaitForElement("Delete me first");
		App.Tap("Delete me first");
		App.WaitForNoElement("Cell2");

#if MACCATALYST
		App.LongPress("Cell1");
#else
		App.TouchAndHold("Cell1");
#endif
		App.WaitForElement("Delete me first");
		App.Tap("Delete me after");
		App.WaitForNoElement("Cell1");
	}
}
