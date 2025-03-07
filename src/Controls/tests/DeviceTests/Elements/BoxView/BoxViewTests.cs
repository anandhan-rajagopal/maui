using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Xunit;


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
		[Description("The BackgroundColor of a BoxView should match with native background color")]
		public async Task BoxViewBackgroundColorConsistent()
		{
			var expected = Colors.AliceBlue;

			var boxView = new BoxView()
			{
				BackgroundColor = expected,
				HeightRequest = 100,
				WidthRequest = 200
			};

			await ValidateHasColor(boxView, expected, typeof(ShapeViewHandler));
		}

		[Fact]
		public async Task BoxViewTransformationConsistent()
		{
			var boxView = new BoxView()
			{
				HeightRequest = 100,
				WidthRequest = 200,
				TranslationX = 10.0,
				TranslationY = 30.0,
				Rotation = 248.0,
				Scale = 2.0,
				ScaleX = 2.0
			};
			
			var handler = await CreateHandlerAsync<BoxViewHandler>(boxView);
			var nativeView = GetNativeBoxView(handler);
			
			await InvokeOnMainThreadAsync(() =>
			{
		#if ANDROID
				var density = Microsoft.Maui.Devices.DeviceDisplay.Current.MainDisplayInfo.Density;
				
				var expectedTranslationX = density * boxView.TranslationX;
				var expectedTranslationY = density * boxView.TranslationY;
				var expectedRotation = boxView.Rotation;
				var expectedScaleX = boxView.Scale * boxView.ScaleX;
				var expectedScaleY = boxView.Scale; 
				
				var actualTranslationX = nativeView.TranslationX;
				var actualTranslationY = nativeView.TranslationY;
				var actualRotation = nativeView.Rotation;
				var actualScaleX = nativeView.ScaleX;
				var actualScaleY = nativeView.ScaleY;
				
				Assert.Equal(expectedTranslationX, actualTranslationX, 1.0);
				Assert.Equal(expectedTranslationY, actualTranslationY, 1.0);
				Assert.Equal(expectedRotation, actualRotation, 0.1);
				Assert.Equal(expectedScaleX, actualScaleX, 0.01);
				Assert.Equal(expectedScaleY, actualScaleY, 0.01);
		#endif
			});
		}
	}
}