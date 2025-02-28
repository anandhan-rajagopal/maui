﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Text;
using Android.Views;
using Android.Widget;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	public partial class LabelTests
	{
		[Fact(DisplayName = "Html Text Initializes Correctly")]
		public async Task HtmlTextInitializesCorrectly()
		{
			var expected = "Html";

			var label = new Label()
			{
				Text = $"&lt;b&gt;{expected}&lt;/b&gt;",
				TextType = TextType.Html
			};

			var handler = await CreateHandlerAsync<LabelHandler>(label);
			var platformText = await InvokeOnMainThreadAsync(() => TextForHandler(handler));
			Assert.Equal(expected, platformText);
		}

		// This test will only run if the Android Manifest of the Controls.DeviceTests project is edited to have android:supportsRtl="false"
		[Fact(DisplayName = "Horizontal text aligned when RTL is not supported")]
		public async Task HorizontalTextAlignedWhenRtlIsFalse()
		{
			if (Rtl.IsSupported)
				return;

			var label = new Label { Text = "Foo", HorizontalTextAlignment = TextAlignment.Center };

			var handler = await CreateHandlerAsync<LabelHandler>(label);
			var platformLabel = GetPlatformLabel(handler);

			Assert.False(platformLabel.Gravity.HasFlag(GravityFlags.Start), "Label should not have the Start flag.");
			Assert.False(platformLabel.Gravity.HasFlag(GravityFlags.End), "Label should not have the End flag.");
			Assert.True(platformLabel.Gravity.HasFlag(GravityFlags.CenterHorizontal), "Label should have the CenterHorizontal flag.");
		}

		// This test will only run if the Android Manifest of the Controls.DeviceTests project is edited to have android:supportsRtl="false"
		[Fact(DisplayName = "Vertical text aligned when RTL is not supported")]
		public async Task VerticalTextAlignedWhenRtlIsFalse()
		{
			if (Rtl.IsSupported)
				return;

			var label = new Label { Text = "Foo", VerticalTextAlignment = TextAlignment.Center };

			var handler = await CreateHandlerAsync<LabelHandler>(label);
			var platformLabel = GetPlatformLabel(handler);

			Assert.False(platformLabel.Gravity.HasFlag(GravityFlags.Top), "Label should not have the Top flag.");
			Assert.False(platformLabel.Gravity.HasFlag(GravityFlags.Bottom), "Label should not have the Bottom flag.");
			Assert.True(platformLabel.Gravity.HasFlag(GravityFlags.CenterVertical), "Label should only have the CenterVertical flag.");
		}

		// https://github.com/dotnet/maui/issues/18059
		[Fact(DisplayName = "Using TailTruncation LineBreakMode with 2 MaxLines")]
		public async Task UsingTailTruncationWith2MaxLines()
		{
			var label = new Label()
			{
				Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit",
				LineBreakMode = LineBreakMode.TailTruncation,
				MaxLines = 2
			};

			var handler = await CreateHandlerAsync<LabelHandler>(label);

			var platformLabel = GetPlatformLabel(handler);

			await InvokeOnMainThreadAsync((System.Action)(() =>
			{
				Assert.Equal(2, GetPlatformMaxLines(handler));
				Assert.Equal(LineBreakMode.TailTruncation.ToPlatform(), GetPlatformLineBreakMode(handler));
			}));
		}

		[Fact]
		[Description("The ScaleX property of a Label should match with native ScaleX")]
        public async Task ScaleXConsistent()
        {
            var label = new Label() { ScaleX = 0.45f };
            var handler = await CreateHandlerAsync<LabelHandler>(label);
            var expected = label.ScaleX;
            var platformScaleX = await InvokeOnMainThreadAsync(() => handler.PlatformView.ScaleX);
            Assert.Equal(expected, platformScaleX);
        }

		[Fact]
		[Description("The ScaleY property of a Label should match with native ScaleY")]
        public async Task ScaleYConsistent()
        {
            var label = new Label() { ScaleY = 0.45f };
            var handler = await CreateHandlerAsync<LabelHandler>(label);
            var expected = label.ScaleY;
            var platformScaleY = await InvokeOnMainThreadAsync(() => handler.PlatformView.ScaleY);
            Assert.Equal(expected, platformScaleY);
        }

		TextView GetPlatformLabel(LabelHandler labelHandler) =>
			labelHandler.PlatformView;

		TextUtils.TruncateAt GetPlatformLineBreakMode(LabelHandler labelHandler) =>
			GetPlatformLabel(labelHandler).Ellipsize;

		int GetPlatformMaxLines(LabelHandler labelHandler) =>
			GetPlatformLabel(labelHandler).MaxLines;
	}
}