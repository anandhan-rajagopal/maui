using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Issues
{
	[Issue(IssueTracker.Github, 21012, "Create test case for ShouldShowToolbarButton in FlyoutPage", PlatformAffected.All)]
	public class Issue21012 : TestFlyoutPage
	{
		protected override void Init()
		{
			// Set up the test pages
			var flyoutPage = new CustomFlyoutPage();

			// The test is embedded in the CustomFlyoutPage
			Flyout = flyoutPage.Flyout;
			Detail = flyoutPage.Detail;
			FlyoutLayoutBehavior = flyoutPage.FlyoutLayoutBehavior;
		}

		// Custom FlyoutPage implementation for testing ShouldShowToolbarButton behavior
		public class CustomFlyoutPage : FlyoutPage
		{
			private readonly Label _statusLabel;

			public CustomFlyoutPage()
			{
				// Create Flyout content
				var flyoutContent = new StackLayout
				{
					Margin = new Thickness(0, 20, 0, 0),
					Padding = new Thickness(10)
				};

				_statusLabel = new Label
				{
					Text = "Current Status: Not Tested",
					AutomationId = "StatusLabel",
					FontSize = 18,
					Margin = new Thickness(0, 0, 0, 20)
				};

				flyoutContent.Children.Add(new Label { Text = "Testing ShouldShowToolbarButton", FontSize = 20, FontAttributes = FontAttributes.Bold });
				flyoutContent.Children.Add(_statusLabel);
				
				// Test controls
				var testButton = new Button
				{
					Text = "Test ShouldShowToolbarButton Override",
					AutomationId = "TestButton"
				};
				testButton.Clicked += OnTestButtonClicked;
				flyoutContent.Children.Add(testButton);

				// Layout behavior controls
				var layoutBehaviorPicker = new Picker
				{
					Title = "FlyoutLayoutBehavior",
					AutomationId = "BehaviorPicker",
					Margin = new Thickness(0, 20, 0, 0)
				};
				layoutBehaviorPicker.ItemsSource = Enum.GetNames(typeof(FlyoutLayoutBehavior));
				layoutBehaviorPicker.SelectedIndex = 0; // Default
				layoutBehaviorPicker.SelectedIndexChanged += (sender, e) => 
				{
					FlyoutLayoutBehavior = Enum.Parse<FlyoutLayoutBehavior>(layoutBehaviorPicker.SelectedItem.ToString());
					UpdateStatus();
				};
				flyoutContent.Children.Add(layoutBehaviorPicker);
				
				// Create detail content
				var detailContent = new StackLayout
				{
					Padding = new Thickness(20)
				};

				detailContent.Children.Add(new Label
				{
					Text = "Issue #21012 - Testing ShouldShowToolbarButton",
					FontSize = 20,
					FontAttributes = FontAttributes.Bold
				});

				detailContent.Children.Add(new Label
				{
					Text = "This test verifies that the ShouldShowToolbarButton method in FlyoutPage works correctly across all platforms.\n\n" +
						   "The test checks that:\n" +
						   "1. The drawer toggle (hamburger icon) is shown or hidden based on the FlyoutLayoutBehavior\n" +
						   "2. When the ShouldShowToolbarButton is overridden, it correctly impacts the visibility\n" +
						   "3. The behavior works across all platforms\n\n" +
						   "Use the controls in the flyout menu to run the test.",
					Margin = new Thickness(0, 20, 0, 0)
				});

				var openFlyoutButton = new Button
				{
					Text = "Open Flyout",
					AutomationId = "OpenFlyoutButton",
					HorizontalOptions = LayoutOptions.Center,
					Margin = new Thickness(0, 20, 0, 0)
				};
				openFlyoutButton.Clicked += (sender, e) => IsPresented = true;
				detailContent.Children.Add(openFlyoutButton);

				// Set up the pages
				Flyout = new ContentPage
				{
					Title = "Test Controls",
					Content = flyoutContent
				};

				Detail = new NavigationPage(new ContentPage
				{
					Title = "Issue #21012",
					Content = detailContent
				});

				FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
			}

			private void OnTestButtonClicked(object sender, EventArgs e)
			{
				// Toggle ShouldShowToolbarButtonOverride
				ShouldShowToolbarButtonOverride = !ShouldShowToolbarButtonOverride;
				UpdateStatus();
			}

			private void UpdateStatus()
			{
				var actualBehavior = ShouldShowToolbarButton();
				_statusLabel.Text = $"Current Status:\n" +
								   $"FlyoutLayoutBehavior: {FlyoutLayoutBehavior}\n" +
								   $"Override Active: {ShouldShowToolbarButtonOverride}\n" +
								   $"ShouldShowToolbarButton(): {actualBehavior}";
			}

			// Flag to control override behavior
			public bool ShouldShowToolbarButtonOverride { get; private set; }

			// Override for testing
			public override bool ShouldShowToolbarButton()
			{
				// If override is active, return false to hide the button
				if (ShouldShowToolbarButtonOverride)
					return false;
				
				// Otherwise use the default implementation
				return base.ShouldShowToolbarButton();
			}
		}
	}
}
