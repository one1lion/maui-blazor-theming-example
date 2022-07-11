using ThemingExample.BlazorUi.Shared;
using ThemingExample.Shared.Skinning;

namespace ThemingExample.BlazorUi.Extensions;

public static class SkinExtensions
{
    public static Type GetLayoutType(this Skin skin) => skin switch
    {
        Skin.AspNetPages => typeof(AspNetLayout),
        _ => typeof(MainLayout)
    };
}
