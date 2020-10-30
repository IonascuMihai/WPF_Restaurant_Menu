using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Restaurant.ViewModels
{
    class LowStockViewModel : INotifyViewModel
    {
        RestaurantConnString context = new RestaurantConnString();
        public ObservableCollection<PreparatModel> preparateList;
        public ObservableCollection<PreparatModel> PreparateList
        {
            get
            {
                return preparateList;
            }
            set
            {
                preparateList = value;
                OnPropertyChanged("preparateList");
            }
        }
        public LowStockViewModel()
        {
            preparateList = new ObservableCollection<PreparatModel>();
            var queryResult = context.GetLowStockFood(int.Parse(ConfigurationManager.AppSettings.Get("c"))).ToList();
            foreach (var preparat in queryResult)
            {
                string composedAlergens = "";
                var alergens = context.GetAllergensForPreparat(preparat.id_preparat);
                foreach (string alergen in alergens)
                {
                    string copyAlergen = Regex.Replace(alergen, @"\s+", "");
                    composedAlergens += "/" + copyAlergen.ToString();
                }
                preparateList.Add(new PreparatModel
                {
                    prepratId = preparat.id_preparat,
                    PreparatName = preparat.nume_preparat,
                    PreparatPrice = preparat.pret.ToString(),
                    CantitateMeniu = preparat.cantitate_meniu.ToString(),
                    CantitateTotala = preparat.cantitate_totala.ToString(),
                    FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                    AlergeniComposedString = composedAlergens
                });
            }
        }
    }
}
