using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Issues
{
    [Issue(IssueTracker.Github, 28140, "Keyboard Scrolling Crash", PlatformAffected.iOS)]
    public class Issue28140 : NavigationPage
    {
        public Issue28140() : base(new MainPage())
        {
        }

        public class MainPage : ContentPage
        {
            private Entry _entry;
            private Button _button;
            private ScrollView _scrollView;

            public MainPage()
            {
                var stackLayout = new StackLayout();

                _button = new Button
                {
                    Text = "Crash Test Button",
                    Command = new Command(CrashConditionTest),
                    AutomationId = "CrashConditionTest"
                };
                _entry = new Entry
                {
                    AutomationId = "Entry",
                    Placeholder = "Tap to enter text",
                };

                stackLayout.Children.Add(_entry);
                stackLayout.Children.Add(_button);

                for (int i = 1; i <= 40; i++)
                {
                    stackLayout.Children.Add(new Label
                    {
                        Text = $"Label {i}",
                        FontSize = 24
                    });
                }

                _scrollView = new ScrollView
                {
                    Content = stackLayout
                };
                Content = _scrollView;
            }

            // This method tries to hit the exact timing window where the crash occurs
            private async void CrashConditionTest()
            {
                for (int i = 0; i < 10; i++)
                {
                    // Focus entry to show keyboard
                    _entry.Focus();
                    
                    var newPage = new NewPage();
                    await Navigation.PushAsync(newPage);

                    // Wait briefly then pop back
                    await Task.Delay(50);
                    await Navigation.PopAsync();
                }

            }
        }

        public class NewPage : ContentPage
        {
            public NewPage()
            {
                Content = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Children =
                        {
                            new Label
                            {
                                Text = "Navigation successful!",
                                FontSize = 24,
                                HorizontalOptions = LayoutOptions.Center
                            },
                        }
                    }
                };
            }
        }
    }
}