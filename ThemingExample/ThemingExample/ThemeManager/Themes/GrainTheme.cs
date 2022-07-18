namespace ThemingExample.ThemeManager.Themes;

public class GrainTheme : ITheme
{
    public GrainTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Grain4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        WindowCaptionBackground = (Color)colorDict["Color.Grain5"];
        WindowCaptionButtonBackground = (Color)colorDict["Color.Grain5"];
        WindowCaptionButtonBackgroundPointerOver = (Color)colorDict["Color.Grain5"];
        CloseButtonBackgroundPointerOver = (Color)colorDict["Color.Grain5"];
        BarTextColor = (Color)colorDict["Color.Grain1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Grain5"];
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
