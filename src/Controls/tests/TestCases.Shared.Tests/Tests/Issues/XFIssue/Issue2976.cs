using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue2976 : _IssuesUITest
{
	public Issue2976(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Sample 'WorkingWithListviewNative' throw Exception on Xam.Android project.";

	[Test]
	[Category(UITestCategories.ListView)]
	public void Issue1Test()
	{
		App.WaitForElement("DEMOA");
		App.Tap("DEMOA");
		App.WaitForElement("DEMOB");
		App.Tap("DEMOB");
		App.WaitForElement("DEMOC");
		App.Tap("DEMOC");
		App.WaitForElement("DEMOD");
		App.Tap("DEMOD");
	}
}