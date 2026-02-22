using Avalonia;
using ReactiveUI.Avalonia;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class AppBuilderImplementation<TApp> : IAppBuilderImplementation
    where TApp : Application, new()
{
    /// <inheritdoc />
    public AppBuilder ValueFor([NotNull] Action<ReactiveUIBuilder> withReactiveUiBuilder)
    {
        ArgumentNullException.ThrowIfNull(withReactiveUiBuilder);

        var win32PlatformOptions = new Win32PlatformOptions();

        return AppBuilder.Configure<TApp>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .With(win32PlatformOptions)
                         .UseReactiveUI(withReactiveUiBuilder);
    }
}