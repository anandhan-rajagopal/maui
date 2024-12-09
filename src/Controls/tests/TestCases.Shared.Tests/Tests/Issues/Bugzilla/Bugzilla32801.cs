
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla32801 : _IssuesUITest
{
	public Bugzilla32801(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "Memory Leak in TabbedPage + NavigationPage";

	[Test]
    [Category(UITestCategories.TabbedPage)]
 
    public void Bugzilla32801Test()
    {
        App.WaitForElement("btnAdd");
        App.Tap("btnAdd");
        App.WaitForElement("btnAdd");
        App.Tap("btnAdd");
        App.WaitForElement("btnStack");
        App.Tap("btnStack");
        App.WaitForElement("Stack 3");
#if ANDROID
        App.Tap("TAB 1");
#else
        App.Tap("Tab 1");
#endif
        App.Tap("btnStack");
        App.WaitForElement("Stack 1");
    }
 
    [TearDown]
    public void TearDown()
    {
#if ANDROID
        App.SetOrientationPortrait();
#endif
    }
}
