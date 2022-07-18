using ThemingExample.ThemeManager;

namespace ThemingExample.Resources.Themes;

public partial class ThemeResourceDictionary : ResourceDictionary, ITheme
{
    public static IEnumerable<Type> KeepProps { get; } = new[]
    {
        typeof(Color),
        typeof(Brush)
    };
    
    public ThemeResourceDictionary(ITheme theme)
    {
        var myProps = GetType().GetProperties().Where(x => KeepProps.Contains(x.PropertyType));
        foreach (var curProp in theme.GetType().GetProperties().Where(x => KeepProps.Contains(x.PropertyType)))
        {
            Add(curProp.Name, curProp.GetValue(theme));
            var myProp = myProps.Single(x => x.Name == curProp.Name);
            myProp.SetValue(this, curProp.GetValue(theme));
        }

        InitializeComponent();
    }


    public Color PageBackgroundColor { get; private set; }
    public Color PrimaryTextColor { get; private set; }
    public Brush WindowCaptionBackground { get; private set; }
    public Brush WindowCaptionButtonBackground { get; private set; }
    public Brush WindowCaptionButtonBackgroundPointerOver { get; private set; }
    public Brush CloseButtonBackgroundPointerOver { get; private set; }
    public Color BarTextColor { get; private set; }
    public Color ButtonBackgroundColor { get; private set; }
}