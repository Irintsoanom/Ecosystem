using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class LivingCreature : GameObject
{
    [ObservableProperty]
    private int lifePoint;
    [ObservableProperty]
    private int energyReserve;
    [ObservableProperty]
    private Point startingPoint = new Point(1.0, 0);

    public LivingCreature(Point location):base(location) {
        
    }

    private void Feed()
    {

    }
    private void Reproduce()
    {

    }
}
