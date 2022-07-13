using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.ComponentModel;
using ThemingExample.BlazorUi.Extensions;
using ThemingExample.Shared.State;

namespace ThemingExample.BlazorUi;

public partial class Main
{
    [Inject] private PreferencesState PreferencesState { get; set; } = default!;
    [Inject] private IJSRuntime JsRuntime { get; set; } = default!;

    private Type _layoutType = typeof(BlazorHybridSkin.Shared.MainLayout);
    private static List<string> _cssClassProps = new()
    {
        nameof(Shared.State.PreferencesState.ActiveTheme),
        nameof(Shared.State.PreferencesState.ActiveSkin)
    };
    private ValueTask<IJSObjectReference> _module => JsRuntime.InvokeAsync<IJSObjectReference>("import", "/_content/ThemingExample.BlazorUi.SharedComponents/js/main-layout-funcs.js");
    private bool _hasRendered;
    protected override void OnInitialized()
    {
        _layoutType = PreferencesState.ActiveSkin.GetLayoutType();
        PreferencesState.AllowSkinChange = true;
        PreferencesState.PropertyChanged += HandlePreferenceChanged;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _hasRendered = true;
            await UpdateBodyClasses();
            await ApplySkinLayout();
        }
    }

    private void HandlePreferenceChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_cssClassProps.Contains(e.PropertyName ?? string.Empty))
        {
            Task.Run(() => UpdateBodyClasses());
            if (e.PropertyName == nameof(PreferencesState.ActiveSkin))
            {
                Task.Run(() => ApplySkinLayout());
            }
        }
    }

    private Task ApplySkinLayout()
    {
        _layoutType = PreferencesState.ActiveSkin.GetLayoutType();

        return InvokeAsync(StateHasChanged);
    }

    private async Task UpdateBodyClasses()
    {
        if (!_hasRendered)
        {
            return;
        }

        var module = await _module;
        await module.InvokeAsync<object>("setThemeClass", PreferencesState.ActiveTheme.ToString());
        await module.InvokeAsync<object>("setSkinClass", PreferencesState.ActiveSkin.ToString());
    }
}