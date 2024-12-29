using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Lion : Carnivore
{
    public Lion(Point location, MainWindowViewModel ecosystem) : base(location, ecosystem)
    {
        
    }
}
