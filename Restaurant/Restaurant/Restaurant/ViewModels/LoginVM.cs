using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.ViewModels
{
    public class LoginVM : MainVM
    {
        #region DataMembers
        private string username;
        public static int userId { get; set; }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged("username");
            }
        }

        #endregion
        RestaurantConnString context = new RestaurantConnString();
        public RelayCommand LogInCommand { get; private set; }
        public RelayCommand ClearFieldCommand { get; private set; }
        public LoginVM()
        {
            username = string.Empty;
            LogInCommand = new RelayCommand(LogIn, CanLogIn);
            ClearFieldCommand = new RelayCommand(ClearField, CanClearField);
            userId = -1;
        }
        #region RelayCommandFunctions
        public void LogIn(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            var returnedEmail = context.CheckEmailAndPassword(Username, passBox.Password).ToList();
            if (returnedEmail.Count != 0)
            {
                foreach (var user in returnedEmail)
                {
                    userId = user.id_user;
                    if (user.email.Contains("@restaurant.com"))
                    {
                        loginInStatus = "EMPLOYEE";
                    }
                    else
                    {
                        loginInStatus = "CUSTOMER";
                    }
                    DisplayLogInStatus = "You are logged in as " + loginInStatus + ": " + user.email;
                    MessageBox.Show("You are now logged in.", "Authentication succesful!");
                }
            }
            else
            {
                MessageBox.Show("No account of given creditentials was found.", "Authentication failed!");
            }
        }
        public bool CanLogIn(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            if (username != string.Empty && passBox.Password != string.Empty)
                return true;
            return false;
        }

        public void ClearField(object obj)
        {
            Username = string.Empty;
            PasswordBox passBox = (PasswordBox)obj;
            passBox.Password = string.Empty;           
        }
        public bool CanClearField(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            if (username != string.Empty || passBox.Password != string.Empty)
                return true;
            return false;
        }
        #endregion
    }
}
