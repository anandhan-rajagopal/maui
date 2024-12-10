using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

namespace Maui.Controls.Sample.Issues;

[Issue(IssueTracker.Github, 4138, "[iOS] NavigationPage.TitleIcon no longer centered", PlatformAffected.iOS)]
public class Issue4138 : TestNavigationPage
{
	protected override void Init()
	{
		ContentPage contentPage = new ContentPage();
		var imageSource = new FileImageSource()
				{
					File = "coffee.png",
					AutomationId = "CoffeeAutomation"
				};
		NavigationPage.SetTitleIconImageSource(contentPage, imageSource);

		PushAsync(contentPage);
	}
}