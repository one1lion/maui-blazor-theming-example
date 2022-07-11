using Xaml = Microsoft.UI.Xaml;
using XamlControls = Microsoft.UI.Xaml.Controls;

namespace ThemingExample.Platforms.Windows;

internal class CustomTitleBar : XamlControls.Grid
{
	public CustomTitleBar()
	{
		//ColumnDefinitions.Add(new XamlControls.ColumnDefinition() { Width = Xaml.GridLength });
		ColumnDefinitions.Add(new XamlControls.ColumnDefinition() { Width = new Xaml.GridLength(1, Xaml.GridUnitType.Star) });
		var button = new XamlControls.Button()
		{
			Content = "This is a button"
		};

        Children.Add(button);

		SetColumn(button, 0);
	}
}
