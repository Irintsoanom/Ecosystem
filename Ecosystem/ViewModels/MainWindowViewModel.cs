using Avalonia;
using System.Collections.ObjectModel;

namespace Ecosystem.ViewModels;

public partial class MainWindowViewModel : GameBase
{
    public int Width { get; } = 800;
    public int Height { get; } = 450;
    private Ball ball;
    private Lion lion;

    // Liste des objets à afficher
    public ObservableCollection<GameObject> GameObjects { get; } = new();

    public MainWindowViewModel() {
        ball = new Ball(new Point(Width/2-32, Height/2-32));
        GameObjects.Add(ball);
        lion = new Lion(new Point(Width / 2, Height / 2));
        GameObjects.Add(lion);
    }

    protected override void Tick()
    {
        ball.Tick();
        lion.Move();
    }
}
