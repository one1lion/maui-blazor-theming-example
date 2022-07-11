using Microsoft.Maui.LifecycleEvents;
using ThemingExample.Shared.State;
using ThemingExample.ThemeManager;

#if WINDOWS
using ThemingExample.Platforms.Windows;
#endif

namespace ThemingExample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			})
			.ConfigureLifecycleEvents(events =>
			{
#if WINDOWS
				events.AddWindows(windows => windows
					.OnWindowCreated(async window =>
					{
						window.ExtendsContentIntoTitleBar = true;
						await Task.Delay(60);
						window.SetTitleBar(new CustomTitleBar());
					})
				);
#endif
			}); ;

		builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddSingleton<Resources.Styles.Colors>();
		builder.Services.AddSingleton<IThemeManager, ThemeManager.ThemeManager>();

		builder.Services.AddSingleton<PreferencesState>();

		return builder.Build();
	}
}
