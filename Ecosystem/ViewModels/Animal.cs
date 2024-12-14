using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace Ecosystem.ViewModels;

public partial class Animal : LivingCreature
{
    [ObservableProperty]
    private int viewArea;
    [ObservableProperty]
    private int contactZone;
    [ObservableProperty]
    private string sex;
    
    private int xVelocity;
    private int yVelocity;

    
    private Point velocity;

    public static readonly Random rand = new Random();
    private List<int> randVelocity = new List<int>() { -2, -1, 1, 2 };
    

    public Animal(Point location) : base(location)
    {
        this.sex = "Male";
        this.xVelocity = rand.Next(randVelocity.Count);
        this.yVelocity = rand.Next(randVelocity.Count);
        this.velocity = new Point(randVelocity[xVelocity], randVelocity[yVelocity]);
    }

    public void Move()
    {
        Location = Location + velocity;
    }
    private void Defecate()
    {

    }

}
