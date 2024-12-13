#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS // It throws Exception System.InvalidCastException: 'Unable to cast object of type 'Microsoft.Maui.Controls.Page' to type 'Microsoft.Maui.IContentView, Issue: https://github.com/dotnet/maui/issues/21205 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Bugzilla41842 : _IssuesUITest
	{
		public Bugzilla41842(TestDevice testDevice) : base(testDevice)
		{
		}

		public override string Issue => "Set FlyoutPage.Detail = New Page() twice will crash the application when set FlyoutLayoutBehavior = FlyoutLayoutBehavior.Split";

		 
		[Test]
		[Category(UITestCategories.FlyoutPage)]
		public void Bugzilla41842Test()
		{
			App.WaitForElement("Success");
		}
		
	}
}
#endif