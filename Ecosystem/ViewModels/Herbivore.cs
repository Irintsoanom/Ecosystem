using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Herbivore : Animal
{
    public Herbivore(Point location, MainWindowViewModel ecosystem) : base(location, ecosystem) 
    {
        
    }
    private void Flee()
    {

    }
}
