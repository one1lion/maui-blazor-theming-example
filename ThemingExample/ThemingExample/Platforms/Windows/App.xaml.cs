// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Handlers;
using Microsoft.UI;
using Microsoft.UI.Windowing;
using System.Diagnostics;
using ThemingExample.Platforms.Windows;
using ThemingExample.Resources.Themes;
using ThemingExample.Shared.State;
using ThemingExample.Shared.Theming;
using ThemingExample.ThemeManager;
using Windows.UI.Core;
using WinRT.Interop;

namespace ThemingExample.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
    private Microsoft.UI.Xaml.Window _window;
    
    private IThemeManager _themeManager;
    private PreferencesState _preferencesState;
    private Resources.Styles.Colors _colorsDict;
    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();

        WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        {
            _themeManager = handler.MauiContext.Services.GetService<IThemeManager>();
            _preferencesState = handler.MauiContext.Services.GetService<PreferencesState>();
            _colorsDict = handler.MauiContext.Services.GetService<Resources.Styles.Colors>();

            var width = 1420;
            var height = 838;

            var nativeWindow = handler.PlatformView;
            nativeWindow.Activate();

            //nativeWindow.ExtendsContentIntoTitleBar = true;
            //nativeWindow.SetTitleBar(null);
            //var custTitleBar = (Microsoft.UI.Xaml.Controls.Grid)Resources["AppTitleBar"];
            //nativeWindow.SetTitleBar(custTitleBar);

            var hWnd = WindowNative.GetWindowHandle(nativeWindow);
            var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);
            var appWindow = AppWindow.GetFromWindowId(windowId);

            var preferencesState = _preferencesState;
            var themeManager = _themeManager;

            Task.Run(() => preferencesState.Initialize()).Wait();

            var activeTheme = themeManager[preferencesState.ActiveTheme];

            ApplyTheme(_preferencesState.ActiveTheme);

            //WindowHelpers.ApplyColorTheme(activeTheme, appWindow);

            preferencesState.PropertyChanged += HandlePreferenceChanged;

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

    /// <summary>
    /// Invoked when the application is launched normally by the end user.  Other entry points
    /// will be used such as when the application is launched to open a specific file.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    //protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    //{
    //    _window = new MainWindow();
    //    _window.Activate();
    //}

    private void HandlePreferenceChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(PreferencesState.ActiveTheme))
        {
            ApplyTheme(_preferencesState.ActiveTheme);
        }
    }

    private void ApplyTheme(ColorTheme theme)
    {
#if WINDOWS
        //return;
        var resDict = Current.Resources;
        var themeClass = theme.GetThemeType();
        var curTheme = (ITheme)Activator.CreateInstance(themeClass, _colorsDict);

        foreach (var curProp in themeClass.GetProperties().Where(x => ThemeResourceDictionary.KeepProps.Contains(x.PropertyType)))
        {
            object value = default!;
            switch (curProp.GetValue(curTheme))
            {
                case Color c:
                    //value = c.ToMediaColor();
                    value = c.ToWinUiColor();
                    break;

                case Brush b:
                    value = b.ToBrush();
                    break;

                default:
                    continue;
            };

            if (resDict.ContainsKey(curProp.Name))
            {
                resDict[curProp.Name] = value;
            }
            else
            {
                resDict.Add(curProp.Name, value);
            }
        }

        var nativeWindow = (Microsoft.UI.Xaml.Window)Current.Application.Windows.FirstOrDefault()?.Handler?.PlatformView;
        if(nativeWindow is not null)
        {
            Current.Application.Windows.FirstOrDefault().AddOverlay(Current.Application.Windows.FirstOrDefault().VisualDiagnosticsOverlay);
            var hWnd = WindowNative.GetWindowHandle(nativeWindow);
            hWnd.ForcePaint();
            nativeWindow.Dispatcher?.ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);
            Current.Application.Windows.FirstOrDefault().RemoveOverlay(Current.Application.Windows.FirstOrDefault().VisualDiagnosticsOverlay);
        }
#endif
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

