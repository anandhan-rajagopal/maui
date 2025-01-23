using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
#if ANDROID
using Android.Views;
using AView = Android.Views.View;
#elif IOS
using UIKit;
#endif

namespace Maui.Controls.Sample.Issues
{
    [Issue(IssueTracker.Github, 1942, "[Android] Attached Touch Listener events do not dispatch to immediate parent Grid Renderer View on Android when Child fakes handled",
        PlatformAffected.Android)]
    public class Issue1942 : TestContentPage
    {
        public const string SuccessString = "Success";
        public const string ClickMeString = "CLICK ME";
        protected override void Init()
        {
            Content = new CustomGrid()
            {
                Children =
                {
                    new Grid
                    {
                        Children = { 
                            new Label() { 
                                Text = ClickMeString, 
                                BackgroundColor = Colors.Blue, 
                                HeightRequest = 300, 
                                WidthRequest = 300,
                            } 
                        }
                    }
                }
            };
        }
    }

    public class CustomGrid : Grid { }

#if ANDROID
    public class CustomGrid1942Handler : ViewHandler<CustomGrid, AView>
    {
        private AView _gridChild;
        private GlobalLayoutListener _globalLayoutListener;

        public static PropertyMapper<CustomGrid, CustomGrid1942Handler> PropertyMapper = new PropertyMapper<CustomGrid, CustomGrid1942Handler>(ViewHandler.ViewMapper);

        public static CommandMapper<CustomGrid, CustomGrid1942Handler> CommandMapper = new(ViewCommandMapper);

        public CustomGrid1942Handler() : base(PropertyMapper, CommandMapper)
        {}

        protected override AView CreatePlatformView()
        {
            var context = Context;
            var gridLayout = new Android.Widget.FrameLayout(context)
            {
                LayoutParameters = new ViewGroup.LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent)
            };

            _globalLayoutListener = new GlobalLayoutListener(this);
            gridLayout.ViewTreeObserver.AddOnGlobalLayoutListener(_globalLayoutListener);
            
            return gridLayout;
        }

        protected override void ConnectHandler(AView platformView)
        {
            base.ConnectHandler(platformView);

            if (platformView is ViewGroup viewGroup)
            {
                foreach (var child in VirtualView.Children)
                {
                    var childHandler = child.ToHandler(MauiContext);
                    if (childHandler?.PlatformView is AView childView)
                    {
                        viewGroup.AddView(childView);
                    }
                }
            }
        }

        protected override void DisconnectHandler(AView platformView)
        {
            if (_gridChild != null)
            {
                _gridChild.SetOnTouchListener(null);
                _gridChild = null;
            }

            if (_globalLayoutListener != null && platformView?.ViewTreeObserver != null)
            {
                platformView.ViewTreeObserver.RemoveOnGlobalLayoutListener(_globalLayoutListener);
                _globalLayoutListener = null;
            }
            
            if (platformView is ViewGroup viewGroup)
            {
                viewGroup.RemoveAllViews();
            }

            base.DisconnectHandler(platformView);
        }

        private class GlobalLayoutListener : Java.Lang.Object, ViewTreeObserver.IOnGlobalLayoutListener
        {
            private readonly WeakReference<CustomGrid1942Handler> _handlerRef;

            public GlobalLayoutListener(CustomGrid1942Handler handler)
            {
                _handlerRef = new WeakReference<CustomGrid1942Handler>(handler);
            }

            public void OnGlobalLayout()
            {
                if (_handlerRef.TryGetTarget(out var handler))
                {
                    var platformView = handler.PlatformView as ViewGroup;
                    if (platformView?.ChildCount > 0)
                    {
                        handler._gridChild = platformView.GetChildAt(0);
                        if (handler._gridChild != null)
                        {
                            handler._gridChild.SetOnTouchListener(new TouchListener(handler));
                        }
                    }
                }
            }
        }

        private class TouchListener : Java.Lang.Object, AView.IOnTouchListener
        {
            private readonly WeakReference<CustomGrid1942Handler> _handlerRef;

