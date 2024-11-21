#if TEST_FAILS_ON_IOS && TEST_FAILS_ON_CATALYST //application crash wile tap the viewcell: in iOS:The app was expected to be running still, investigate as possible crash && in mac:System.NullReferenceException : Object reference not set to an instance of an object.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla47923 : _IssuesUITest
{
	public Bugzilla47923(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Vectors don't work in Images, and work badly in Buttons";


	[Test]
	[Category(UITestCategories.Button)]
	public void Bugzilla47923Test()
	{
		foreach (var testString in new[] { "AspectFit", "AspectFill", "Fill", "Test cell views" })
		{
			App.WaitForElement(testString);
			App.Tap(testString);
			App.TapBackArrow();
#if IOS
			App.Back();
#endif
		}
	}
}
#endif