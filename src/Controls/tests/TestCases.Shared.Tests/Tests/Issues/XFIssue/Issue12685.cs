#if TEST_FAILS_ON_WINDOWS
using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

public class Issue12685 : _IssuesUITest
{
	const string StatusLabelId = "StatusLabelId";
	const string PathId = "PathId";
	const string ResetStatus = "Path touch event not fired, touch path above.";
	const string ClickedStatus = "Path was clicked, click reset button to start over.";
	public Issue12685(TestDevice testDevice) : base(testDevice)
	{
	}

	public override string Issue => "[iOs][Bug] TapGestureRecognizer in Path does not work on iOS";

	[Test]
	[Category(UITestCategories.Shape)]
	public void ShapesPathReceiveGestureRecognizers()
	{
		var testLabel = App.WaitForFirstElement(StatusLabelId);
		Assert.That(testLabel.ReadText(), Is.EqualTo(ResetStatus));
		var testPath = App.WaitForFirstElement(PathId);
		var pathRect = testPath.GetRect();
#if MACCATALYST
		App.ClickCoordinates(pathRect.X + 3, pathRect.Y + 3);
#else
		App.TapCoordinates(pathRect.X + 1, pathRect.Y + 1);
#endif
		Assert.That(testLabel.ReadText(), Is.EqualTo(ClickedStatus));
	}
}
#endif