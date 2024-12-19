﻿using Avalonia;
using System.Collections.ObjectModel;

namespace Ecosystem.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 1600;
    public int Height { get; } = 900;
    private Lion lion;
    private Rabbit rabbit;

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        lion = new Lion(new Point(Width / 2, Height / 2));
        GameObjects.Add(lion);
        rabbit = new Rabbit(new Point(Width / 3, Height / 3));
        GameObjects.Add(rabbit);
    }

    protected override void Tick()
    {
        lion.Move();
        rabbit.Move();
    }
}
