using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla43663 : _IssuesUITest
{

	public Bugzilla43663(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "ModalPushed and ModalPopped not working on WinRT";

	[Test]
	[Category(UITestCategories.Navigation)]
	public void ModalNavigation()
	{
		App.WaitForElement("Click to push Modal");
		App.Tap("Click to push Modal");
# if !MACCATALYST
		App.WaitForElement("Cancel");
		App.Tap("Cancel");
		App.WaitForElement("Modal");
		App.Tap("Click to dismiss modal");
		App.WaitForElement("Cancel");		
		App.Tap("Cancel");
#else
		App.WaitForElement("action-button--999");
    	App.Tap("action-button--999");
		App.WaitForElement("Modal");
		App.Tap("Click to dismiss modal");
		App.WaitForElement("action-button--999");
    	App.Tap("action-button--999");
#endif	
		App.WaitForElement("Click to push Modal");	
	}
}