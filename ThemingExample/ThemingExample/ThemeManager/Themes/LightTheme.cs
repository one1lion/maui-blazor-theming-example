namespace ThemingExample.ThemeManager.Themes;

public class LightTheme : ITheme
{
    public LightTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.White"];
        PrimaryTextColor = (Color)colorDict["Color.Black"];
        WindowCaptionBackground = (Color)colorDict["Color.White"];
        WindowCaptionButtonBackground = (Color)colorDict["Color.White"];
        WindowCaptionButtonBackgroundPointerOver = (Color)colorDict["Color.White"];
        CloseButtonBackgroundPointerOver = (Color)colorDict["Color.White"];
        BarTextColor = (Color)colorDict["Color.Black"];
        ButtonBackgroundColor = (Color)colorDict["Color.Boo3"];
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