            public TouchListener(CustomGrid1942Handler handler)
            {
                _handlerRef = new WeakReference<CustomGrid1942Handler>(handler);
            }

            public bool OnTouch(AView v, MotionEvent e)
            {
                if (_handlerRef.TryGetTarget(out var handler))
                {
                    var grid = handler.VirtualView;
                    if (grid?.Children.FirstOrDefault() is Grid childGrid)
                    {
                        if (childGrid.Children.FirstOrDefault() is Label label)
                        {
                            label.Text = Issue1942.SuccessString;
                        }
                    }

                    handler._gridChild?.SetOnTouchListener(null);
                    if (handler.PlatformView?.ViewTreeObserver != null && handler._globalLayoutListener != null)
                    {
                        handler.PlatformView.ViewTreeObserver.RemoveOnGlobalLayoutListener(handler._globalLayoutListener);
                    }
                }
                return true;
            }
        }
    }
#elif IOS
     public class CustomGrid1942Handler : ViewHandler<CustomGrid, UIView>
    {
        public static PropertyMapper<CustomGrid, CustomGrid1942Handler> PropertyMapper = new PropertyMapper<CustomGrid, CustomGrid1942Handler>(ViewHandler.ViewMapper);

        public static CommandMapper<CustomGrid, CustomGrid1942Handler> CommandMapper = new(ViewCommandMapper);

        public CustomGrid1942Handler() : base(PropertyMapper, CommandMapper)
        {
        }

        protected override UIView CreatePlatformView()
        {
            var containerView = new UIView
            {
                ClipsToBounds = true,
                UserInteractionEnabled = true
            };
        containerView.Frame = new CoreGraphics.CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);

            return containerView;
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);

            if (platformView != null)
            {
                if (platformView.GestureRecognizers != null)
                {
                    foreach (var recognizer in platformView.GestureRecognizers)
                    {
                        platformView.RemoveGestureRecognizer(recognizer);
                    }
                }

                var tapRecognizer = new UITapGestureRecognizer(HandleTouch)
                {
                    CancelsTouchesInView = false,
                    DelaysTouchesBegan = false,
                    DelaysTouchesEnded = false
                };

                platformView.AddGestureRecognizer(tapRecognizer);

                foreach (var child in VirtualView.Children)
                {
                    var childHandler = child.ToHandler(MauiContext);
                    if (childHandler?.PlatformView is UIView childView)
                    {
                        platformView.AddSubview(childView);
                        
                        childView.UserInteractionEnabled = true;
                        childView.TranslatesAutoresizingMaskIntoConstraints = false;
                        childView.CenterXAnchor.ConstraintEqualTo(platformView.CenterXAnchor).Active = true;
                        childView.CenterYAnchor.ConstraintEqualTo(platformView.CenterYAnchor).Active = true;
                        childView.WidthAnchor.ConstraintEqualTo(300).Active = true; 
                        childView.HeightAnchor.ConstraintEqualTo(300).Active = true;
 
                    }
                }

                platformView.SetNeedsLayout();
            }
        }

        protected override void DisconnectHandler(UIView platformView)
        {
            if (platformView != null)
            {
                foreach (var subview in platformView.Subviews.ToArray())
                {
                    subview.RemoveFromSuperview();
                }

                if (platformView.GestureRecognizers != null)
                {
                    foreach (var recognizer in platformView.GestureRecognizers)
                    {
                        platformView.RemoveGestureRecognizer(recognizer);
                    }
                }
            }

            base.DisconnectHandler(platformView);
        }

        private void HandleTouch()
        {
            var grid = VirtualView;
            MainThread.BeginInvokeOnMainThread(() => {
                var grid = VirtualView;
                if (grid?.Children.FirstOrDefault() is Grid childGrid)
                {             
                    if (childGrid.Children.FirstOrDefault() is Label label)
                    {
                        label.Text = Issue1942.SuccessString;
                    }
                }
            });
        }
    }
#endif
}
