using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
#if IOS || MACCATALYST
using UIKit;
using CoreGraphics;
using static Maui.Controls.Sample.Issues.Issue6368.MainPage;
#elif ANDROID
using Android.Graphics.Drawables;
#endif
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
#if IOS || MACCATALYST
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
#endif

#if ANDROID
public class RoundedLabelHandler : LabelHandler
{
    public static PropertyMapper<MainPage.RoundedLabel, RoundedLabelHandler> PropertyMapper = 
        new PropertyMapper<MainPage.RoundedLabel, RoundedLabelHandler>(LabelHandler.Mapper);

    public RoundedLabelHandler() : base(PropertyMapper)
    {
    }

    protected override MauiTextView CreatePlatformView()
    {
        var textView = new MauiTextView(Context);

        // Set text properties
        textView.SetTextColor(Android.Graphics.Color.Black);
        textView.TextAlignment = Android.Views.TextAlignment.Center;
        textView.Gravity = Android.Views.GravityFlags.Center;
        textView.SetTextSize(Android.Util.ComplexUnitType.Sp, 16);

        // Set padding (convert dp to pixels)
        float density = Context.Resources.DisplayMetrics.Density;
        int paddingHorizontal = (int)(5 * density);
        int paddingVertical = (int)(10 * density);
        textView.SetPadding(paddingHorizontal, paddingVertical, paddingHorizontal, paddingVertical);

        // Create rounded background drawable
        var shape = new GradientDrawable();
        shape.SetShape(ShapeType.Rectangle);
        shape.SetCornerRadius(30f);
        shape.SetStroke(3, Android.Graphics.Color.Rgb(3, 169, 244));
        shape.SetColor(Android.Graphics.Color.White);
        textView.Background = shape;

        return textView;
    }
}

public class CustomViewHandler : ViewHandler<MainPage.CustomView, Android.Views.View>
{
    public static PropertyMapper<MainPage.CustomView, CustomViewHandler> PropertyMapper = 
        new PropertyMapper<MainPage.CustomView, CustomViewHandler>(ViewHandler.ViewMapper);

    public CustomViewHandler() : base(PropertyMapper)
    {
    }

    protected override Android.Views.View CreatePlatformView()
    {
        return new Android.Views.View(Context);
    }
}
#endif
	}
}