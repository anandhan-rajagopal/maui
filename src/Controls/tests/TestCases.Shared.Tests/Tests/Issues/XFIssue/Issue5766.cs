#if TEST_FAILS_ON_WINDOWS && TEST_FAILS_ON_CATALYST //Scroll not working on catalyst , sometimes fail on Android, In IOS it will take more than 100 seconds to run, In windows it will application still running (crash) but it works fine on sample 
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue5766 : _IssuesUITest
{
	public Issue5766(TestDevice testDevice) : base(testDevice)
	{
	}
	const string StartText1 = "start1";
	const string BigText1 = "big string > big frame1";
	const string SmallText1 = "s1";
	const string List1 = "lst1";

	const string StartText2 = "start2";
	const string BigText2 = "big string > big frame2";
	const string SmallText2 = "s2"; 
	const string List2 = "lst2";

	public override string Issue => "Frame size gets corrupted when ListView is scrolled";

	[Test]
	[Category(UITestCategories.Layout)]

	public void FrameSizeGetsCorruptedWhenListViewIsScrolled()
	{
		var start = App.WaitForElement(StartText1).GetRect();
		var smalls = App.WaitForElement(SmallText1).GetRect();
		var bigs = App.WaitForElement(BigText1).GetRect();

		 
		App.ScrollDown(List1);    
		App.ScrollUp(List1);   

		var startAfter = App.WaitForElement(StartText1).GetRect();
		var smallAfter = App.WaitForElement(SmallText1).GetRect();
		var bigAfter = App.WaitForElement(BigText1).GetRect();

		Assert.That(start.Width, Is.EqualTo(startAfter.Width));
		Assert.That(start.Height, Is.EqualTo(startAfter.Height));

		Assert.That(smalls.Width, Is.EqualTo(smallAfter.Width));
		Assert.That(smalls.Height, Is.EqualTo(smallAfter.Height));

		Assert.That(bigs.Width, Is.EqualTo(bigAfter.Width));
		Assert.That(bigs.Height, Is.EqualTo(bigAfter.Height));

		start = App.WaitForElement(StartText2).GetRect();
		smalls = App.WaitForElement(SmallText2).GetRect();
		bigs = App.WaitForElement(BigText2).GetRect();

		 
		App.ScrollDown(List2);   
		App.ScrollUp(List2);  

		var startAfterList2 = App.WaitForElement(StartText2).GetRect();
		var smallAfterList2 = App.WaitForElement(SmallText2).GetRect();
		var bigAfterList2 = App.WaitForElement(BigText2).GetRect();

		Assert.That(start.Width, Is.EqualTo(startAfterList2.Width));
		Assert.That(start.Height, Is.EqualTo(startAfterList2.Height));

		Assert.That(smalls.Width, Is.EqualTo(smallAfterList2.Width));
		Assert.That(smalls.Height, Is.EqualTo(smallAfterList2.Height));

		Assert.That(bigs.Width, Is.EqualTo(bigAfterList2.Width));
		Assert.That(bigs.Height, Is.EqualTo(bigAfterList2.Height));
	}
}
#endif


