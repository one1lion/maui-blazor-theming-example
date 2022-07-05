using ThemingExample.Shared.State;
using ThemingExample.Shared.Theming;
using ThemingExample.ThemeManager;

#if WINDOWS
using ThemingExample.Platforms.Windows;
#endif

namespace ThemingExample;

public partial class App : Application, IDisposable
{
	private readonly IThemeManager _themeManager;
	private readonly PreferencesState _preferencesState;

	public App(IThemeManager themeManager, PreferencesState preferencesState)
	{
		_themeManager = themeManager;
		_preferencesState = preferencesState;
		Task.Run(() => _preferencesState.Initialize()).Wait();

		Current.Resources.MergedDictionaries.Add(new Resources.Styles.Colors());
        ApplyTheme(_preferencesState.ActiveTheme);
        Current.Resources.MergedDictionaries.Add(themeManager[_preferencesState.ActiveTheme]);
		Current.Resources.MergedDictionaries.Add(new Resources.Styles.Styles());

        _preferencesState.PropertyChanged += HandlePreferenceChanged;

        InitializeComponent();

		MainPage = new MainPage();
	}

    private void HandlePreferenceChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PreferencesState.ActiveTheme))
        {
            ApplyTheme(_preferencesState.ActiveTheme);
        }
    }

    private void ApplyTheme(ColorTheme theme)
    {
        var resDict = Current.Resources.MergedDictionaries;
        var curTheme = resDict.GetActiveThemeResource();
        if (curTheme is not null && theme.Is(curTheme))
        {
            // The theme is not changing
            return;
        }

        // Remove the current theme and add the new theme resources
        if (curTheme is not null) { resDict.Remove(curTheme); }
        var updateTheme = _themeManager[theme];
        resDict.Add(updateTheme);
#if WINDOWS
        // Apply the colors to the app window for Windows
        WindowHelpers.ApplyColorTheme(updateTheme);
#endif
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);
        window.Title = "Theming Example";

        return window;
    }

    public void Dispose()
    {
        _preferencesState.PropertyChanged -= HandlePreferenceChanged;
    }
}
