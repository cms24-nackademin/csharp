using Shared.Models;
using Shared.Services;
using System.Collections.ObjectModel;
using System.Windows;


namespace MainApp;

public partial class MainWindow : Window
{
    private readonly CustomerService _customerService;
    private ObservableCollection<Customer> _customers = [];

    public MainWindow(CustomerService customerService)
    {
        InitializeComponent();
        _customerService = customerService;
        UpdateListView();
    }

    private void BtnSave_Click(object sender, RoutedEventArgs e)
    {
        var customer = new Customer
        {
            Name = InputName.Text,
            Email = InputEmail.Text
        };

        _customerService.AddToList(customer);
        InputName.Text = "";
        InputEmail.Text = "";

        UpdateListView();
    }

    private void UpdateListView()
    {
        _customers.Clear();
        foreach(var customer in _customerService.GetCustomers())
        {
            _customers.Add(customer);
        }

        LvCustomers.ItemsSource = _customers;
    }
}