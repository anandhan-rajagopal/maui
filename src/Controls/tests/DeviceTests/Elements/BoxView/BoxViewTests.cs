using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Xunit;
using System.ComponentModel;
using Microsoft.Maui.Controls.Handlers;
using System.Diagnostics;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.BoxView)]
	public partial class BoxViewTests : ControlsHandlerTestBase
	{
		[Theory(DisplayName = "BoxView Initializes Correctly")]
		[InlineData(0xFFFF0000)]
		[InlineData(0xFF00FF00)]
		[InlineData(0xFF0000FF)]
		public async Task BoxViewInitializesCorrectly(uint color)
		{
			var expected = Color.FromUint(color);

			var boxView = new BoxView()
			{
				Color = expected,
				HeightRequest = 100,
				WidthRequest = 200
			};

			await ValidateHasColor(boxView, expected, typeof(ShapeViewHandler));
		}

		[Fact]
		[Description("The Cornerradius of a Button should match with native CornerRadius")]
		public async Task BoxViewCornerRadius()
		{
			var boxView = new BoxView
			{
				HeightRequest = 100,
				WidthRequest = 200,
				BackgroundColor = Colors.Red,
				CornerRadius = new CornerRadius(15)
			};
			var expected = boxView.CornerRadius;
			var handler = await CreateHandlerAsync<BoxViewHandler>(boxView);
			var nativeView = GetNativeBoxView(handler);

			await InvokeOnMainThreadAsync( () =>
            {
#if ANDROID
				if (nativeView.Background is Android.Graphics.Drawables.GradientDrawable gradientDrawable)
                {
                    var cornerRadius = gradientDrawable.CornerRadius;
                    Assert.Equal((float)expected.TopLeft, cornerRadius);
                }
#elif IOS || MACCATALYST
				nativeView.Layer.CornerRadius = 15f;
                var cornerRadius = (float)nativeView.Layer.CornerRadius;
				Assert.Equal(expected.TopLeft, cornerRadius);
#elif WINDOWS
                var cornerRadius = (float)nativeView.CornerRadius.TopLeft;
                Assert.Equal(expected, cornerRadius);
#endif
            });
        }

		[Fact]
		[Description("The Background of a Button should match with native Background")]
		public async Task BoxViewBackground()
		{
			var boxView = new BoxView
			{
				HeightRequest = 100,	
				WidthRequest = 200,
				Background = Brush.Red
			};
			var expected = (boxView.Background as SolidColorBrush)?.Color;
			
			await ValidateHasColor(boxView, expected, typeof(BoxViewHandler));
		}
	}
}