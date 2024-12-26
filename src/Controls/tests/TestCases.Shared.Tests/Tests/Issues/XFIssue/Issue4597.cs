using NUnit.Framework;
using UITest.Appium;
using UITest.Core;

namespace Microsoft.Maui.TestCases.Tests.Issues;

[Category(UITestCategories.Cells)]
public class Issue4597 : _IssuesUITest
{


	public Issue4597(TestDevice testDevice) : base(testDevice)
	{
	}


	string _appearText = "Clicking this should cause the image to reappear";
	string _theListView = "theListViewAutomationId";
	string _nextTestId = "NextTest";
	string _switchUriId = "SwitchUri";
	string _imageFromUri = "Image From Uri";
	string _imageFromFile = "Image From File";
	string _ButtonAutomationId = "Button";
	string _fileNameAutomationId = "Image";
	string _imageButtonAutomationId = "ImageButton";

	public override string Issue => "[Android] ImageCell not loading images and setting ImageSource to null has no effect";

	[Test, Order(1)]
	public void ImageFromFileSourceAppearsAndDisappearsCorrectly()
	{
		App.WaitForElement(_nextTestId);
		VerifySourceLabel(_imageFromFile);
		var imageElements = App.FindElements(_fileNameAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_fileNameAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(0));// windows and mac=1
	}

	[Test, Order(2)]
	public void ImageFromUriSourceAppearsAndDisappearsCorrectly()
	{
		ToggleUriSource();
		App.WaitForElementTillPageNavigationSettled(_fileNameAutomationId);
		var imageElements = App.FindElements(_fileNameAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		VerifySourceLabel(_imageFromUri);
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_fileNameAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(0)); //windows and mac count=1
	}

	[Test, Order(3)]
	public void ButtonFromFileSourceAppearsAndDisappearsCorrectly()
	{
		ToggleUriSource();
		WaitForNextTest();
		VerifySourceLabel(_imageFromFile);
		var imageElements = App.FindElements(_ButtonAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_ButtonAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(1));//mac=2
	}


	[Test, Order(4)]
	public void ButtonFromUriSourceAppearsAndDisappearsCorrectly()
	{

		ToggleUriSource();
		App.WaitForElementTillPageNavigationSettled(_ButtonAutomationId);
		var imageElements = App.FindElements(_ButtonAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		VerifySourceLabel(_imageFromUri);
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_ButtonAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(1));//mac=2
	}


	[Test, Order(5)]
	public void ImageButtonFromFileSourceAppearsAndDisappearsCorrectly()
	{
		ToggleUriSource();
		WaitForNextTest();
		VerifySourceLabel(_imageFromFile);
		var imageElements = App.FindElements(_imageButtonAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_imageButtonAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(0));//windows =1, ios=1, mac=2
	}


	[Test, Order(6)]
	public void ImageButtonFromUriSourceAppearsAndDisappearsCorrectly()
	{
		ToggleUriSource();
		App.WaitForElementTillPageNavigationSettled(_imageButtonAutomationId);
		var imageElements = App.FindElements(_imageButtonAutomationId);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		VerifySourceLabel(_imageFromUri);
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_imageButtonAutomationId);
		Assert.That(imageElements.Count, Is.EqualTo(0));//ios=1,windows=1, mac=2
	}


	[Test, Order(7)]
	public void ImageCellFromFileSourceAppearsAndDisappearsCorrectly()
	{
		ToggleUriSource();
		WaitForNextTest();
		VerifySourceLabel(_imageFromFile);
		var imageElements = App.FindElements(_theListView);
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_theListView);
		Assert.That(imageElements.Count, Is.EqualTo(1));
	}

	//throws exception in android
	[Test, Order(8)]
	public void ImageCellFromUriSourceAppearsAndDisappearsCorrectly()
	{

		ToggleUriSource();
		var imageElements = App.FindElements(_theListView); //couldn't able to get automationid for listview image, so i get lsistview automationid
		Assert.That(imageElements.Count, Is.GreaterThan(0));
		VerifySourceLabel(_imageFromUri);
		App.Tap("ClickMe");
		App.WaitForElement(_appearText);
		imageElements = App.FindElements(_theListView);
		Assert.That(imageElements.Count, Is.EqualTo(1));
	}
	private void VerifySourceLabel(string expectedText)
	{
		var sourceLabelElement = App.WaitForElement("SourceLabel");
		string sourceLabel = sourceLabelElement?.GetText() ?? string.Empty;
		Assert.That(sourceLabel, Is.EqualTo(expectedText));
	}
	private void WaitForNextTest()
	{
		App.WaitForElement(_nextTestId);
		App.Tap(_nextTestId);
	}

	private void ToggleUriSource()
	{
		App.WaitForElement(_switchUriId);
		App.Tap(_switchUriId);
	}

}