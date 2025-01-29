using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
#if ANDROID
using Android.Views;
using AView = Android.Views.View;
#elif IOS || MACCATALYST
using UIKit;
#elif WINDOWS
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
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
					new Microsoft.Maui.Controls.Grid
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

	public class CustomGrid : Microsoft.Maui.Controls.Grid { }

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
 
#elif IOS || MACCATALYST
	public class CustomGrid1942Handler : ViewHandler<CustomGrid, UIView>
	{
		public static PropertyMapper<CustomGrid, CustomGrid1942Handler> PropertyMapper =
			new PropertyMapper<CustomGrid, CustomGrid1942Handler>(ViewHandler.ViewMapper);

		public static CommandMapper<CustomGrid, CustomGrid1942Handler> CommandMapper =
			new(ViewCommandMapper);

		public CustomGrid1942Handler() : base(PropertyMapper, CommandMapper) { }

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
				// Remove existing gesture recognizers
				if (platformView.GestureRecognizers != null)
				{
					foreach (var recognizer in platformView.GestureRecognizers)
					{
						platformView.RemoveGestureRecognizer(recognizer);
					}
				}

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

						var tapGesture = new UITapGestureRecognizer(HandleTouch)
						{
							CancelsTouchesInView = false,
							DelaysTouchesBegan = false,
							DelaysTouchesEnded = false
						};
						childView.AddGestureRecognizer(tapGesture);
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
					if (subview.GestureRecognizers != null)
					{
						foreach (var recognizer in subview.GestureRecognizers)
						{
							subview.RemoveGestureRecognizer(recognizer);
						}
					}
					subview.RemoveFromSuperview();
				}
			}

			base.DisconnectHandler(platformView);
		}

		private void HandleTouch()
		{
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
#elif WINDOWS
	public class CustomGrid1942Handler : ViewHandler<CustomGrid, FrameworkElement>
    {
        public static PropertyMapper<CustomGrid, CustomGrid1942Handler> PropertyMapper = 
            new PropertyMapper<CustomGrid, CustomGrid1942Handler>(ViewHandler.ViewMapper);

        public static CommandMapper<CustomGrid, CustomGrid1942Handler> CommandMapper = 
            new(ViewCommandMapper);

        public CustomGrid1942Handler() : base(PropertyMapper, CommandMapper) { }

        protected override FrameworkElement CreatePlatformView()
        {
            var containerPanel = new Microsoft.UI.Xaml.Controls.Grid
            {
                HorizontalAlignment = Microsoft.UI.Xaml.HorizontalAlignment.Center,
                VerticalAlignment = Microsoft.UI.Xaml.VerticalAlignment.Center
            };

            return containerPanel;
        }

        protected override void ConnectHandler(FrameworkElement platformView)
        {
            base.ConnectHandler(platformView);

            if (platformView is Microsoft.UI.Xaml.Controls.Grid containerGrid)
            {
                foreach (var child in VirtualView.Children)
                {
                    var childHandler = child.ToHandler(MauiContext);
                    if (childHandler?.PlatformView is FrameworkElement childView)
                    {
                        containerGrid.Children.Add(childView);

                        var tapHandler = new TappedEventHandler((sender, e) => {
                            var grid = VirtualView;
                            if (grid?.Children.FirstOrDefault() is Microsoft.Maui.Controls.Grid childGrid)
                            {             
                                if (childGrid.Children.FirstOrDefault() is Microsoft.Maui.Controls.Label mauiLabel)
                                {
                                    mauiLabel.Text = Issue1942.SuccessString;
                                }
                            }
                        });

                        childView.Tapped += tapHandler;
                    }
                }
            }
        }

        protected override void DisconnectHandler(FrameworkElement platformView)
        {
            if (platformView is Microsoft.UI.Xaml.Controls.Grid containerGrid)
            {
                containerGrid.Children.Clear();
            }

            base.DisconnectHandler(platformView);
        }
    }
#endif
}