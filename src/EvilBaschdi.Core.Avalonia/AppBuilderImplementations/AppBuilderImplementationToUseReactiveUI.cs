using Avalonia;
using ReactiveUI.Avalonia;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia.AppBuilderImplementations;

/// <inheritdoc />
// ReSharper disable once InconsistentNaming
public class AppBuilderImplementationToUseReactiveUI<TApp> : IAppBuilderImplementationToUseReactiveUI
    where TApp : Application, new()
{
    /// <inheritdoc />
    public AppBuilder ValueFor([NotNull] Action<ReactiveUIBuilder> withReactiveUiBuilder)
    {
        ArgumentNullException.ThrowIfNull(withReactiveUiBuilder);

        return AppBuilder.Configure<TApp>()
                         .UsePlatformDetect()
                         .LogToTrace()
                         .UseReactiveUI(withReactiveUiBuilder);
    }
}