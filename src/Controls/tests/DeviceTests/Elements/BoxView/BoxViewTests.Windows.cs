﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Graphics.Win2D;
using Microsoft.Maui.Handlers;
using Xunit;
using System.ComponentModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Handlers;

namespace Microsoft.Maui.DeviceTests
{
	public partial class BoxViewTests
	{
		W2DGraphicsView GetNativeBoxView(ShapeViewHandler boxViewHandler) =>
			boxViewHandler.PlatformView;

		Task<float> GetPlatformOpacity(ShapeViewHandler handler)
		{
			return InvokeOnMainThreadAsync(() =>
			{
				var nativeView = GetNativeBoxView(handler);
				return (float)nativeView.Opacity;
			});
		}
	}
}