using MainApp.Models;
using System.Collections.ObjectModel;

namespace MainApp;

public partial class MainPage : ContentPage
{
    private ObservableCollection<ActivityItem> _activities = [];

    public MainPage()
    {
        InitializeComponent();
        CvActivities.ItemsSource = _activities;
    }

    private void BtnSave_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(InputActivity.Text))
                _activities.Add(new ActivityItem { Activity = InputActivity.Text });

            InputActivity.Text = "";
        }
        catch (Exception ex) { }
    }

    private void BtnDelete_Clicked(object sender, EventArgs e)
    {
        try
        {
            var button = (Button)sender;
            var context = button.BindingContext;
            var activtyItem = (ActivityItem)context;

            _activities.Remove(activtyItem);
        }
        catch (Exception ex) { }
    }
}
