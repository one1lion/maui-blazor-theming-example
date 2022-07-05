using ThemingExample.ThemeManager;

namespace ThemingExample.Resources.Themes;

public partial class ThemeResourceDictionary : ResourceDictionary, ITheme
{
    public ThemeResourceDictionary(ITheme theme)
    {
        var keepProps = new[]
        {
            typeof(Color),
            typeof(Brush)
        };
        var myProps = GetType().GetProperties().Where(x => keepProps.Contains(x.PropertyType));
        foreach (var curProp in theme.GetType().GetProperties().Where(x => keepProps.Contains(x.PropertyType)))
        {
            Add(curProp.Name, curProp.GetValue(theme));
            var myProp = myProps.Single(x => x.Name == curProp.Name);
            myProp.SetValue(this, curProp.GetValue(theme));
        }

        InitializeComponent();
    }


    public Color PageBackgroundColor { get; private set; }
    public Color PrimaryTextColor { get; private set; }
    public Color BarBackgroundColor { get; private set; }
    public Color BarTextColor { get; private set; }
    public Color ButtonBackgroundColor { get; private set; }
}