namespace Maui.Controls.Sample;

public partial class AppThemePage : ContentPage
{
	public AppThemePage()
	{
		InitializeComponent();
	}

	public void OnButtonClicked(object sender, EventArgs e)
	{
		var currentTheme = Application.Current!.UserAppTheme;

		Application.Current.UserAppTheme = currentTheme switch
		{
			AppTheme.Light => AppTheme.Dark,
			AppTheme.Dark => AppTheme.Light,
			AppTheme.Unspecified => AppTheme.Dark,
			_ => AppTheme.Light
		};
	}
}