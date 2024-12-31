using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Herbivore : Animal
{
    public Herbivore(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name) 
    {
        
    }
    private void Flee()
    {

    }
}
