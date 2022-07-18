namespace ThemingExample.ThemeManager.Themes;

public class DarkTheme : ITheme
{
    public DarkTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Black"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        WindowCaptionBackground = (Color)colorDict["Color.Black"];
        WindowCaptionButtonBackground = (Color)colorDict["Color.Black"];
        WindowCaptionButtonBackgroundPointerOver = (Color)colorDict["Color.Black"];
        CloseButtonBackgroundPointerOver = (Color)colorDict["Color.Black"];
        BarTextColor = (Color)colorDict["Color.White"];
        ButtonBackgroundColor = (Color)colorDict["Color.Black"];
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
