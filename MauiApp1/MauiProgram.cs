﻿using CommunityToolkit.Maui;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.Platform;
using SkiaSharp.Views.Maui.Controls.Hosting;
using ZXing.Net.Maui;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

#if ANDROID
[assembly: Android.App.UsesPermission(Android.Manifest.Permission.Camera)]
#endif

namespace MauiApp1;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseBarcodeReader()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            fonts.AddFont("fa-brands-400.ttf", "FontAwesomeBrands");
            fonts.AddFont("fa-regular-400.ttf", "FontAwesomeRegular");
            fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
            fonts.AddFont("Lato-Black.ttf", "LatoBlack");
            fonts.AddFont("Lato-BlackItalic.ttf", "LatoBlackItalic");
            fonts.AddFont("Lato-Bold.ttf", "LatoBold");
            fonts.AddFont("Lato-BoldItalic.ttf", "LatoBoldItalic");
            fonts.AddFont("Lato-Italic.ttf", "LatoItalic");
            fonts.AddFont("Lato-Light.ttf", "LatoLight");
            fonts.AddFont("Lato-LightItalic.ttf", "LatoLightItalic");
            fonts.AddFont("Lato-Regular.ttf", "LatoRegular");
            fonts.AddFont("Lato-Thin.ttf", "LatoThin");
            fonts.AddFont("Lato-ThinItalic.ttf", "LatoThinItalic");
        });
     //        builder.Services.AddMauiBlazorWebView();
#if WINDOWS
            builder.ConfigureLifecycleEvents(events =>
            {
                events.AddWindows(wndLifeCycleBuilder =>
                {
                    wndLifeCycleBuilder.OnWindowCreated(window =>
                    {
                        IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                        WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                        AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

                        const int width = 1200;
                        const int height = 800;
                        int x = 1920 / 2 - width / 2; //Convert.ToInt32(DeviceDisplay.MainDisplayInfo.Width)
                        int y = 1080 / 2 - height / 2; //Convert.ToInt32(DeviceDisplay.MainDisplayInfo.Height)

                        winuiAppWindow.MoveAndResize(new RectInt32(x, y, width, height));
                    });
                });
            });
#endif

        ModifyEntry();

        return builder.Build();
    }

    public static void ModifyEntry()
    {
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoMoreBorders", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
            handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
            handler.PlatformView.FontWeight = Microsoft.UI.Text.FontWeights.Thin;
#endif
        });
    }
}
