using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Diagnostics;
using System.Timers;

namespace Ecosystem.ViewModels;

public partial class LivingCreature : GameObject
{
    [ObservableProperty]
    private int lifePoint;
    [ObservableProperty]
    private int energyReserve;
    [ObservableProperty]
    private Point startingPoint = new Point(1.0, 0);
    private Timer lifeTimer = new Timer(1000);

    public LivingCreature(Point location):base(location) 
    {
        this.lifePoint = 1;
        this.energyReserve = 100;

        this.lifeTimer.Elapsed += OnTimerElapsed;
        this.lifeTimer.Start();
    }

    private void Feed()
    {

    }
    private void Reproduce()
    {

    }
    private void DrecreaseEnergy()
    {
        if (this.EnergyReserve > 0)
        {
            this.EnergyReserve -= 10;
        }
        else if (this.LifePoint > 0)
        {
            this.LifePoint -= 1;
            this.EnergyReserve = 100;
        }
        
    }

    private void OnTimerElapsed(object? sender, EventArgs e) 
    {
        DrecreaseEnergy();

        if (this.LifePoint == 0 && this is Animal animal)
        {
            animal.Die();
            this.lifeTimer.Stop();
        }
    }
}
