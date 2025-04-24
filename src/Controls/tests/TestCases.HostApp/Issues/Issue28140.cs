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
            private Label _label;
            private Entry _entry;
            private Button _button;
            private ScrollView _scrollView;

            public MainPage()
            {
                Title = "Test for Issue #28140";

                var stackLayout = new StackLayout();

                _label = new Label
                {
                    Text = "This test case tries to reproduce the keyboard dismissal crash in issue #28140",
                    LineBreakMode = LineBreakMode.WordWrap
                };
                _button = new Button
                {
                    Text = "Crash Test Button",
                    Command = new Command(CrashConditionTest),
                    AutomationId = "RaceConditionTest"
                };
                _entry = new Entry
                {
                    AutomationId = "Entry",
                    Placeholder = "Tap to enter text",
                    Text = "Type something here"
                };

                stackLayout.Children.Add(_label);
                stackLayout.Children.Add(_button);
                stackLayout.Children.Add(_entry);

                for (int i = 1; i <= 20; i++)
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
                _entry.Focus();
                await Task.Delay(1000);
                var newPage = new NewPage();
                await Navigation.PushAsync(newPage);
            }
        }

        public class NewPage : ContentPage
        {
            private bool _pageRemoved = false;
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
                            new Button
                            {
                                Text = "Remove Previous Page",
                                IsEnabled = !_pageRemoved,
                                Command = new Command((sender) => {
                                    RemovePreviousPage();
                                    ((Button)sender).IsEnabled = false;
                                    _pageRemoved = true;
                                })
                            },
                        }
                    }
                };
            }

            private void RemovePreviousPage()
            {
                if (Navigation.NavigationStack.Count > 1)
                {
                    var previousPage = Navigation.NavigationStack[Navigation.NavigationStack.Count - 2];
                    Navigation.RemovePage(previousPage);
                }
            }
        }
    }
}