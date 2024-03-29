using Avalonia.Controls;
using Avalonia.Controls.Templates;
using EvilBaschdi.Core.Avalonia.DummyAppMvvm.ViewModels;

namespace EvilBaschdi.Core.Avalonia.DummyAppMvvm;

public class ViewLocator : IDataTemplate
{
    public Control Build(object? data)
    {
        var name = data?.GetType().FullName!.Replace("ViewModel", "View");
        if (name == null)
        {
            return new TextBlock { Text = "View Not Found" };
        }

        var type = Type.GetType(name);

        if (type != null)
        {
            return (Control)Activator.CreateInstance(type)!;
        }

        return new TextBlock { Text = "Not Found: " + name };
    }

    public bool Match(object? data)
    {
        return data is ViewModelBase;
    }
}