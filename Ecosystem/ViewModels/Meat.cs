using Avalonia;
using Avalonia.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Timers;

namespace Ecosystem.ViewModels;

public partial class Meat : GameObject
{
    private Timer decayTimer = new Timer(3000);
    public Meat(Point location) : base(location)
    {
        this.decayTimer.Elapsed += OnTimerElapsed;
        this.decayTimer.Start();
        Location = location;
    }
    private void Decay()
    {

    }
    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        Decay();
    }
}