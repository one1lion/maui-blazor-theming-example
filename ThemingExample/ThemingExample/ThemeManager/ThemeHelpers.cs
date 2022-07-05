using ThemingExample.Shared.Theming;
using ThemingExample.ThemeManager.Themes;

namespace ThemingExample.ThemeManager;

public static class ThemeHelpers
{
    public static Type GetThemeType(this ColorTheme theme) => theme switch
    {
        ColorTheme.Light => typeof(LightTheme),
        ColorTheme.Dark => typeof(DarkTheme),
        ColorTheme.Boo => typeof(BooTheme),
        ColorTheme.Ernge => typeof(ErngeTheme),
        ColorTheme.Grain => typeof(GrainTheme),
        ColorTheme.Kohii => typeof(KohiiTheme),
        _ => typeof(LightTheme)
    };
}
