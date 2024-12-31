using Avalonia;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Ecosystem.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1600;
    public int Height { get; } = 900;
    private Lion lion;
    private Rabbit rabbit;
    private Lion lion2;
    private Rabbit rabbit2;
    private List<Plant> plantList;
    private Random rand = new Random();
    private Timer poopTimer = new Timer(2000);

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion = new Lion(new Point(Width / 2, Height / 2), this, "Male", "Lion");
        GameObjects.Add(lion);
        rabbit = new Rabbit(new Point(Width / 3, Height / 3), this, "Male", "Rabbit");
        GameObjects.Add(rabbit);
        lion2 = new Lion(new Point(Width / 2, Height / 2), this, "Female", "Lion");
        GameObjects.Add(lion2);
        rabbit2 = new Rabbit(new Point(Width / 3, Height / 3), this, "Female", "Rabbit");
        GameObjects.Add(rabbit2);
        this.poopTimer.Elapsed += OnTimerElapsed;
        this.poopTimer.Start();

        plantList = new List<Plant>();
        for(int i = 0; i < 5; i++)
        {
            Plant plant = new Plant(new Point(rand.Next(Width), rand.Next(Height)), this);
            plantList.Add(plant);
            GameObjects.Add(plantList[i]);
        }

    }
    public void AddGameObject(GameObject gameObject)
    {
        GameObjects.Add(gameObject);
    }
    public void RemoveGameObject(GameObject gameObject)
    {
        GameObjects.Remove(gameObject);
    }
    protected override void Tick()
    {
        var gameObjectsCopy = GameObjects.ToList();
        foreach (GameObject gameObject in gameObjectsCopy)
        {
            if (gameObject is Animal animal)
            {
                animal.Move();
                animal.Reproduce();
                if(animal is Lion lion)
                {
                    lion.Hunt();
                }
                else if (animal is Rabbit rabbit)
                {
                    rabbit.ConsumePlants();
                }
            } else if(gameObject is Plant plant)
            {
                plant.ConsumeOrganicWaste();
            }
        }
    }
    private void OnTimerElapsed(object? sender, EventArgs e)
    {
        var gameObjectsCopy = GameObjects.ToList();
        foreach (GameObject gameObject in gameObjectsCopy)
        {
            if (gameObject is Animal animal)
            {
                animal.Defecate();
            }
        }
    }
}
