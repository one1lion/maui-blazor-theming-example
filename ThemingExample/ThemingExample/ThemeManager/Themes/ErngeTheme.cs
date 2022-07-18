namespace ThemingExample.ThemeManager.Themes;

public class ErngeTheme : ITheme
{
    public ErngeTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Ernge4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        WindowCaptionBackground = (Color)colorDict["Color.Ernge5"];
        WindowCaptionButtonBackground = (Color)colorDict["Color.Ernge5"];
        WindowCaptionButtonBackgroundPointerOver = (Color)colorDict["Color.Ernge5"];
        CloseButtonBackgroundPointerOver = (Color)colorDict["Color.Ernge5"];
        BarTextColor = (Color)colorDict["Color.Ernge1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Ernge5"];
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
