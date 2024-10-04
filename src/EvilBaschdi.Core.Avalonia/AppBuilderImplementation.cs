using Avalonia;
using Avalonia.ReactiveUI;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class AppBuilderImplementation<TApp> : IAppBuilderImplementation
    where TApp : Application, new()
{
    /// <inheritdoc />
    public AppBuilder Value
    {
        get
        {
            var win32PlatformOptions = new Win32PlatformOptions();

            return AppBuilder.Configure<TApp>()
                             .UsePlatformDetect()
                             .LogToTrace()
                             .With(win32PlatformOptions)
                             .UseReactiveUI();
        }
    }
}