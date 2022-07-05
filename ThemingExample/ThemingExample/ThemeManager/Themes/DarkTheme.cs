namespace ThemingExample.ThemeManager.Themes;

public class DarkTheme : ITheme
{
    public DarkTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Black"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        BarBackgroundColor = (Color)colorDict["Color.Black"];
        BarTextColor = (Color)colorDict["Color.White"];
        ButtonBackgroundColor = (Color)colorDict["Color.Black"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Color BarBackgroundColor { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
