namespace ThemingExample.ThemeManager.Themes;

public class GrainTheme : ITheme
{
    public GrainTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Grain4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        BarBackgroundColor = (Color)colorDict["Color.Grain5"];
        BarTextColor = (Color)colorDict["Color.Grain1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Grain5"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Color BarBackgroundColor { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
