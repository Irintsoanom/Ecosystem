using Avalonia;
using Avalonia.Metadata;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Timers;

namespace Ecosystem.ViewModels;

public partial class Meat
{
    private Timer decayTimer = new Timer(3000);
    public Meat()
    {
        this.decayTimer.Elapsed += OnTimerElapsed;
    }
    private void Decay()
    {

    }
    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        Decay();
    }
}