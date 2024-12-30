using Avalonia;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;

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
        lion = new Lion(new Point(Width / 2, Height / 2), this);
        GameObjects.Add(lion);
        rabbit = new Rabbit(new Point(Width / 3, Height / 3), this);
        GameObjects.Add(rabbit);
        
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
        lion.Move();
        rabbit.Move();
    }
}
