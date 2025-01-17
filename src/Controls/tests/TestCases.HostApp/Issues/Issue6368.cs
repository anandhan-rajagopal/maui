#if IOS
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using UIKit;
using CoreGraphics;
using static Maui.Controls.Sample.Issues.Issue6368.MainPage;
namespace Maui.Controls.Sample.Issues
{


	[Issue(IssueTracker.Github, 6368, "[CustomRenderer]Crash when navigating back from page with custom renderer control", PlatformAffected.iOS)]
	public class Issue6368 : NavigationPage
	{
		public Issue6368() : base(new MainPage())
		{
		}

		public class MainPage : ContentPage
		{
			public MainPage()
			{
				var rootPage = new ContentPage();
				var button = new Button()
				{
					AutomationId = "btnGo",
					Text = "Click me to go to the next page",
					Command = new Command(() => Navigation.PushAsync(new ContentPage()
					{
						Content = GetContent()
					}))
				};
				var content = GetContent();
				content.Children.Add(button);
				rootPage.Content = content;
				Navigation.PushAsync(rootPage);
			}

			public class CustomView : View
			{
			}

			public class RoundedLabel : Label
			{
			}

			static StackLayout GetContent()
			{
				var content2 = new StackLayout();
				content2.Children.Add(new RoundedLabel { AutomationId = "GoToNextPage", Text = "Go to next Page" });
				content2.Children.Add(new RoundedLabel { Text = "then navigate back" });
				content2.Children.Add(new RoundedLabel { Text = "If test doesn't crash it passed" });
				content2.Children.Add(new CustomView());
				return content2;
			}
		}

		public class CustomMauiLabel : MauiLabel
        {
            private UIEdgeInsets _edgeInsets = new(10, 5, 10, 5);
            private UIEdgeInsets _inverseEdgeInsets = new(-10, -5, -10, -5);

            public override CGRect TextRectForBounds(CGRect bounds, nint numberOfLines)
            {
                var textRect = base.TextRectForBounds(_edgeInsets.InsetRect(bounds), numberOfLines);
                return _inverseEdgeInsets.InsetRect(textRect);
            }

            public override void DrawText(CGRect rect)
            {
                base.DrawText(_edgeInsets.InsetRect(rect));
            }
        }

        public class RoundedLabelHandler : LabelHandler
        {
            public static PropertyMapper<MainPage.RoundedLabel, RoundedLabelHandler> PropertyMapper = new PropertyMapper<MainPage.RoundedLabel, RoundedLabelHandler>(LabelHandler.Mapper);

            public RoundedLabelHandler() : base(PropertyMapper)
            {
            }

            protected override MauiLabel CreatePlatformView()
            {
                var label = new CustomMauiLabel();
                
                label.Layer.CornerRadius = 10;
                label.Layer.BorderColor = UIColor.FromRGB(3, 169, 244).CGColor;
                label.Layer.BackgroundColor = Colors.GhostWhite.ToCGColor();
                label.Layer.BorderWidth = 1;
                
                return label;
            }
        }

        public class CustomViewHandler : ViewHandler<MainPage.CustomView, UIView>
        {
            public static PropertyMapper<MainPage.CustomView, CustomViewHandler> PropertyMapper = new PropertyMapper<MainPage.CustomView, CustomViewHandler>(ViewHandler.ViewMapper);

            public CustomViewHandler() : base(PropertyMapper)
            {
            }

            protected override UIView CreatePlatformView()
            {
                return new UIView();
            }
        }
	}
}
#endif