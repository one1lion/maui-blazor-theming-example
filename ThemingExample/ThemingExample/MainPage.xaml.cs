#if WINDOWS
using Microsoft.Maui.Handlers;
using ThemingExample.Platforms.Windows;
//using Xaml = Microsoft.UI.Xaml;
#endif

namespace ThemingExample;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

#if WINDOWS
        //WindowHandler.Mapper.AppendToMapping(nameof(IWindow), (handler, view) =>
        //{
        //    var pageContent = new Xaml.Controls.Grid();
        //    pageContent.RowDefinitions.Add(new() { Height = Xaml.GridLength.Auto });
        //    pageContent.RowDefinitions.Add(new() { Height = new Xaml.GridLength(1, Xaml.GridUnitType.Star) });
        //    var titleBar = new Xaml.Controls.Grid();

        //    titleBar.ColumnDefinitions.Add(new() { Width = new Xaml.GridLength(1, Xaml.GridUnitType.Star) });

        //    var titleText = new Xaml.Controls.Button() { Content = "Title Text" };
        //    titleBar.Children.Add(titleText);
        //    pageContent.Children.Add(titleBar);
        //    pageContent.Children.Add(BlazorUi);

        //    PageContent.RowDefinitions.Insert(0, new RowDefinition() { Height = GridLength.Auto });
        //    PageContent.Children.Insert(0, titleBar);
        //    PageContent.SetRow(BlazorUi, 1);
        //    PageContent.SetRow(titleBar, 1);

        //    var nativeWindow = handler.PlatformView;
        //    nativeWindow.ExtendsContentIntoTitleBar = true;
        //    nativeWindow.SetTitleBar(titleBar);
        //});
#endif
    }
}
