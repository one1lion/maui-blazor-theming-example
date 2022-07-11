using Microsoft.UI.Windowing;
using Microsoft.UI;
using WinRT.Interop;
using ThemingExample.Resources.Themes;
using ThemingExample.ThemeManager;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace ThemingExample.Platforms.Windows;

public static class WindowHelpers
{
    public static Microsoft.UI.Xaml.Window GetActiveNativeWindow() => 
        (Microsoft.UI.Xaml.Window)Application.Current.Windows.FirstOrDefault()?.Handler?.PlatformView;

    public static AppWindow GetActiveAppWindow()
    {
        var nativeWindow = GetActiveNativeWindow();
        if (nativeWindow is null) { return default; }
        var hWnd = WindowNative.GetWindowHandle(nativeWindow);
        var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
        return AppWindow.GetFromWindowId(windowId);
    }

    public static void ApplyColorTheme(ThemeResourceDictionary colorTheme, AppWindow appWindow = null)
    {
        return;

        if (appWindow is null)
        {
            appWindow = GetActiveAppWindow();
        }
        if (appWindow is null) { return; } // This will be null on initial start

#if WINDOWS
        if (appWindow.TitleBar is null) { return; }
        // The platform directive is needed since the extension method in ThemeHelpers 
        // is also surrounded by one
        var color = ((Color)colorTheme["BarBackgroundColor"]).ToWinUiColor();
        appWindow.TitleBar.BackgroundColor = color;
        appWindow.TitleBar.ButtonBackgroundColor = color;
        // This forces the icon area to refresh as well (so the background color applies)
        appWindow.TitleBar.IconShowOptions = IconShowOptions.ShowIconAndSystemMenu;
#endif
    }
}
