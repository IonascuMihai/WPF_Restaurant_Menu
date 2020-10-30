using Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class PreparatModel: INotifyViewModel
    {
        #region DataMembers
        public int prepratId { get; set; }
        private string preparatName;
        private string preparatPrice;
        private string cantitateMeniu;
        private string cantitateTotala;
        private string fotografiePath;
        private string alergeniComposedString;
        private string availability;
        public string PreparatName
        {
            get
            {
                return preparatName;
            }
            set
            {
                preparatName = value;
                OnPropertyChanged("preparatName");
            }
        }
        public string FotografiePath
        {
            get
            {
                return fotografiePath;
            }
            set
            {
                fotografiePath = value;
                OnPropertyChanged("fotografiePath");
            }
        }
        public string PreparatPrice
        {
            get
            {
                return preparatPrice;
            }
            set
            {
                preparatPrice = value;
                OnPropertyChanged("preparatPrice");
            }
        }
        public string CantitateMeniu
        {
            get
            {
                return cantitateMeniu;
            }
            set
            {
                cantitateMeniu = value;
                OnPropertyChanged("cantitateMeniu");
            }
        }
        public string CantitateTotala
        {
            get
            {
                return cantitateTotala;
            }
            set
            {
                cantitateTotala = value;
                OnPropertyChanged("cantitateTotala");
            }
        }
        public string AlergeniComposedString
        {
            get
            {
                return alergeniComposedString;
            }
            set
            {
                alergeniComposedString = value;
                OnPropertyChanged("alergeniComposedString");
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
