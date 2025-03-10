using System.ComponentModel;
using System.Threading.Tasks;
using AndroidX.AppCompat.Widget;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Handlers;
using Xunit;

namespace Microsoft.Maui.DeviceTests
{
	public partial class EntryTests
	{
		static AppCompatEditText GetPlatformControl(EntryHandler handler) =>
			handler.PlatformView;

		static Task<string> GetPlatformText(EntryHandler handler)
		{
			return InvokeOnMainThreadAsync(() => GetPlatformControl(handler).Text);
		}

		static void SetPlatformText(EntryHandler entryHandler, string text) =>
			GetPlatformControl(entryHandler).SetTextKeepState(text);

		static int GetPlatformCursorPosition(EntryHandler entryHandler)
		{
			var editText = GetPlatformControl(entryHandler);

			if (editText != null)
				return editText.SelectionEnd;

			return -1;
		}

		static int GetPlatformSelectionLength(EntryHandler entryHandler)
		{
			var editText = GetPlatformControl(entryHandler);

			if (editText != null)
				return editText.SelectionEnd - editText.SelectionStart;

			return -1;
		}

		Task<float> GetPlatformOpacity(EntryHandler entryHandler)
		{
			return InvokeOnMainThreadAsync(() =>
			{
				var nativeView = GetPlatformControl(entryHandler);
				return nativeView.Alpha;
			});
		}

		[Fact]
		public async Task CursorPositionPreservedWhenTextTransformPresent()
		{
			var entry = new Entry
			{
				Text = "TET",
				TextTransform = TextTransform.Uppercase
			};

			await SetValueAsync<int, EntryHandler>(entry, 2, (h, s) => h.PlatformView.SetSelection(2));

			Assert.Equal(2, entry.CursorPosition);

			await SetValueAsync<string, EntryHandler>(entry, "TEsT", SetPlatformText);

			Assert.Equal(2, entry.CursorPosition);
		}

		[Fact]
		[Category(TestCategory.Entry)]
		public async Task UpdateTextWithTextLongerThanMaxLength()
		{
			string longText = "A text longer than 4 characters";
			var entry = new Entry
			{
				MaxLength = 4,
			};

			await SetValueAsync<string, EntryHandler>(entry, longText, SetPlatformText);

			Assert.Equal(longText[..4], entry.Text);
		}

		[Theory]
		[InlineData(true, FlowDirection.LeftToRight, Android.Views.TextAlignment.ViewStart)]
		[InlineData(true, FlowDirection.RightToLeft, Android.Views.TextAlignment.ViewStart)]
		[InlineData(false, FlowDirection.LeftToRight, Android.Views.TextAlignment.ViewStart)]
		[InlineData(false, FlowDirection.RightToLeft, Android.Views.TextAlignment.ViewStart)]
		[Description("The Entry's text alignment should match the expected alignment when FlowDirection is applied explicitly or implicitly")]
		public async Task EntryAlignmentMatchesFlowDirection(bool isExplicit, FlowDirection flowDirection, Android.Views.TextAlignment expectedAlignment)
		{
			var entry = new Entry { Text = "Checking flow direction", HorizontalTextAlignment = TextAlignment.Start };
			var contentPage = new ContentPage { Title = "Flow Direction", Content = entry };

			if (isExplicit)
			{
				entry.FlowDirection = flowDirection;
			}
			else
			{
				contentPage.FlowDirection = flowDirection;
			}

			var handler = await CreateHandlerAsync<EntryHandler>(entry);
			var nativeAlignment = await contentPage.Dispatcher.DispatchAsync(() =>
			{
				var textField = GetPlatformControl(handler);
				return textField.TextAlignment;
			});

			Assert.Equal(expectedAlignment, nativeAlignment);
		}
	}
}
