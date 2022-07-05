namespace ThemingExample.ThemeManager.Themes;

public class BooTheme : ITheme
{
	public BooTheme(Resources.Styles.Colors colorDict)
    {
        PageBackgroundColor = (Color)colorDict["Color.Boo4"];
        PrimaryTextColor = (Color)colorDict["Color.White"];
        BarBackgroundColor = (Color)colorDict["Color.Boo5"];
        BarTextColor = (Color)colorDict["Color.Boo1"];
        ButtonBackgroundColor = (Color)colorDict["Color.Boo5"];
    }

    public Color PageBackgroundColor { get; }
    public Color PrimaryTextColor { get; }
    public Color BarBackgroundColor { get; }
    public Color BarTextColor { get; }
    public Color ButtonBackgroundColor { get; }
}
