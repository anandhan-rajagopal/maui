namespace Maui.Controls.Sample;

public partial class TabbedPageOptionsPage : ContentPage
{
	private TabbedPageViewModel _viewModel;

	public TabbedPageOptionsPage(TabbedPageViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private void ApplyButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopModalAsync();
	}

	private void BarBackgroundBrushButton_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		switch (button.Text)
		{
			case "Gradient":
				_viewModel.BarBackground = new LinearGradientBrush
				{
					StartPoint = new Point(0, 0),
					EndPoint = new Point(1, 1),
					GradientStops = new GradientStopCollection
			{
				new GradientStop { Color = Colors.Red, Offset = 0.0f },
				new GradientStop { Color = Colors.Blue, Offset = 1.0f }
			}
				};
				break;
			case "Solid":
				_viewModel.BarBackground = new SolidColorBrush(Colors.Yellow);
				break;
		}
	}

	private void BarBackgroundColorButton_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		switch (button.Text)
		{
			case "Blue":
				_viewModel.BarBackgroundColor = Colors.Blue;
				break;
			case "Green":
				_viewModel.BarBackgroundColor = Colors.Green;
				break;
		}
	}

	private void BarTextColorButton_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		switch (button.Text)
		{
			case "Black":
				_viewModel.BarTextColor = Colors.Black;
				break;
			case "Red":
				_viewModel.BarTextColor = Colors.Red;
				break;
		}
	}

	private void SelectedTabColorButton_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		switch (button.Text)
		{
			case "Orange":
				_viewModel.SelectedTabColor = Colors.Orange;
				break;
			case "Purple":
				_viewModel.SelectedTabColor = Colors.Purple;
				break;
		}
	}

	private void UnselectedTabColorButton_Clicked(object sender, EventArgs e)
	{
		var button = (Button)sender;
		switch (button.Text)
		{
			case "LightGray":
				_viewModel.UnselectedTabColor = Colors.LightGray;
				break;
			case "DarkGray":
				_viewModel.UnselectedTabColor = Colors.DarkGray;
				break;
		}
	}

	private void OnIsVisibleChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton != null && radioButton.IsChecked)
		{
			_viewModel.IsVisible = false;
		}
	}

	private void OnIsEnabledChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton != null && radioButton.IsChecked)
		{
			_viewModel.IsEnabled = false;
		}
	}

	private void OnFlowDirectionChanged(object sender, CheckedChangedEventArgs e)
	{
		var radioButton = sender as RadioButton;
		if (radioButton != null && radioButton.IsChecked)
		{
			_viewModel.FlowDirection = radioButton.Content.ToString() == "Left to Right" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
		}
	}
}
