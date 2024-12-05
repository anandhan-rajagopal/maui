using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
[Category(UITestCategories.Layout)]
public class Issue6932_emptyviewstring : _IssuesUITest
{
	public int Count = 10;
 
	public Issue6932_emptyviewstring(TestDevice testDevice) : base(testDevice)
	{
	}
	public string LayoutAutomationId { get => "StackLayoutThing"; }
	public string AddAutomationId { get => "Add"; }
	public string RemoveAutomationId { get => "Remove"; }
	public string ClearAutomationId { get => "Clear"; }
	public string EmptyViewAutomationId { get => "EmptyViewId"; }
	public string EmptyTemplateAutomationId { get => "EmptyTemplateId"; }
	public string EmptyViewStringDescription { get => "Nothing to see here"; }
 
	
	public override string Issue => "EmptyView for BindableLayout (string)";
 
	[Test]
 
	public void EmptyViewStringBecomesVisibleWhenItemsSourceIsCleared()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
		App.Tap(ClearAutomationId);
		App.WaitForElement(EmptyViewStringDescription);
 
		App.Screenshot("Empty view is visible");
	}
 
	[Test]
 
	public void EmptyViewStringBecomesVisibleWhenItemsSourceIsEmptiedOneByOne()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
 
		for (var i = 0; i < Count; i++)
			App.Tap(RemoveAutomationId);
 
		App.WaitForElement(EmptyViewStringDescription);
 
		App.Screenshot("Empty view is visible");
	}
 
	[Test]
 
	public void EmptyViewStringHidesWhenItemsSourceIsFilled()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
		App.Tap(ClearAutomationId);
		App.WaitForElement(EmptyViewStringDescription);
 
		App.Screenshot("Items are cleared, empty view visible");
 
		App.Tap(AddAutomationId);
		App.WaitForNoElement(EmptyViewStringDescription);
 
		App.Screenshot("Item is added, empty view is not visible");
	}
}