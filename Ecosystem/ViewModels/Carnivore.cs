using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace Ecosystem.ViewModels;

public partial class Carnivore: Animal
{
    public Carnivore(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name) 
    { 

    }
    private void Attack()
    {

    }
}