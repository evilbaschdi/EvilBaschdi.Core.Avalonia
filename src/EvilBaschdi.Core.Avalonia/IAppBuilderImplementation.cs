using Avalonia;
using ReactiveUI.Builder;

namespace EvilBaschdi.Core.Avalonia;

/// <inheritdoc />
public interface IAppBuilderImplementation : IValueFor<Action<ReactiveUIBuilder>, AppBuilder>;