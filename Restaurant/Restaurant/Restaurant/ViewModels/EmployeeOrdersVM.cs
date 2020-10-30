using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    class EmployeeOrdersVM: INotifyViewModel
    {
        #region DataMembers
        static RestaurantConnString context = new RestaurantConnString();
        public static int selectedOrderIndex;
        public static ObservableCollection<OrderModel> orderList;
        public RelayCommand SortByDateCommand { get; private set; }
        public RelayCommand SortByETACommand { get; private set; }
        public RelayCommand SortActivesByDateCommand { get; private set; }
        public RelayCommand SortActivesByETACommand { get; private set; }
        public RelayCommand ChangeOrderStatusCommand { get; private set; }
        public ObservableCollection<OrderModel> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("orderList");
            }
        }
        public int SelectedOrderIndex
        {

            get
            {
                return selectedOrderIndex;
            }
            set
            {
                selectedOrderIndex = value;
                OnPropertyChanged("selectedOrderIndex");
            }
        }
        #endregion
        public EmployeeOrdersVM()
        {
            SortByDateCommand = new RelayCommand(SortByDate, RelayCommand.UniversallyTrueCanExecute);
            SortByETACommand = new RelayCommand(SortByETA, RelayCommand.UniversallyTrueCanExecute);
            SortActivesByDateCommand = new RelayCommand(SortActivesByDate, RelayCommand.UniversallyTrueCanExecute);
            SortActivesByETACommand = new RelayCommand(SortActivesByETA, RelayCommand.UniversallyTrueCanExecute);
            ChangeOrderStatusCommand = new RelayCommand(RelayCommand.EmptyAction, CanChangeOrderStatus);

            orderList = new ObservableCollection<OrderModel>();
            selectedOrderIndex = -1;
            InitiliaseComponents();
        }

        public static void InitiliaseComponents()
        {
            orderList.Clear();
            var orderListQuery = context.GetOrdersUnsorted().ToList();
            foreach(var order in orderListQuery)
            {
                string currentName = Regex.Replace(order.nume_user, @"\s+", ""); ;
                string currentSurname = Regex.Replace(order.prenume_user, @"\s+", "");
                orderList.Add(new OrderModel
                {
                    OrderId = order.id_comanda,
                    Name = currentName,
                    Surname = currentSurname,
                    State = order.stare,
                    TotalPrice = (float)order.total_price,
                    Date = order.data,
                    EstimateDelivery = order.timp_livrare,
                    Phone = int.Parse(order.telefon),
                    Address = order.adresa_livrare
                });
            }
        }
        #region RelayCommandFunctions
        private void SortActivesByETA(object obj)
        {
            selectedOrderIndex = -1;
            orderList.Clear();
            var orderListQuery = context.SortActivesByETA().ToList();
            foreach (var order in orderListQuery)
            {
                string currentName = Regex.Replace(order.nume_user, @"\s+", ""); ;
                string currentSurname = Regex.Replace(order.prenume_user, @"\s+", "");
                orderList.Add(new OrderModel
                {
                    OrderId = order.id_comanda,
                    Name = currentName,
                    Surname = currentSurname,
                    State = order.stare,
                    TotalPrice = (float)order.total_price,
                    Date = order.data,
                    EstimateDelivery = order.timp_livrare,
                    Phone = int.Parse(order.telefon),
                    Address = order.adresa_livrare
                });
            }
        }

        private void SortActivesByDate(object obj)
        {
            selectedOrderIndex = -1;
            orderList.Clear();
            var orderListQuery = context.SortActivesByDate().ToList();
            foreach (var order in orderListQuery)
            {
                string currentName = Regex.Replace(order.nume_user, @"\s+", ""); ;
                string currentSurname = Regex.Replace(order.prenume_user, @"\s+", "");
                orderList.Add(new OrderModel
                {
                    OrderId = order.id_comanda,
                    Name = currentName,
                    Surname = currentSurname,
                    State = order.stare,
                    TotalPrice = (float)order.total_price,
                    Date = order.data,
                    EstimateDelivery = order.timp_livrare,
                    Phone = int.Parse(order.telefon),
                    Address = order.adresa_livrare
                });
            }
        }
        private void SortByETA(object obj)
        {
            selectedOrderIndex = -1;
            orderList.Clear();
            var orderListQuery = context.SortByETA().ToList();
            foreach (var order in orderListQuery)
            {
                string currentName = Regex.Replace(order.nume_user, @"\s+", ""); ;
                string currentSurname = Regex.Replace(order.prenume_user, @"\s+", "");
                orderList.Add(new OrderModel
                {
                    OrderId = order.id_comanda,
                    Name = currentName,
                    Surname = currentSurname,
                    State = order.stare,
                    TotalPrice = (float)order.total_price,
                    Date = order.data,
                    EstimateDelivery = order.timp_livrare,
                    Phone = int.Parse(order.telefon),
                    Address = order.adresa_livrare
                });
            }
        }
        private void SortByDate(object obj)
        {
            selectedOrderIndex = -1;
            orderList.Clear();
            var orderListQuery = context.SortByDate().ToList();
            foreach (var order in orderListQuery)
            {
                string currentName = Regex.Replace(order.nume_user, @"\s+", ""); ;
                string currentSurname = Regex.Replace(order.prenume_user, @"\s+", "");
                orderList.Add(new OrderModel
                {
                    OrderId = order.id_comanda,
                    Name = currentName,
                    Surname = currentSurname,
                    State = order.stare,
                    TotalPrice = (float)order.total_price,
                    Date = order.data,
                    EstimateDelivery = order.timp_livrare,
                    Phone = int.Parse(order.telefon),
                    Address = order.adresa_livrare
                });
            }
        }
        private bool CanChangeOrderStatus(object obj)
        {
            if (selectedOrderIndex != -1)
                return true;
            return false;
        }
        #endregion
    }
}
