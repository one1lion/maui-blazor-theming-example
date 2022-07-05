using ThemingExample.Resources.Themes;
using ThemingExample.Shared.Theming;

namespace ThemingExample.ThemeManager;

public interface IThemeManager
{
    ResourceDictionary Colors { get; }
    IReadOnlyDictionary<ColorTheme, ThemeResourceDictionary> Themes { get; }
    public ThemeResourceDictionary this[ColorTheme theme] { get; }
}

public class ThemeManager : IThemeManager
{
    public ThemeManager(Resources.Styles.Colors colorDictionary)
    {
        Colors = colorDictionary;
        var themesList = new Dictionary<ColorTheme, ThemeResourceDictionary>();
        foreach (var curColorTheme in Enum.GetValues<ColorTheme>())
        {
            var type = curColorTheme.GetThemeType();
            var themeObj = (ITheme)Activator.CreateInstance(type, colorDictionary);
            themesList.Add(curColorTheme, new ThemeResourceDictionary(themeObj));
        }
        Themes = themesList;
    }

    public ThemeResourceDictionary this[ColorTheme theme] => GetThemeObject(theme);
    public ResourceDictionary Colors { get; }
    public IReadOnlyDictionary<ColorTheme, ThemeResourceDictionary> Themes { get; }

    public ThemeResourceDictionary GetThemeObject(ColorTheme theme)
    {
        return Themes.TryGetValue(theme, out var themeObj) ? themeObj : null;
    }
}
