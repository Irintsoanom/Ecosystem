using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;  

namespace Ecosystem.ViewModels;

public partial class Herbivore : Animal
{
    private MainWindowViewModel ecosystem;
    public Herbivore(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location, ecosystem, sex, name) 
    {
        this.ecosystem = ecosystem;
    }
    public void ConsumePlants()
    {
        var plants = ecosystem.GameObjects
            .OfType<Plant>()
            .Where(plant =>
                VectorDistance(plant.Location, this.Location) < this.ContactZone)
            .ToList();

        foreach (var plant in plants)
        {
            this.EnergyReserve += 30;
            ecosystem.RemoveGameObject(plant);
        }
    }
    private double VectorDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
