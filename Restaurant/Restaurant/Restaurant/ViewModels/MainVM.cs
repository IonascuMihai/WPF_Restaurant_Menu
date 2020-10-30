using Restaurant.Utilities;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.ViewModels
{
    public class MainVM : INotifyViewModel
    {
        #region DataMembers
        public static string loginInStatus = "You are not logged in"; 
        public static string displayLogInStatus =  "You are not logged in";
        public RelayCommand LogOutCommand { get; private set; }
        public RelayCommand OpenOrdersCommand { get; private set; }
        public string DisplayLogInStatus
        {
            get
            {
                return displayLogInStatus;
            }
            set
            {
                displayLogInStatus = value;
                OnPropertyChanged("displayLogInStatus");
            }
        }
        #endregion

        public MainVM()
        {
            LogOutCommand = new RelayCommand(LogOut, CanLogOut);
            OpenOrdersCommand = new RelayCommand(OpenOrders, CanOpenOrders);
        }

        #region RelayCommandFunctions
        public void LogOut(object obj)
        {
            loginInStatus = "You are not logged in"; 
            DisplayLogInStatus = "You are not logged in";
            MessageBox.Show("You are now logged out", "Succesfull log out.");
            LoginVM.userId = -1;
        }
        public bool CanLogOut(object obj)
        {
            if (displayLogInStatus != "You are not logged in")
                return true;
            return false;
        }
        private void OpenOrders(object obj)
        {
            OrderView orderView = new OrderView();
            orderView.DataContext = new OrderViewModel();
            orderView.Show();
        }

        private bool CanOpenOrders(object obj)
        {
            if (loginInStatus == "CUSTOMER")
                return true;
            return false;
        }
        #endregion
    }
}
