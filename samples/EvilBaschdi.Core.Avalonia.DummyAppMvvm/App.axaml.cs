using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using EvilBaschdi.Core.Avalonia.DependencyInjection;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.Views;
using EvilBaschdi.Core.Avalonia.Lifetime;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

/// <inheritdoc />
public class App : ApplicationWithSplash
{
    /// <inheritdoc />
    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    /// <inheritdoc />
    protected override bool ResizeWithBorder400 => true;

    /// <inheritdoc />
    protected override void PreMainWindowCreation()
    {
        ApplicationServices.AppName = Current?.Name;
    }

    /// <inheritdoc />
    protected override Window CreateMainWindow() => new MainWindow
                                                    {
                                                        DataContext = ApplicationServices.GetRequiredService<MainWindowViewModel>()
                                                    };
}