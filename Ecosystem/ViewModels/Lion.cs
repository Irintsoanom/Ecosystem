using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Lion : Carnivore
{
    public Lion(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name)
    {
        
    }
}
