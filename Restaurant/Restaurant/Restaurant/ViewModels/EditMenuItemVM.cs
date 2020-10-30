using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.ViewModels
{
    class EditMenuItemVM :INotifyViewModel
    {
        public RelayCommand CommitChangeCommand { get; private set; }
        RestaurantConnString context = new RestaurantConnString();
        private string menuItemName;
        private string oldName;
        public string MenuItemName
        {
            get
            {
                return menuItemName;
            }
            set
            {
                menuItemName = value;
                OnPropertyChanged("menuItemName");
            }
        }
        public EditMenuItemVM()
        {

        }
        public EditMenuItemVM(int selectedMenuItemIndex)
        {
            CommitChangeCommand = new RelayCommand(CommitChange, RelayCommand.UniversallyTrueCanExecute);
            menuItemName = EmployeeMenuVM.menuList[selectedMenuItemIndex].MenuName;
            oldName = menuItemName;
        }

        private void CommitChange(object obj)
        {
            Window window = (Window)obj;
            context.UpdateMeniu(menuItemName, oldName);
            window.Close();
            EmployeeMenuVM.InitialiseComponents();
            MessageBox.Show("Change completed");
        }
    }
}
