using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Ecosystem.ViewModels;

public partial class Animal : LivingCreature
{
    [ObservableProperty]
    private int viewArea;
    [ObservableProperty]
    private int contactZone;
    [ObservableProperty]
    private string sex;
    [ObservableProperty]
    private string name;
    
    private int xVelocity;
    private int yVelocity;

    
    private Point velocity;

    public static readonly Random rand = new Random();
    private List<int> randVelocity = new List<int>() { -2, -1, 1, 2 };

    private MainWindowViewModel ecosystem;


    public Animal(Point location, MainWindowViewModel ecosystem, string sex, string name) : base(location)
    {
        this.name = name;
        this.sex = sex;
        this.contactZone = 50;
        this.viewArea = 150;
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
    public void Reproduce()
    {
        var animals = ecosystem.GameObjects
            .OfType<Animal>()
            .Where(animal =>
                VectorDistance(animal.Location, this.Location) < this.ContactZone)
            .ToList();

        foreach (var animal in animals)
        {
            if(this.Sex != animal.Sex && this.Name == animal.Name)
            {
                double newX = Location.X + rand.Next(-ContactZone, ContactZone);
                double newY = Location.Y + rand.Next(-ContactZone, ContactZone);

                newX = Math.Max(0, Math.Min(ecosystem.Width, newX));
                newY = Math.Max(0, Math.Min(ecosystem.Height, newY));


                if(this.Name == "Lion")
                {
                    Lion lion = new Lion(new Point(newX, newY), ecosystem, "Male", "Lion");
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        ecosystem.AddGameObject(lion);
                    });
                }
                else
                {
                    Rabbit rabbit = new Rabbit(new Point(newX, newY), ecosystem, "Male", "Rabbit");
                    Avalonia.Threading.Dispatcher.UIThread.Post(() =>
                    {
                        ecosystem.AddGameObject(rabbit);
                    });
                }
            }
        }
    }
    private double VectorDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
    }
    public void Die()
    {
        Meat meat = new Meat(this.Location, ecosystem);
        ecosystem.AddGameObject(meat);
        ecosystem.RemoveGameObject(this);
    }
}
