namespace ThemingExample.ThemeManager.Themes;

public class BooTheme : ITheme
{
	public BooTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Boo4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        WindowCaptionBackground = new SolidColorBrush((Color)colorDict["Color.Boo5"]);
        WindowCaptionButtonBackground = new SolidColorBrush((Color)colorDict["Color.Boo5"]);
        WindowCaptionButtonBackgroundPointerOver = new SolidColorBrush((Color)colorDict["Color.Boo5"]);
        CloseButtonBackgroundPointerOver = new SolidColorBrush((Color)colorDict["Color.Boo5"]);
        BarTextColor = (Color)colorDict["Color.Boo1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Boo5"];
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
