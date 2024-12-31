using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Diagnostics;
using System.Linq;  

namespace Ecosystem.ViewModels;

public partial class Carnivore: Animal
{
    private MainWindowViewModel ecosystem;
    public Carnivore(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name) 
    { 
        this.ecosystem = ecosystem;
    }
    private void Attack()
    {
        var preyList = ecosystem.GameObjects
            .OfType<Herbivore>()
            .Where(prey =>
                VectorDistance(prey.Location, this.Location) < this.ContactZone)
            .ToList();

        foreach (var prey in preyList)
        {
            this.EnergyReserve += 40;
            ecosystem.RemoveGameObject(prey);
        }
    }
    private double VectorDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}