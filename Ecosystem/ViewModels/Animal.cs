using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

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
    

    public Animal(Point location) : base(location)
    {
        this.sex = "Male";
        this.xVelocity = rand.Next(-1, 2);
        this.yVelocity = rand.Next(-1, 2);
        this.velocity = new Point(xVelocity, yVelocity);
    }

    public void Move()
    {
        Location = Location + velocity;
    }
    private void Defecate()
    {

    }

}
