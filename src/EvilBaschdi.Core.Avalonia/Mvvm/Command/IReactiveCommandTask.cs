﻿using System.Reactive;

namespace EvilBaschdi.Core.Avalonia.Mvvm.Command;

/// <inheritdoc cref="ITaskRun" />
/// <inheritdoc cref="IInitReactiveCommand{TParam,TResult}" />
public interface IReactiveCommandTask<TParam> : IInitReactiveCommand<TParam, Unit>, ITaskRun;