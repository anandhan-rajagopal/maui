#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS //TimeoutException - DataTemplate
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
	[FailsOnAndroidWhenRunningOnXamarinUITest]
	public void Issue2794Test()
	{
		App.TouchAndHold("Cell2");
		App.Tap("Delete me first");
		App.WaitForNoElement("Cell2");

		App.TouchAndHold("Cell1");
		App.Tap("Delete me after");
		App.WaitForNoElement("Cell1");
	}
}
