using Restaurant.ViewModels;
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

namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for EmployeeMenuView.xaml
    /// </summary>
    public partial class EmployeeMenuView : UserControl
    {
        public EmployeeMenuView()
        {
            InitializeComponent();
        }

        private void AddToMenu_Click(object sender, RoutedEventArgs e)
        {
            AddToMenuView addToMenuView = new AddToMenuView();
            addToMenuView.Show();
        }

        private void EditFoodItem_Click(object sender, RoutedEventArgs e)
        {
            if (productList.SelectedIndex != -1)
            {
                EditFoodItemView editFoodItemView = new EditFoodItemView();
                editFoodItemView.DataContext = new EditFoodItemVM(productList.SelectedIndex);
                editFoodItemView.Show();
            }   
        }
        private void EditMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (menuList.SelectedIndex != -1)
            {
                EditMenuItemView editMenuItemView = new EditMenuItemView();
                editMenuItemView.DataContext = new EditMenuItemVM(menuList.SelectedIndex);
                editMenuItemView.Show();
            }
        }

        private void SeeOrders_Click(object sender, RoutedEventArgs e)
        {
            EmployeeOrdersView employeeOrdersView = new EmployeeOrdersView();
            employeeOrdersView.Show();
        }

        private void SeeLowStock_Click(object sender, RoutedEventArgs e)
        {
            LowStockView lowStockView = new LowStockView();
            lowStockView.Show();
        }
    }
}
