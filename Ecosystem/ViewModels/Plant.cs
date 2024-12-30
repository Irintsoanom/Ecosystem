using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Linq;
using System.Timers;

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
    private Timer seedTimer;
    private Random rand = new Random();

    public Plant(Point point, MainWindowViewModel mainWindowViewModel) : base(point)
    {
        this.rootArea = 300;
        this.seedZone = 256;
        this.mainWindowViewModel = mainWindowViewModel;
        this.seedTimer = new Timer(1000);
        this.seedTimer.Elapsed += OnTimerElapsed;
        this.seedTimer.Start();
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
        double newX = Location.X + rand.Next(-SeedZone, SeedZone);
        double newY = Location.Y + rand.Next(-SeedZone, SeedZone);

        // Limiter les coordonnées à l'espace de jeu
        newX = Math.Max(0, Math.Min(mainWindowViewModel.Width, newX));
        newY = Math.Max(0, Math.Min(mainWindowViewModel.Height, newY));

        Plant plant = new Plant(new Point(newX, newY), mainWindowViewModel);
        mainWindowViewModel.AddGameObject(plant);
    }
    private double VectorDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }

    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        SpreadSeed();
    }
}
