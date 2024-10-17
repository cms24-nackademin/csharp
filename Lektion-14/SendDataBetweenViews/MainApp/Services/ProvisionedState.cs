using MainApp.ViewModels;

namespace MainApp.Services;

public static class ProvisionedState
{
    public static Product CurrentProduct { get; set; } = null!;
}
