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
    public class EditFoodItemVM: INotifyViewModel
    {
        #region DataMembers
        private string foodItemName;
        private float foodItemPrice;
        private float menuQty;
        private float restaurantQty;
        private string oldName;
        public RelayCommand CommitChangeCommand  { get; private set; }
        RestaurantConnString context = new RestaurantConnString();
        public string FoodItemName
        {
            get
            {
                return foodItemName;
            }
            set
            {
                foodItemName = value;
                OnPropertyChanged("foodItemName");
            }
        }
        public float FoodItemPrice
        {
            get
            {
                return foodItemPrice;
            }
            set
            {
                foodItemPrice = value;
                OnPropertyChanged("foodItemPrice");
            }
        }
        public float RestaurantQty
        {
            get
            {
                return restaurantQty;
            }
            set
            {
                restaurantQty = value;
                OnPropertyChanged("restaurantQty");
            }
        }
        public float MenuQty
        {
            get
            {
                return menuQty;
            }
            set
            {
                menuQty = value;
                OnPropertyChanged("menuQty");
            }
        }
        #endregion
        public EditFoodItemVM(int chosenFoodItemIndex)
        {
            CommitChangeCommand = new RelayCommand(CommitChange, RelayCommand.UniversallyTrueCanExecute);
            foodItemName = EmployeeMenuVM.preparateList[chosenFoodItemIndex].PreparatName;
            oldName = foodItemName;
            foodItemPrice = float.Parse(EmployeeMenuVM.preparateList[chosenFoodItemIndex].PreparatPrice);
            menuQty = float.Parse(EmployeeMenuVM.preparateList[chosenFoodItemIndex].CantitateMeniu);
            restaurantQty = float.Parse(EmployeeMenuVM.preparateList[chosenFoodItemIndex].CantitateTotala);
        }
        public EditFoodItemVM()
        {

        }
        public void CommitChange(object obj)
        {
            Window window = (Window)obj;
            context.UpdatePreparat(foodItemName, foodItemPrice, menuQty, restaurantQty, oldName);
            window.Close();
            EmployeeMenuVM.InitialiseComponents();
            MessageBox.Show("Change completed");        
        }
    }
}
