#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST
//In MacCatalyst, Timeout Exception in the label. And in Windows platform, it throws the NullReferenceException.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;
public class Issue3788 : _IssuesUITest
{
	public Issue3788(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[UWP] ListView with observable collection always seems to refresh the entire list";

	[Test]
	[Category(UITestCategories.ListView)]
	public void ReplaceItemScrollsListToTop()
	{
		App.WaitForElement("Replace Me");
		App.Tap("Scroll down and click me");
		App.WaitForElement("Last");
	}
}
#endif