using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using System.ComponentModel;
using ThemingExample.BlazorUi;
using Windows.Graphics;
using AppWindow = Microsoft.UI.Windowing.AppWindow;
using Border = Microsoft.UI.Xaml.Controls.Border;
using Color = Windows.UI.Color;
using Colors = Microsoft.UI.Colors;
using Grid = Microsoft.UI.Xaml.Controls.Grid;
using Rect = Windows.Foundation.Rect;
using Size = Windows.Foundation.Size;
using SolidColorBrush = Microsoft.UI.Xaml.Media.SolidColorBrush;
using Thickness = Microsoft.UI.Xaml.Thickness;
using Visibility = Microsoft.UI.Xaml.Visibility;
using Win32Interop = Microsoft.UI.Win32Interop;
using Window = Microsoft.UI.Xaml.Window;

namespace ThemingExample.WinUI;

public partial class MainWindow : Window
{
    private BlazorWebView _blazWebView;
    public MainWindow()
	{
		InitializeComponent();
        /*
        <maui:BlazorWebView x:Name="BlazorUi" HostPage="wwwroot/index.html">
            <maui:BlazorWebView.RootComponents>
                <maui:RootComponent Selector="#app" ComponentType="{y:Type local:Main}" />
            </maui:BlazorWebView.RootComponents>
        </maui:BlazorWebView>
         */
        //_blazWebView = new BlazorWebView()
        //{
        //    HostPage = "wwwroot/index.html"
        //};

        var rootComp = new RootComponent
        {
            ComponentType = typeof(Main),
            Selector = "#app"
        };
        //((BlazorWebView)MainBlazorUi).RootComponents.Add(rootComp);
        //_blazWebView.RootComponents.Add(rootComp);
        //_blazWebView.HandlerChanged += HandleWebViewHandlerChanged;



        //MainLayout.Children.Add(blazWebView);

        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
    }

    private void HandleWebViewHandlerChanged(object sender, EventArgs e)
    {
        if(_blazWebView.Handler is null) { return; }
        //MainLayout.Children.Add(_blazWebView.);
    }
}