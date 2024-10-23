using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using UIKit;

namespace Maui.Controls.Sample.Platform
{
	[Register("AppDelegate")]
	public class AppDelegate : MauiUIApplicationDelegate
	{
		protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();


		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{

			 var processArguments = NSProcessInfo.ProcessInfo.Arguments;

			Console.WriteLine($"Process Argument: START");
			// Log the arguments
			foreach (var arg in processArguments)
			{
				Console.WriteLine($"Process Argument: {arg}");
			}
			
			var env = NSProcessInfo.ProcessInfo.Environment;

			// Log the arguments
			foreach (var en in env)
			{
				Console.WriteLine($"Process Argument: {en.Key} = {en.Value}");
			}
			
			Console.WriteLine($"Process Argument: END");

			return base.FinishedLaunching(application, launchOptions);
		}
	}
}