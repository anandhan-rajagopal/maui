using Microsoft.Maui.Controls;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Microsoft.Maui;
#if ANDROID
using Android.Views;
using Android.Content;

namespace Maui.Controls.Sample.Issues
{
    [Issue(IssueTracker.Github, 12484, "Unable to set ControlTemplate for TemplatedView in Xamarin.Forms version 5.0", PlatformAffected.Android)]
    public partial class Issue12484 : TestContentPage
    {
        public Issue12484()
        {
            InitializeComponent();
            Content = new Issue12484CustomView();
        }   

        protected override void Init()
        {
            Title = "Issue 12484";
        }
    }

    public class Issue12484CustomView : TemplatedView
    {
        public class Issue12484Template : ContentView
        {
            public Issue12484Template()
            {
                var content = new StackLayout()
                {
                    Children =
                    {
                        new Label()
                        {
                            Text = "If a label with text `Success` does not show up this test has failed"
                        }
                    }
                };
                Content = content;
            }
        }

        public Issue12484CustomView()
        {
            ControlTemplate = new ControlTemplate(typeof(Issue12484Template));
        }
    }

    public class Issue12484CustomViewHandler : ViewHandler<Issue12484CustomView, Android.Views.View>
    {
        public static IPropertyMapper<Issue12484CustomView, Issue12484CustomViewHandler> Mapper = new PropertyMapper<Issue12484CustomView, Issue12484CustomViewHandler>(ViewHandler.ViewMapper);

        public Issue12484CustomViewHandler() : base(Mapper)
        {
        }

        public Issue12484CustomViewHandler(IPropertyMapper mapper = null) : base(mapper ?? Mapper)
        {
        }

        protected override Android.Views.View CreatePlatformView()
        {
            var template = VirtualView.ControlTemplate.CreateContent() as Issue12484CustomView.Issue12484Template;
            
            if (template == null)
                return new Android.Widget.FrameLayout(Context);

            if (template.Content is StackLayout stackLayout)
            {
                var label = new Label
                {
                    AutomationId = "Success",
                    Text = "Success",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                
                stackLayout.Children.Add(label);
            }

            return template.ToPlatform(MauiContext);
        }

        public static void MapContent(Issue12484CustomViewHandler handler, Issue12484CustomView view)
        {
            if (handler.PlatformView != null)
            {
                handler.PlatformView.Invalidate();
            }
        }
    }
}
#endif