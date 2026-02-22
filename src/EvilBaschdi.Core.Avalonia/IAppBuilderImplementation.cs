using Avalonia;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
// ReSharper disable once InconsistentNaming
public interface IAppBuilderImplementationToUseReactiveUI : IValueFor<Action<ReactiveUIBuilder>, AppBuilder>;