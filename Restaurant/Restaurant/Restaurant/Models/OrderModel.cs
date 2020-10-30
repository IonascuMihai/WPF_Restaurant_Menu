using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class OrderModel: INotifyViewModel
    {
        #region DataMembers
        private int orderId;
        private ObservableCollection<ProductNamesModel> productNames;
        private float totalPrice;
        private string state;
        private string date;
        private string estimateDelivery;
        private string name;
        private string surname;
        private int phone;
        private string address;
        public int OrderId
        {
            get
            {
                return orderId;
            }
            set
            {
                orderId = value;
                OnPropertyChanged("orderId");
            }
        }
        public int Phone
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
        public ObservableCollection<ProductNamesModel> ProductNames
        {
            get
            {
                return productNames;
            }
            set
            {
                productNames = value;
                OnPropertyChanged("productNames");
            }
        }
        public float TotalPrice
        {
            get
            {
                return totalPrice;
            }
            set
            {
                totalPrice = value;
                OnPropertyChanged("totalPrice");
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("state");
            }
        }
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("date");
            }
        }
        public string EstimateDelivery
        {
            get
            {
                return estimateDelivery;
            }
            set
            {
                estimateDelivery = value;
                OnPropertyChanged("estimateDelivery");
            }
        }
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
        #endregion
    }
}
