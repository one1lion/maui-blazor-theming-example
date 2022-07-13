using System.Reflection;
using ThemingExample.Shared.Skinning;

namespace ThemingExample.BlazorUi.Extensions;

public static class SkinExtensions
{
    private static Assembly[]? _loadedRouteAssemblies;
    public static Type GetLayoutType(this Skin skin) => skin switch
    {
        Skin.AspNetPages => typeof(AspNetPagesSkin.Shared.MainLayout),
        _ => typeof(BlazorHybridSkin.Shared.MainLayout)
    };

    public static Assembly[] GetAssemblies()
    {
        if (_loadedRouteAssemblies is null)
        {
            _loadedRouteAssemblies = Enum.GetValues<Skin>()
                .Select(x => x.GetLayoutType().Assembly)
                .ToArray();
        }
        return _loadedRouteAssemblies;
    }
}
