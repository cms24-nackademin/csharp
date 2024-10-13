using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using System.Collections.ObjectModel;

namespace Shared.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<ActivityItem> _activities = [];

    [ObservableProperty]
    private ActivityItem _currentItem = new();

    [RelayCommand]
    public void Save()
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(CurrentItem.Activity))
                Activities.Add(CurrentItem);

            CurrentItem = new();
        }
        catch (Exception ex) { }
    }

    [RelayCommand]
    public void Delete(ActivityItem item)
    {
        try
        {
            Activities.Remove(item);
        }
        catch (Exception ex) { }
    }

}
