namespace ThemingExample.ThemeManager.Themes;

public class LightTheme : ITheme
{
    public LightTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.White"];
        PrimaryTextColor = (Color)colorDict["Color.Black"];
        BarBackgroundColor = (Color)colorDict["Color.White"];
        BarTextColor = (Color)colorDict["Color.Black"];
        ButtonBackgroundColor = (Color)colorDict["Color.Boo3"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Color BarBackgroundColor { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
