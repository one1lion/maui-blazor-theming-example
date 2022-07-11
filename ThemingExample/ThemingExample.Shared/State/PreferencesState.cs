using ThemingExample.Shared.Skinning;
using ThemingExample.Shared.Theming;

namespace ThemingExample.Shared.State;

public class PreferencesState : BaseState
{
    // private readonly IPreferencesService _preferencesService;
    private bool _initializing;
    private bool _initialized;
    public PreferencesState(/* IPreferencesService perferencesService */)
    {
        //_perferencesService = perferencesService;
    }

    public async Task Initialize()
    {
        if (_initializing || _initialized) { return; }

        _initializing = true;
        try
        {
            // var prefs = await _perferencesService.GetUserPreferences();
            // ActiveTheme = prefs.ActiveTheme;
            await Task.Delay(300);
            _initialized = true;
        }
        catch (Exception)
        {
            // TODO: Handle error
        }
        finally
        {
            _initializing = false;
        }

    }

    private ColorTheme _activeTheme = ColorTheme.Kohii;
    public ColorTheme ActiveTheme { get => _activeTheme; set => SetProperty(ref _activeTheme, value); }

    private Skin _activeSkin = Skin.BlazorStandard;
    public Skin ActiveSkin { get => _activeSkin; set => SetProperty(ref _activeSkin, value); }
}
