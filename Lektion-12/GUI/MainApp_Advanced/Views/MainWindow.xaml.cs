using MainApp_Advanced.ViewModels;
using System;
using System.Windows;


namespace MainApp_Advanced.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
