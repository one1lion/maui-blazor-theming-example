using ThemingExample.Shared.Theming;
using ThemingExample.ThemeManager.Themes;

namespace ThemingExample.ThemeManager;

public static class ThemeHelpers
{
#if WINDOWS
    public static Windows.UI.Color ToWinUiColor(this Color winUiColor)
    {
        return Windows.UI.Color.FromArgb((byte)(255 * winUiColor.Alpha), (byte)(255 * winUiColor.Red), (byte)(255 * winUiColor.Green), (byte)(255 * winUiColor.Blue));
    }
#endif
    
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

    public static ResourceDictionary GetActiveThemeResource(this ICollection<ResourceDictionary> mergedDictionaries)
    {
        return mergedDictionaries?
            .FirstOrDefault(x =>
                (x.GetType().Name?.Contains("Theme") ?? false)
                || (x.Source?.OriginalString?.Contains("/Themes") ?? false)
            ) ?? null;
    }

    public static bool Is(this ColorTheme theme, ResourceDictionary themeDictionary)
    {
        if (themeDictionary is null) { return false; }
        return theme.GetThemeType() == themeDictionary.GetType();
    }
}
