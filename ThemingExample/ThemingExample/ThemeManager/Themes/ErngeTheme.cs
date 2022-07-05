namespace ThemingExample.ThemeManager.Themes;

public class ErngeTheme : ITheme
{
    public ErngeTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Ernge4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        BarBackgroundColor = (Color)colorDict["Color.Ernge5"];
        BarTextColor = (Color)colorDict["Color.Ernge1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Ernge5"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Color BarBackgroundColor { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
