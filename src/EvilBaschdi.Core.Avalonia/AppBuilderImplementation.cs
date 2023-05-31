using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.ReactiveUI;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public class AppBuilderImplementation<TApp> : IAppBuilderImplementation
    where TApp : Application, new()
{
    /// <inheritdoc />
    public AppBuilder Value => AppBuilder.Configure<TApp>()
                                         .UsePlatformDetect()
                                         .LogToTrace()
                                         .With(new Win32PlatformOptions
                                               {
                                                   //UseWindowsUIComposition = true,
                                                   //CompositionBackdropCornerRadius = 8f,
                                                   UseWgl = RuntimeInformation.OSArchitecture == Architecture.Arm || RuntimeInformation.OSArchitecture == Architecture.Arm64
                                               })
                                         .UseReactiveUI();
}