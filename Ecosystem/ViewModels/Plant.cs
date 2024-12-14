using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Plant : LivingCreature
{
    [ObservableProperty]
    private int rootArea;
    [ObservableProperty]
    private int seedZone;
    public Plant(Point point) : base(point)
    {

    }
}
