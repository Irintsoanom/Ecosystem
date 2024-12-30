using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;

namespace Ecosystem.ViewModels;

public partial class Plant : LivingCreature
{
    [ObservableProperty]
    private int rootArea;
    [ObservableProperty]
    private int seedZone;
    private MainWindowViewModel mainWindowViewModel;
    public double CenteredX => Location.X - RootArea / 2;
    public double CenteredY => Location.Y - RootArea / 2;

    public Plant(Point point, MainWindowViewModel mainWindowViewModel) : base(point)
    {
        this.rootArea = 128;
        this.mainWindowViewModel = mainWindowViewModel;
    }
    public void ConsumeOrganicWaste()
    {
        var wastes = mainWindowViewModel.GameObjects
            .OfType<OrganicWaste>()
            .Where(waste =>
                VectorDistance(waste.Location, this.Location) < this.RootArea)
            .ToList();

        foreach (var waste in wastes)
        {
            this.EnergyReserve += 20;
            mainWindowViewModel.RemoveGameObject(waste);
        }
    }
    private void SpreadSeed()
    {

    }
    private double VectorDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
}
