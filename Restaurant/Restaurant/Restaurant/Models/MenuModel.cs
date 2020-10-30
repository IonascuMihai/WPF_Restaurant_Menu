using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class MenuModel: INotifyViewModel
    {
        #region DataMembers
        private int categoryId;
        public int menuId { get; set; }
        private string menuName;
        private string menuPrice;
        private string menuPhotoPath;
        private string menuQuantities;
        private string menuAlergens;
        private string availability;
        public string MenuName
        {
            get
            {
                return menuName;
            }
            set
            {
                menuName = value;
                OnPropertyChanged("menuName");
            }
        }
        public string MenuPrice
        {
            get
            {
                return menuPrice;
            }
            set
            {
                menuPrice = value;
                OnPropertyChanged("menuPrice");
            }
        }
        public string MenuPhotoPath
        {
            get
            {
                return menuPhotoPath;
            }
            set
            {
                menuPhotoPath = value;
                OnPropertyChanged("menuPhotoPath");
            }
        }
        public string MenuQuantities
        {
            get
            {
                return menuQuantities;
            }
            set
            {
                menuQuantities = value;
                OnPropertyChanged("menuQuantities");
            }
        }
        public string MenuAlergens
        {
            get
            {
                return menuAlergens;
            }
            set
            {
                menuAlergens = value;
                OnPropertyChanged("menuAlergens");
            }
        }
        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            set
            {
                categoryId = value;
                OnPropertyChanged("categoryId");
            }
        }
        public string Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
                OnPropertyChanged("availability");
            }
        }
        #endregion
    }
}
