using Avalonia;
using Avalonia.ReactiveUI;

namespace EvilBaschdi.Avalonia.DummyAppMvvm;

// ReSharper disable once ClassNeverInstantiated.Global
internal class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    // ReSharper disable once MemberCanBePrivate.Global
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
                     .UsePlatformDetect()
                     .LogToTrace()
                     .UseReactiveUI()
                     .With(new Win32PlatformOptions
                           {
                               UseWindowsUIComposition = true,
                               EnableMultitouch = true,
                               CompositionBackdropCornerRadius = 8f
                           });
}