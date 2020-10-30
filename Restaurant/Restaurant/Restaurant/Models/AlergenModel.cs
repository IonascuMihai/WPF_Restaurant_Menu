using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class AlergenModel: INotifyViewModel
    {
        #region DataMembers
        private int alergenId;
        private string alergenName;
        public int AlergenId
        {
            get
            {
                return alergenId;
            }
            set
            {
                alergenId = value;
                OnPropertyChanged("alergenId");
            }
        }
        public string AlergenName
        {
            get
            {
                return alergenName;
            }
            set
            {
                alergenName = value;
                OnPropertyChanged("alergenName");
            }
        }
        #endregion
    }
}
