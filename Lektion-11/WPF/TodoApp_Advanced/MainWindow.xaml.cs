using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TodoApp_Advanced.Shared.Models;

namespace TodoApp_Advanced;

public partial class MainWindow : Window
{
    private ObservableCollection<ActivityItem> _activities = [];
    private ActivityItem? _selectedItem;

    public MainWindow()
    {
        InitializeComponent();
        LV_Activities.ItemsSource = _activities;
        TB_Activity.Focus();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        HandleSave();
    }

    private void TB_Activity_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
            HandleSave();
    }

    private void HandleSave()
    {
        if (!string.IsNullOrWhiteSpace(TB_Activity.Text))
        {
            if (_selectedItem == null)
            {
                _activities.Add(new ActivityItem { Activity = TB_Activity.Text });
            }
            else
            {
                _selectedItem.Activity = TB_Activity.Text;
                LV_Activities.Items.Refresh();
                _selectedItem = null;
            }

            TB_Activity.Text = "";
            TB_Activity.Focus();
        }
    }

    private void Btn_Delete_Click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var activityItem = button?.DataContext as ActivityItem;

        if (activityItem != null)
            _activities.Remove(activityItem);

        TB_Activity.Focus();
    }

    private void LV_Activities_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (LV_Activities.SelectedItem is ActivityItem selectedItem)
        {
            _selectedItem = selectedItem;
            TB_Activity.Text = _selectedItem.Activity;
            TB_Activity.Focus();
        }
    }
}