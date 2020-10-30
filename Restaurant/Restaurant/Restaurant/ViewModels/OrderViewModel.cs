using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Restaurant.ViewModels
{
    public class OrderViewModel : MainVM
    {
        RestaurantConnString context = new RestaurantConnString();
        private int selectedOrderIndex;
        public ObservableCollection<OrderModel> orderList;
        public RelayCommand CancelOrderCommand { get; private set; }
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
        public OrderViewModel()
        {
            selectedOrderIndex = -1;
            CancelOrderCommand = new RelayCommand(CancelOrder, CanCancelOrder);
            orderList = new ObservableCollection<OrderModel>();
            InitialiseOrderList();
        }

        private void InitialiseOrderList()
        {
            var customerOrderIds = context.GetOrderIdsForCustomer(LoginVM.userId).ToList();
            foreach (int currentOrderId in customerOrderIds)
            {
                ObservableCollection<ProductNamesModel> foodNamesList = new ObservableCollection<ProductNamesModel>();
                var orderFoodNames = context.GetFoodNamesForUserWithOrderId(LoginVM.userId, currentOrderId).ToList();
                foreach (string currentFoodName in orderFoodNames)
                {
                    foodNamesList.Add(new ProductNamesModel
                    {
                        ProductName = currentFoodName
                    });
                }
                var orderFoodMenuNames = context.GetFoodNamesForUserWithOrderId2(LoginVM.userId, currentOrderId).ToList();
                foreach (string currentFoodMenuName in orderFoodMenuNames)
                {
                    foodNamesList.Add(new ProductNamesModel
                    {
                        ProductName = currentFoodMenuName
                    });
                }
                var orderDetailsQuery = context.GetOrderDetailsForGivenOrderId(currentOrderId).ToList();
                foreach(var orderDetail in orderDetailsQuery)
                {
                    string stareNoSpaces = Regex.Replace(orderDetail.stare, @"\s+", "");
                    orderList.Add(new OrderModel
                    {
                        OrderId = currentOrderId,
                        ProductNames = foodNamesList,
                        TotalPrice = (float)orderDetail.total_price,                       
                        State = stareNoSpaces,
                        Date = orderDetail.data,
                        EstimateDelivery = orderDetail.timp_livrare
                    }) ;
                }
            }
        }
        private void CancelOrder(object obj)
        {
            context.CancelOrder(selectedOrderIndex);
            OrderList[selectedOrderIndex].State = "anulata";
            MessageBox.Show("Order canceled.");
        }

        private bool CanCancelOrder(object obj)
        {
            if (selectedOrderIndex != -1 && orderList[selectedOrderIndex].State != "anulata"
                && orderList[selectedOrderIndex].State != "livrata")
                return true;
            return false;
        }
    }
}
