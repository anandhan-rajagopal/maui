﻿using System.Drawing;
using OpenQA.Selenium.Appium;
using UITest.Core;

namespace UITest.Appium
{
	public class AppiumWindowsContextMenuActions : ICommandExecutionGroup
	{
		const string ActivateContextMenuCommand = "activateContextMenu";
		const string DismissContextMenuCommand = "dismissContextMenu";

		protected readonly AppiumApp _app;
		readonly List<string> _commands = new()
		{
			ActivateContextMenuCommand,
			DismissContextMenuCommand,
		};

		public AppiumWindowsContextMenuActions(AppiumApp app)
		{
			_app = app;
		}

		public bool IsCommandSupported(string commandName)
		{
			return _commands.Contains(commandName, StringComparer.OrdinalIgnoreCase);
		}

		public CommandResponse Execute(string commandName, IDictionary<string, object> parameters)
		{
			return commandName switch
			{
				ActivateContextMenuCommand => ActivateContextMenu(parameters),
				DismissContextMenuCommand => DismissContextMenu(parameters),
				_ => CommandResponse.FailedEmptyResponse,
			};
		}

		protected CommandResponse ActivateContextMenu(IDictionary<string, object> parameters)
		{
			parameters.TryGetValue("element", out var value);

			if (value is null)
				return CommandResponse.FailedEmptyResponse;

			string elementString = (string)value;
			var element = GetAppiumElement(elementString);

			// If cannot find an element by Id, just try to find using the text.
			if (element is null)
				element = _app.Driver.FindElement(OpenQA.Selenium.By.XPath("//*[@text='" + elementString + "']"));

			if (element is not null)
			{
				_app.Driver.ExecuteScript("windows: click", new Dictionary<string, object>
				{
					{ "elementId", element.Id },
					{ "button", "right" },
				});

				return CommandResponse.SuccessEmptyResponse;
			}

			return CommandResponse.FailedEmptyResponse;
		}

		protected CommandResponse DismissContextMenu(IDictionary<string, object> parameters)
		{
			try
			{
				var screenbounds = GetRootViewRect(_app);

				var centerX = screenbounds.Width / 2;
				var centerY = screenbounds.Height / 2;

				_app.TapCoordinates(centerX, centerY);

				return CommandResponse.SuccessEmptyResponse;
			}
			catch
			{
				return CommandResponse.FailedEmptyResponse;
			}
		}

		static AppiumElement? GetAppiumElement(object element)
		{
			if (element is AppiumElement appiumElement)
			{
				return appiumElement;
			}
			else if (element is AppiumDriverElement driverElement)
			{
				return driverElement.AppiumElement;
			}

			return null;
		}

		static Rectangle GetRootViewRect(AppiumApp app)
		{
			var rootElement = app.FindElement(AppiumQuery.ByXPath("/*"));
			var rootViewRect = rootElement.GetRect();

			return rootViewRect;
		}
	}
}
