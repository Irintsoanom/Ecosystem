using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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

    private MainWindowViewModel ecosystem;


    public Animal(Point location, MainWindowViewModel ecosystem) : base(location)
    {
        this.sex = "Male";
        this.xVelocity = rand.Next(randVelocity.Count);
        this.yVelocity = rand.Next(randVelocity.Count);
        this.velocity = new Point(randVelocity[xVelocity], randVelocity[yVelocity]);
        this.ecosystem = ecosystem;
    }

    public void Move()
    {
        Location = Location + velocity;
        if (Location.X <= 25 || Location.X >= 1550) 
        {
            velocity = new Point(-velocity.X, velocity.Y);
            Location = new Point(
                Math.Clamp(Location.X, 50, 1550),
                Location.Y
            );
        }

        if (Location.Y <= 0 || Location.Y >= 850) 
        {
            velocity = new Point(velocity.X, -velocity.Y);
            Location = new Point(
                Location.X,
                Math.Clamp(Location.Y, 0, 850)
            );
        }

    }
    public void Defecate()
    {
        OrganicWaste organicWaste = new OrganicWaste(this.Location);
        ecosystem.AddGameObject(organicWaste);
    }
    public void Die()
    {
        Meat meat = new Meat(this.Location, ecosystem);
        ecosystem.AddGameObject(meat);
        ecosystem.RemoveGameObject(this);
    }
}
