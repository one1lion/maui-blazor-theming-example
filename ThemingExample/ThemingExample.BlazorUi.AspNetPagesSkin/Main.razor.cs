using Microsoft.AspNetCore.Components;
using ThemingExample.Shared.State;

namespace ThemingExample.BlazorUi.AspNetPagesSkin;

public partial class Main
{
    [Inject] private PreferencesState PreferencesState { get; set; } = default!;

    protected override void OnInitialized()
    {
        PreferencesState.ActiveSkin = ThemingExample.Shared.Skinning.Skin.AspNetPages;
    }
}