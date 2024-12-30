using Avalonia;
using Avalonia.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Timers;

namespace Ecosystem.ViewModels;

public partial class Meat : GameObject
{
    private Timer decayTimer = new Timer(5000);
    private MainWindowViewModel ecosystem;
    public Meat(Point location, MainWindowViewModel ecosystem) : base(location)
    {
        this.decayTimer.Elapsed += OnTimerElapsed;
        this.decayTimer.Start();
        Location = location;
        this.ecosystem = ecosystem;
    }
    private void Decay()
    {
        OrganicWaste organicWaste = new OrganicWaste(this.Location);
        ecosystem.AddGameObject(organicWaste);
        ecosystem.RemoveGameObject(this);
    }
    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        Decay();
    }
}