namespace ThemingExample;

public partial class App : Application
{
	public App()
	{
		Current.Resources.MergedDictionaries.Add(new Resources.Styles.Colors());

        

		Current.Resources.MergedDictionaries.Add(new Resources.Styles.Styles());
        
		InitializeComponent();

		MainPage = new MainPage();
	}
}
