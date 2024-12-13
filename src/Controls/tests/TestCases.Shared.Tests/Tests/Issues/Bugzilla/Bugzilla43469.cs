#if TEST_FAILS_ON_CATALYST //The test fails on macOS because the alert box can only be opened a maximum of 5 times, while the test attempts to open it 6 times.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
public class Bugzilla43469 : _IssuesUITest
{
	#if MACCATALYST
		const string CancelBtn = "action-button--999";
	#else
		const string CancelBtn = "Cancel";
	#endif
    public Bugzilla43469(TestDevice testDevice) : base(testDevice)
    {
    }
 
    public override string Issue => "Calling DisplayAlert twice in WinRT causes a crash";
 
    [Test]
    [Category(UITestCategories.DisplayAlert)]
    public void Bugzilla43469Test()
    {
        App.WaitForElement("kButton");
        App.Tap("kButton");
        App.WaitForElement("First");
        TapCancel(CancelBtn);
        App.WaitForElement("Second");
        TapCancel(CancelBtn);
        App.WaitForElement("Three");
		for(int i=0; i<4; i++)
		{
			TapCancel(CancelBtn);
		}
        App.WaitForElement("kButton");
    }
    void TapCancel(string CancelBtn)
    {
    	App.WaitForElement(CancelBtn, timeout: TimeSpan.FromSeconds(2));
    	App.Tap(CancelBtn);
    }
}
#endif