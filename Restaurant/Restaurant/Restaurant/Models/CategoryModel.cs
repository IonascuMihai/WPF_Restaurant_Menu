using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class CategoryModel: INotifyViewModel
    {
        #region DataMembers
        private int categoryId;
        private string categoryName;
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
        public string CategoryName
        {
            get
            {
                return categoryName;
            }
            set
            {
                categoryName = value;
                OnPropertyChanged("categoryName");
            }
        }
        #endregion
    }
}
