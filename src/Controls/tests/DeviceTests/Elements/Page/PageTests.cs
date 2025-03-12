#if !IOS && !MACCATALYST
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;
using Xunit;
using AView = Android.Views.View;
using AndroidX.Fragment.App;

namespace Microsoft.Maui.DeviceTests
{
	[Category(TestCategory.Page)]
	[Collection(ControlsHandlerTestBase.RunInNewWindowCollection)]
	public partial class PageTests : ControlsHandlerTestBase
	{
		[Theory("Page Background Initializes Correctly With Background Property")]
		[InlineData("#FF0000")]
		[InlineData("#00FF00")]
		[InlineData("#0000FF")]
		public async Task InitializingBackgroundUpdatesBackground(string colorStr)
		{
			var color = Color.Parse(colorStr);

			var page = new ContentPage();
			page.Background = color;

			await CreateHandlerAndAddToWindow<PageHandler>(page, async (handler) =>
			{
				await handler.PlatformView.AssertContainsColor(color, handler.MauiContext);
			});
		}

		[Theory("Page Background Initializes Correctly With BackgroundColor Property")]
		[InlineData("#FF0000")]
		[InlineData("#00FF00")]
		[InlineData("#0000FF")]
		public async Task InitializingBackgroundColorUpdatesBackground(string colorStr)
		{
			var color = Color.Parse(colorStr);

			var page = new ContentPage();
			page.BackgroundColor = color;

			await CreateHandlerAndAddToWindow<PageHandler>(page, async (handler) =>
			{
				await handler.PlatformView.AssertContainsColor(color, handler.MauiContext);
			});
		}

		[Theory("Page Background Updates Correctly With Background Property")]
		[InlineData("#FF0000")]
		[InlineData("#00FF00")]
		[InlineData("#0000FF")]
		public async Task UpdatingBackgroundUpdatesBackground(string colorStr)
		{
			var color = Color.Parse(colorStr);

			var page = new ContentPage();
			page.Background = Colors.HotPink;

			await CreateHandlerAndAddToWindow<PageHandler>(page, async (handler) =>
			{
				page.Background = color;

				await handler.PlatformView.AssertContainsColor(color, handler.MauiContext);
			});
		}

		[Theory("Page Background Updates Correctly With BackgroundColor Property")]
		[InlineData("#FF0000")]
		[InlineData("#00FF00")]
		[InlineData("#0000FF")]
		public async Task UpdatingBackgroundColorUpdatesBackground(string colorStr)
		{
			var color = Color.Parse(colorStr);

			var page = new ContentPage();
			page.BackgroundColor = Colors.HotPink;

			await CreateHandlerAndAddToWindow<PageHandler>(page, async (handler) =>
			{
				page.BackgroundColor = color;

				await handler.PlatformView.AssertContainsColor(color, handler.MauiContext);
			});
		}

		[Fact("No issues using Page IsBusy property")]
		public async Task UsingIsBusyNoCrash()
		{
			var page = new ContentPage();
			page.IsBusy = true;

			await CreateHandlerAndAddToWindow<PageHandler>(page, (handler) =>
			{
				// Validate that no exceptions are thrown
				((IElementHandler)handler).DisconnectHandler();
				return Task.CompletedTask;
			});
		}

#if ANDROID
		[Fact(DisplayName = "Can Create Platform View From ContentPage")]
		public async Task CanCreatePlatformViewFromContentPage()
		{

			var contentPage = new ContentPage { Title = "Embedded Page" };
			var handler = CreateHandler<PageHandler>(contentPage);
			var mauiContext = handler.MauiContext;

			await contentPage.Dispatcher.DispatchAsync(() =>
			{

				AView platformView = contentPage.ToPlatform(mauiContext);
				if (platformView is FragmentContainerView containerView)
				{
					var activity = mauiContext.Context as AndroidX.Fragment.App.FragmentActivity;
					var fragmentManager = activity.SupportFragmentManager;
					var fragment = fragmentManager.FindFragmentById(containerView.Id);
					Assert.NotNull(fragment);
				}
			});
		}
#endif
	}
}
#endif