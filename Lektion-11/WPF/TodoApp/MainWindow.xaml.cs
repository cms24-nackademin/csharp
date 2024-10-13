using System.Collections.ObjectModel;
using System.Windows;

namespace TodoApp;

public partial class MainWindow : Window
{
    private ObservableCollection<string> _activities = [];

    public MainWindow()
    {
        InitializeComponent();
        LV_Activities.ItemsSource = _activities;
        Input_Activity.Focus();
    }

    private void Btn_Save_Click(object sender, RoutedEventArgs e)
    {
        HandleSave();
    }

    private void Btn_Save_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
            HandleSave();
    }

    private void HandleSave()
    {
        var activity = Input_Activity.Text;

        if (!string.IsNullOrWhiteSpace(activity))
            _activities.Add(activity);

        Input_Activity.Text = "";
        Input_Activity.Focus();
    }
}