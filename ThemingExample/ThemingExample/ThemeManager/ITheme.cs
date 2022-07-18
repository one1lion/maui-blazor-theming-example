namespace ThemingExample.ThemeManager;

public interface ITheme
{
    Brush WindowCaptionBackground { get; }
    Brush WindowCaptionButtonBackground { get; }
    Brush WindowCaptionButtonBackgroundPointerOver { get; }
    Brush CloseButtonBackgroundPointerOver { get; }
    Color PageBackgroundColor { get; }
    Color PrimaryTextColor { get; }
    Color BarTextColor { get; }
    Color ButtonBackgroundColor { get; }
}
