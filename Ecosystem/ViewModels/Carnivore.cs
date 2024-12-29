﻿using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Carnivore: Animal
{
    public Carnivore(Point location, MainWindowViewModel ecosystem) : base(location, ecosystem) 
    { 
        
    }
    private void Attack()
    {

    }
}