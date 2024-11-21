using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla40161 : _IssuesUITest
{
	public Bugzilla40161(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Issue Bugzilla40161";

	[Test]
	[Category(UITestCategories.Layout)]
	public void Issue1Test()
	{
		App.WaitForElement("REFRESH");

		App.Tap("SWAP");
		App.Tap("REFRESH");

		App.WaitForElement("step=0");
		App.WaitForElement("w=1008");
	}
}