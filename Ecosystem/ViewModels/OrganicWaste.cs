using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Ecosystem.ViewModels;

public partial class OrganicWaste : GameObject
{
    public OrganicWaste(Point location) : base(location)
    {
        Location = location;
    }
}

