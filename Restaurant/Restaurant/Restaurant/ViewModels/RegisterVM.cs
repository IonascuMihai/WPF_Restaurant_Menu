using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Restaurant.Models;
using Restaurant.Utilities;

namespace Restaurant.ViewModels
{
    public class RegisterVM : MainVM
    {
        #region DataMembers
        private string name;
        private string surname;
        private string email;
        private string phone;
        private string address;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("surname");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("email");
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("phone");
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged("address");
            }
        }

        RestaurantConnString context = new RestaurantConnString();
        public RelayCommand RegisterUserCommand { get; private set; }
        public RelayCommand ClearFieldsCommand { get; private set; }
        #endregion
        public RegisterVM()
        {
            name = string.Empty;
            surname = string.Empty;
            email = string.Empty;
            phone = string.Empty;
            address = string.Empty;
            RegisterUserCommand = new RelayCommand(RegisterUser, CanRegisterUser);
            ClearFieldsCommand = new RelayCommand(ClearFields, CanClearFields);
        }
        #region RelayCommandFunctions
        public void RegisterUser(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            context.RegisterUser(Name, Surname, Email, Phone, Address, passBox.Password);
            context.SaveChanges();
            MessageBox.Show("User created succesfully.", "Registration complete!");
        }
        public bool CanRegisterUser(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            if (name != string.Empty && surname != string.Empty && phone != string.Empty && 
                email != string.Empty && address != string.Empty && passBox.Password != string.Empty)
                return true;
            return false;
        }
        public void ClearFields(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            Phone = string.Empty;
            Address = string.Empty;
            passBox.Password = string.Empty;
        }
        public bool CanClearFields(object obj)
        {
            PasswordBox passBox = (PasswordBox)obj;
            if (name != string.Empty || surname != string.Empty || phone != string.Empty ||
                email != string.Empty || address != string.Empty || passBox.Password != string.Empty)
                return true;
            return false;
        }
        #endregion
    }
}
