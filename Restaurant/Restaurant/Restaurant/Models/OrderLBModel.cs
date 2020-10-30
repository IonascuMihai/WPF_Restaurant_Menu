using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class OrderLBModel: INotifyViewModel
    {
        #region DataMembers
        public int foodItemId { get; set; }
        private string itemName;
        private string itemPrice;
        private int itemQuantity;
        private string itemType;
        public string ItemName
        {
            get
            {
                return itemName;
            }
            set
            {
                itemName = value;
                OnPropertyChanged("itemName");
            }
        }
        public string ItemPrice
        {
            get
            {
                return itemPrice;
            }
            set
            {
                itemPrice = value;
                OnPropertyChanged("itemPrice");
            }
        }
        public int ItemQuantity
        {
            get
            {
                return itemQuantity;
            }
            set
            {
                itemQuantity = value;
                OnPropertyChanged("itemQuantity");
            }
        }
        public string ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                itemType = value;
                OnPropertyChanged("itemType");
            }
        }
        #endregion
    }
}
