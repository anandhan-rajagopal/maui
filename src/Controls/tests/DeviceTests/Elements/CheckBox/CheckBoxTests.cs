﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Xunit;
using System.ComponentModel;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.CheckBox)]
	public partial class CheckBoxTests : ControlsHandlerTestBase
	{
		void SetupBuilder()
		{
			EnsureHandlerCreated(builder =>
			{
				builder.ConfigureMauiHandlers(handlers =>
				{
					handlers.AddHandler<CheckBox, CheckBoxHandler>();
				});
			});
		}

		[Theory("Checkbox Background Updates Correctly With BackgroundColor Property"
#if WINDOWS
			,Skip = "Failing"
#endif
			)]
		[InlineData("#FF0000")]
		[InlineData("#00FF00")]
		[InlineData("#0000FF")]
		public async Task UpdatingCheckBoxBackgroundColorUpdatesBackground(string colorStr)
		{
			var color = Color.Parse(colorStr);

			var checkBox = new CheckBox
			{
				BackgroundColor = Colors.HotPink
			};

			checkBox.BackgroundColor = color;

			await ValidateHasColor<CheckBoxHandler>(checkBox, color);
		}

		[Fact]
		[Description("The IsVisible property of a CheckBox should match with native IsVisible")]		
		public async Task VerifyCheckBoxIsVisibleProperty()
		{
			var checkBox = new CheckBox();
			checkBox.IsVisible = false;
			var expectedValue = checkBox.IsVisible;

			var handler = await CreateHandlerAsync<CheckBoxHandler>(checkBox);
			var nativeView = GetNativeCheckBox(handler);
			 await InvokeOnMainThreadAsync( async () =>
   			 {
				var nativeView = await GetPlatformIsVisible(handler);
		        Assert.Equal(expectedValue, nativeView);
    		});	
		}
	}
}