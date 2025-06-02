using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Issues
{
	// This test case is specifically for verifying that the fix in PR #18522 works correctly
	// Issue #15111 reported that overriding ShouldShowToolbarButton() in FlyoutPage was not hiding 
	// the hamburger icon (drawer toggle) on Android when it returned false
	[Issue(IssueTracker.Github, 21012, "Verify ShouldShowToolbarButton hides drawer toggle in NavigationPageToolbar", PlatformAffected.Android)]
	public class Issue21012_DrawerToggle : TestFlyoutPage
	{
		protected override void Init()
		{
			// Create a FlyoutPage with NavigationPage as Detail that overrides ShouldShowToolbarButton
			var flyoutPage = new CustomFlyoutPageNoToggle();
			
			Flyout = flyoutPage.Flyout;
			Detail = flyoutPage.Detail;
			FlyoutLayoutBehavior = flyoutPage.FlyoutLayoutBehavior;
		}
		
		// This custom FlyoutPage always returns false from ShouldShowToolbarButton
		// which should hide the drawer toggle on all platforms
		public class CustomFlyoutPageNoToggle : FlyoutPage
		{
			public CustomFlyoutPageNoToggle()
			{
				// Create Flyout content
				var flyoutContent = new StackLayout
				{
					Padding = new Thickness(20)
				};

				flyoutContent.Children.Add(new Label 
				{ 
					Text = "ShouldShowToolbarButton Test", 
					FontSize = 24, 
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				});

				flyoutContent.Children.Add(new Label
				{
					Text = "This test verifies that when ShouldShowToolbarButton returns false, " +
						   "the drawer toggle (hamburger menu) is hidden on all platforms.",
					Margin = new Thickness(0, 20, 0, 0)
				});

				// Create detail content with instructions
				var detailContent = new StackLayout
				{
					Padding = new Thickness(20)
				};

				detailContent.Children.Add(new Label
				{
					Text = "Issue #21012 Test",
					FontSize = 24,
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				});

				detailContent.Children.Add(new Label
				{
					Text = "This test verifies the fix for GitHub issue #15111:\n\n" +
						   "When ShouldShowToolbarButton() is overridden to return false, " +
						   "the hamburger icon (drawer toggle) should be hidden on all platforms, including Android.\n\n" +
						   "VERIFICATION:\n" +
						   "1. You should NOT see a hamburger icon in the toolbar on any platform\n" +
						   "2. The flyout can still be opened with the button below",
					Margin = new Thickness(0, 20, 0, 0)
				});

				// Button to show flyout (since the hamburger menu is hidden)
				var showFlyoutButton = new Button
				{
					Text = "Open Flyout",
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(0, 20, 0, 0),
					AutomationId = "OpenFlyoutButton"
				};
				showFlyoutButton.Clicked += (sender, e) => IsPresented = true;
				detailContent.Children.Add(showFlyoutButton);
				
				// Button to push a page to test with multiple pages in stack
				var pushPageButton = new Button
				{
					Text = "Push Page",
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(0, 20, 0, 0),
					AutomationId = "PushPageButton"
				};

				pushPageButton.Clicked += async (sender, e) => 
				{
					var newPage = new ContentPage
					{
						Title = "Pushed Page",
						Content = new StackLayout
						{
							Padding = new Thickness(20),
							Children =
							{
								new Label
								{
									Text = "Pushed Page",
									FontSize = 24,
									FontAttributes = FontAttributes.Bold,
									HorizontalOptions = LayoutOptions.Center
								},
								new Label
								{
									Text = "Even with pages in the navigation stack, the drawer toggle should remain hidden because ShouldShowToolbarButton returns false.",
									Margin = new Thickness(0, 20, 0, 0)
								},
								new Button
								{
									Text = "Open Flyout",
									HorizontalOptions = LayoutOptions.Center,
									Margin = new Thickness(0, 20, 0, 0),
									Command = new Command(() => IsPresented = true)
								}
							}
						}
					};
					
					await ((NavigationPage)Detail).PushAsync(newPage);
				};
				
				detailContent.Children.Add(pushPageButton);

				// Toggle ShouldShowToolbarButton override
				var toggleOverrideButton = new Button
				{
					Text = "Toggle ShouldShowToolbarButton Override",
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(0, 20, 0, 0),
					AutomationId = "ToggleOverrideButton"
				};
				
				toggleOverrideButton.Clicked += (sender, e) => 
				{
					_shouldHideToolbarButton = !_shouldHideToolbarButton;
					toggleOverrideButton.Text = _shouldHideToolbarButton ? 
						"Override: Hiding Drawer Toggle" : 
						"Override: Showing Drawer Toggle";
				};
				
				detailContent.Children.Add(toggleOverrideButton);
				
				// Current status label
				var statusLabel = new Label
				{
					Text = "Override active: Drawer toggle should be hidden",
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(0, 20, 0, 0),
					AutomationId = "StatusLabel"
				};
				
				detailContent.Children.Add(statusLabel);

				// Set up the pages
				Flyout = new ContentPage
				{
					Title = "Flyout",
					Content = flyoutContent
				};

				Detail = new NavigationPage(new ContentPage
				{
					Title = "Issue #21012",
					Content = detailContent
				});

				// Set to Popover initially to show the drawer toggle on all device types
				FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
			}

			private bool _shouldHideToolbarButton = true;

			// This override is the key part of the test - we're verifying
			// that returning false here correctly hides the drawer toggle
			// on all platforms, including Android
			public override bool ShouldShowToolbarButton()
			{
				if (_shouldHideToolbarButton)
				{
					return false;
				}
				
				return base.ShouldShowToolbarButton();
			}
		}
	}
}
