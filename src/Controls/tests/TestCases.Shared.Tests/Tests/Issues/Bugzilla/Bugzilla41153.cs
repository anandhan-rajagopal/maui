﻿#if TEST_FAILS_ON_ANDROID //System.NullReferenceException : Object reference not set to an instance of an object.
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Bugzilla41153 : _IssuesUITest
{
	public Bugzilla41153(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "jobject must not be IntPtr.Zero with TabbedPage and ToolbarItems";


	[Test]
	[Category(UITestCategories.TabbedPage)]
	public void Bugzilla41153Test()
	{
		App.WaitForElement("On Tab 1");
		App.Tap("Tab 2");
		App.Tap("Tab 3");
		App.WaitForElement("On Tab 3");
		App.Tap("Tab 1");
		App.WaitForElement("On Tab 1");
		App.Tap("Toolbar Item");

		App.WaitForTextToBePresentInElement("Toolbar Item", "Success");
	}
}
#endif