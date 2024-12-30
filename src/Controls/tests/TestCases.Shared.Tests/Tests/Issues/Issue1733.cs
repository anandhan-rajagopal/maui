#if TEST_FAILS_ON_ANDROID && TEST_FAILS_ON_CATALYST && TEST_FAILS_ON_IOS && TEST_FAILS_ON_WINDOWS 
#nullable disable
using System.Drawing;
using System.Globalization;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues
{
	public class Issue1733 : _IssuesUITest
	{
		public Issue1733(TestDevice testDevice) : base(testDevice)
		{
		}
 
		public override string Issue => "Autoresizable Editor";
 
			
		Dictionary<string, Size> _results;
 
		const string EditorHeightShrinkWithPressureId = "editorHeightShrinkWithPressureId";
		const string EditorHeightGrowId = "editorHeightGrowId";
		const string EditorWidthGrow1Id = "editorWidthGrow1Id";
		const string EditorWidthGrow2Id = "editorWidthGrow2Id";
		const string BtnChangeFontToDefault = "Change the Font to Default";
		const string BtnChangeFontToLarger = "Change the Font to Larger";
		const string BtnChangeToHasText = "Change to Has Text";
		const string BtnChangeToNoText = "Change to Has No Text";
		const string BtnChangeSizeOption = "Change the Size Option";
 
		[Test]
		[Category(UITestCategories.Editor)]
		[Category(UITestCategories.Compatibility)]
 
		public void EditorAutoResize()
		{
			
 
			string[] editors = new string[] { EditorHeightShrinkWithPressureId, EditorHeightGrowId, EditorWidthGrow1Id, EditorWidthGrow2Id };
			App.WaitForElement(EditorHeightShrinkWithPressureId);
 
			_results = new Dictionary<string, Size>();
 
			foreach (var editor in editors)
			{
				_results.Add(editor, GetDimensions(editor));
			}
 
			App.Tap(BtnChangeToHasText);
			App.WaitForElement(BtnChangeToNoText);
			TestGrowth(false);
			App.Tap(BtnChangeFontToLarger);
			App.WaitForElement(BtnChangeFontToDefault);
			TestGrowth(true);
 
			// Reset back to being empty and make sure everything sets back to original size
			App.Tap(BtnChangeFontToDefault);
			App.Tap(BtnChangeToNoText);
			App.WaitForElement(BtnChangeToHasText);
			App.WaitForElement(BtnChangeFontToLarger);
 
			foreach (var editor in editors)
			{
				var allTheSame = GetDimensions(editor);
				ClassicAssert.AreEqual(allTheSame.Width, _results[editor].Width, editor);
				ClassicAssert.AreEqual(allTheSame.Height, _results[editor].Height, editor);
			}
 
			// This sets it back to not auto size and we click everything again to see if it grows
			App.Tap(BtnChangeSizeOption);
			App.Tap(BtnChangeFontToLarger);
			App.Tap(BtnChangeToHasText);
			App.WaitForElement(BtnChangeFontToDefault);
			App.WaitForElement(BtnChangeToNoText);
			foreach (var editor in editors)
			{
				var allTheSame = GetDimensions(editor);
				Assert.That(_results[editor].Width, Is.EqualTo(allTheSame.Width), editor);
				Assert.That(_results[editor].Height, Is.EqualTo(allTheSame.Height), editor);
			}
		}
 
		void TestGrowth(bool heightPressureShrink)
		{
			var testSizes = GetDimensions(EditorHeightShrinkWithPressureId);
			Assert.That(_results[EditorHeightShrinkWithPressureId].Width, Is.EqualTo(testSizes.Width), EditorHeightShrinkWithPressureId);
 
			if (heightPressureShrink)
				Assert.That(_results[EditorHeightShrinkWithPressureId].Height, Is.LessThan(testSizes.Height), EditorHeightShrinkWithPressureId);
			else
				Assert.That(_results[EditorHeightShrinkWithPressureId].Height, Is.GreaterThan(testSizes.Height), EditorHeightShrinkWithPressureId);
 
			testSizes = GetDimensions(EditorHeightGrowId);
			Assert.That(_results[EditorHeightGrowId].Width, Is.EqualTo(testSizes.Width), EditorHeightGrowId);
			Assert.That(_results[EditorHeightGrowId].Height, Is.LessThan(testSizes.Height), EditorHeightGrowId);
 
			var grow1 = GetDimensions(EditorWidthGrow1Id);
			Assert.That(_results[EditorWidthGrow1Id].Width, Is.LessThan(grow1.Width), EditorWidthGrow1Id);
			Assert.That(_results[EditorWidthGrow1Id].Height, Is.LessThan(grow1.Height), EditorWidthGrow1Id);
 
			var grow2 = GetDimensions(EditorWidthGrow2Id);
			Assert.That(_results[EditorWidthGrow2Id].Width, Is.LessThan(grow2.Width), EditorWidthGrow2Id);
			Assert.That(_results[EditorWidthGrow2Id].Height, Is.LessThan(grow2.Height), EditorWidthGrow2Id);
 
 
			// Grow 1 has a lower minimum width request so it's width should be smaller than grow 2
			Assert.That(grow2.Width, Is.GreaterThan(grow1.Width), "grow2.Width > grow1.Width");
		}
 
		Size GetDimensions(string editorName)
	{
		App.WaitForElement($"{editorName}_height");
		App.WaitForElement($"{editorName}_width");

		var height = App.WaitForElement($"{editorName}_height").GetText();
		var width = App.WaitForElement($"{editorName}_width").GetText();

		if (height == null)
		{
			throw new ArgumentException($"{editorName}_height not found");
		}
		if (width == null)
		{
			throw new ArgumentException($"{editorName}_width not found");
		}

		// Parse height and width as float first, then round/truncate to integer
		var heightValue = Convert.ToDouble(height, CultureInfo.InvariantCulture);
		var widthValue = Convert.ToDouble(width, CultureInfo.InvariantCulture);

		// Round the values to the nearest integer (or you can use Math.Floor or Math.Ceiling if you prefer)
		return new Size((int)Math.Round(widthValue), (int)Math.Round(heightValue));
	}

	}
}
#endif