namespace ThemingExample.ThemeManager.Themes;

public class KohiiTheme : ITheme
{
    public KohiiTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Kohii4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        WindowCaptionBackground = (Color)colorDict["Color.Kohii5"];
        WindowCaptionButtonBackground = (Color)colorDict["Color.Kohii5"];
        WindowCaptionButtonBackgroundPointerOver = (Color)colorDict["Color.Kohii5"];
        CloseButtonBackgroundPointerOver = (Color)colorDict["Color.Kohii5"];
        BarTextColor = (Color)colorDict["Color.Kohii1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Kohii5"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Brush WindowCaptionBackground { get; }
    public Brush WindowCaptionButtonBackground { get; }
    public Brush WindowCaptionButtonBackgroundPointerOver { get; }
    public Brush CloseButtonBackgroundPointerOver { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
