using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.ViewModels
{
    class ChangeOrderStatusVM: INotifyViewModel
    {
        RestaurantConnString context = new RestaurantConnString();
        private ObservableCollection<string> orderStates;
        public RelayCommand ApplyChangeCommand { get; private set; }
        public ObservableCollection<string> OrderStates
        {
            get
            {
                return orderStates;
            }
            set
            {
                orderStates = value;
                OnPropertyChanged("orderStates");
            }
        }

        public ChangeOrderStatusVM()
        {
            ApplyChangeCommand = new RelayCommand(ApplyChange, CanApplyChange);
            OrderStates = new ObservableCollection<string>();
            OrderStates.Add("anulata");
            OrderStates.Add("inregistrata");
            OrderStates.Add("se pregateste");
            OrderStates.Add("a plecat la client");
            OrderStates.Add("livrata");
        }

        private void ApplyChange(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            int orderIndex = EmployeeOrdersVM.orderList[EmployeeOrdersVM.selectedOrderIndex].OrderId;
            if(comboBox.SelectedItem.ToString()=="livrata")
            {
                var preparateQuery = context.FindPreparateForGivenOrderIndex(orderIndex).ToList();
                foreach(var preparat in preparateQuery)
                {
                    context.UpdateRestaurantWeight(preparat.cantitate_meniu, preparat.id_preparat);
                }
                var preparateFromMenusQuery = context.GetMenuPreparatComponentsWeightAndId(orderIndex).ToList();
                foreach(var preparat in preparateFromMenusQuery)
                {
                    context.UpdateRestaurantWeight(preparat.cantitate_meniu, preparat.id_preparat);
                }
            }
            context.UpdateOrderState(comboBox.SelectedItem.ToString(), orderIndex);
            EmployeeOrdersVM.InitiliaseComponents();
            MessageBox.Show("Change applied", "Succes!");         
        }

        private bool CanApplyChange(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            if (comboBox == null)
                return false;
            if (comboBox.SelectedIndex != -1)
                return true;
            return false;
        }
    }
}
