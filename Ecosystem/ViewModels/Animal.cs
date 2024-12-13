using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class Animal : LivingCreature
{
    [ObservableProperty]
    private int viewArea;
    [ObservableProperty]
    private int contactZone;
    [ObservableProperty]
    private string sex;

    public Animal(Point location) : base(location)
    {
        this.sex = "Male";
    }

    private void Move()
    {

    }
    private void Defecate()
    {

    }

}
