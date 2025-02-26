using Microsoft.Maui.Handlers;

namespace Microsoft.Maui.DeviceTests
{
	public partial class RadioButtonTests
	{
		UI.Xaml.Controls.RadioButton GetNativeRadioButton(RadioButtonHandler radioButtonHandler) =>
			radioButtonHandler.PlatformView;

		bool GetNativeIsChecked(RadioButtonHandler radioButtonHandler) =>
			GetNativeRadioButton(radioButtonHandler).IsChecked ?? false;

		[Fact]
		[Description("The IsVisible property of a RadioButton should match with native IsVisible")]		
		public async Task VerifyRadioButtonIsVisibleProperty()
		{
			var radioButton = new RadioButton();
			radioButton.IsVisible = false;
			var expectedValue = radioButton.IsVisible;

			var handler = await CreateHandlerAsync<RadioButton>(radioButton);
			var nativeView = GetNativeRadioButton(handler);
			await InvokeOnMainThreadAsync(() =>
   			{
				var isRadioButtonVisible = nativeView.Visibility == Windows.UI.Xaml.Visibility.Visible;
				Assert.Equal(expectedValue, isRadioButtonVisible);
			});	
		}
	}
}
