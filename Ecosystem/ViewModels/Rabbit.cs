using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Rabbit : Herbivore
{
    public Rabbit(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name)
    {
        
    }
}
