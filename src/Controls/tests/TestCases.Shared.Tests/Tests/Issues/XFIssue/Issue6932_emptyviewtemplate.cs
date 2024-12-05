using NUnit.Framework;
using UITest.Appium;
using UITest.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;
 
namespace Microsoft.Maui.TestCases.Tests.Issues;
 
[Category(UITestCategories.Layout)]
public class Issue6932_emptyviewtemplate : _IssuesUITest
{
	public Issue6932_emptyviewtemplate(TestDevice testDevice) : base(testDevice)
	{
	}
	public int Count = 10;
	public override string Issue => "EmptyView for BindableLayout (template)";
	const string LayoutAutomationId = "StackLayoutThing"; 
	const string AddAutomationId = "Add";
	const string RemoveAutomationId = "Remove";
	const string ClearAutomationId = "Clear";
	const string EmptyTemplateAutomationId = "No items here";
	[Test]
 
	public void EmptyViewTemplateBecomesVisibleWhenItemsSourceIsCleared()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
		App.Tap(ClearAutomationId);
		App.WaitForElement(EmptyTemplateAutomationId);
 
		App.Screenshot("Empty view is visible");
	}
 
	[Test]
 
	public void EmptyViewTemplateBecomesVisibleWhenItemsSourceIsEmptiedOneByOne()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
 
		for (var i = 0; i < Count; i++)
		App.Tap(RemoveAutomationId);
 
		App.WaitForElement(EmptyTemplateAutomationId);
 
		App.Screenshot("Empty view is visible");
	}
 
	[Test]
 
	public void EmptyViewTemplateHidesWhenItemsSourceIsFilled()
	{
		App.Screenshot("Screen opens, items are shown");
 
#if !WINDOWS
		App.WaitForElement(LayoutAutomationId);
#endif
		App.Tap(ClearAutomationId);
		App.WaitForElement(EmptyTemplateAutomationId);
 
		App.Screenshot("Items are cleared, empty view visible");
 
		App.Tap(AddAutomationId);
		App.WaitForNoElement(EmptyTemplateAutomationId);
 
		App.Screenshot("Item is added, empty view is not visible");
	}
}