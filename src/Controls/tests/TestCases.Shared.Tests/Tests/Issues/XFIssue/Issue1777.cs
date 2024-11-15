#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS //TimeoutException - testO element
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue1777 : _IssuesUITest
{
	public Issue1777(TestDevice testDevice) : base(testDevice)
	{
	}

	const string _pickerTableId = "pickerTableId";
	const string _btnText = "do magic";

	public override string Issue => "Adding picker items when picker is in a ViewCell breaks";

	[Test]
	[Category(UITestCategories.TableView)]
	public void Issue1777Test()
	{
		App.WaitForElement(_btnText);
		App.Tap(_btnText);
		App.Tap(_pickerTableId);
		App.WaitForElement("test 0");
	}
}
#endif