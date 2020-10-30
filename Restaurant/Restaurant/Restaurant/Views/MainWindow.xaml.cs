using Restaurant.ViewModels;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loginTab.IsSelected)
                DataContext = new LoginVM();
            else if (registerTab.IsSelected)
                DataContext = new RegisterVM();
            else if (menuTab.IsSelected && MainVM.loginInStatus == "CUSTOMER")
                DataContext = new CustomerMenuVM();
            else if (menuTab.IsSelected && MainVM.loginInStatus == "EMPLOYEE")
                DataContext = new EmployeeMenuVM();
            else if (menuTab.IsSelected && MainVM.loginInStatus == "You are not logged in")
                DataContext = new NoLoginMenuVM();
        }

    }
}
