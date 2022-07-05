using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ThemingExample.Shared.Helpers;

public abstract class BaseNotifyPropertyChanges : INotifyPropertyChanging, INotifyPropertyChanged, IDisposable
{
    public event PropertyChangingEventHandler? PropertyChanging;
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void RaisePropertyChanging([CallerMemberName] string? name = default)
    {
        var e = new PropertyChangingEventArgs(name);
        PropertyChanging?.Invoke(this, e);
    }

    protected void RaisePropertyChanging(object? sender, PropertyChangingEventArgs e)
    {
        PropertyChanging?.Invoke(sender, e);
    }

    protected void RaisePropertyChanged([CallerMemberName] string? name = default)
    {
        var e = new PropertyChangedEventArgs(name);
        PropertyChanged?.Invoke(this, e);
    }

    protected void RaisePropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(sender, e);
    }

    protected void SetProperty<T>(ref T storage, T value, [CallerMemberName] string? name = default)
    {
        if (storage?.Equals(value) ?? false) { return; }
        RaisePropertyChanging(name);
        storage = value;
        RaisePropertyChanged(name);
    }

    private void UnsubAll()
    {
        PropertyChanged = null;
        PropertyChanging = null;
    }

    public void Dispose()
    {
        UnsubAll();
        AdditionalDispose();
    }

    protected virtual void AdditionalDispose() { }
}
