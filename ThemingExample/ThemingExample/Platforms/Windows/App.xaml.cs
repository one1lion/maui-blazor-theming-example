// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.Maui.Handlers;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using ThemingExample.Platforms.Windows;
using ThemingExample.Shared.State;
using ThemingExample.ThemeManager;
using WinRT.Interop;

namespace ThemingExample.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();

        WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            var width = 1420;
            var height = 838;

            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();

            //nativeWindow.ExtendsContentIntoTitleBar = true;
            //nativeWindow.SetTitleBar(/*something*/);
            var hWnd = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            var preferencesState = handler.MauiContext.Services.GetService<PreferencesState>();
            var themeManager = handler.MauiContext.Services.GetService<IThemeManager>();

            Task.Run(() => preferencesState.Initialize()).Wait();
            var activeTheme = themeManager[preferencesState.ActiveTheme];

            WindowHelpers.ApplyColorTheme(activeTheme, appWindow);

            // TODO: On close, remember which display the app is on and try to center the app on that display first.
            //       If that fails, then center on the display it is opening on.
            var screenWidth = DeviceDisplay.MainDisplayInfo.Width;
            var screenHeight = DeviceDisplay.MainDisplayInfo.Height;

            appWindow.MoveAndResize(
                new Windows.Graphics.RectInt32(
                    // Move the top left corner so that the window is centered on the main display
                    (int)(screenWidth / 2 - width / 2),
                    (int)(screenHeight / 2 - height / 2),
                    // Set the height and width
                    width, height
                )
            );
        });
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

