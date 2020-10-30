using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.ViewModels
{
    public class NoLoginMenuVM : MainVM
    {
        #region DataMembers
        RestaurantConnString context = new RestaurantConnString();
        private string searchText;
        public ObservableCollection<PreparatModel> preparateList;
        public ObservableCollection<MenuModel> menuList;
        public RelayCommand SearchCommand { get; private set; }
        private List<string> alergens;
        private List<string> noAlergens;

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
        public ObservableCollection<MenuModel> MenuList
        {
            get
            {
                return menuList;
            }
            set
            {
                menuList = value;
                OnPropertyChanged("menuList");
            }
        }
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged("searchText");
            }
        }
        #endregion
        public NoLoginMenuVM()
        {
            searchText = "Search here...";
            alergens = context.GetAllergenStrings().ToList();
            alergens = alergens.Select(t => Regex.Replace(t, @"\s+", "")).ToList();
            alergens = alergens.ConvertAll(t => t.ToLower());
            noAlergens = alergens.Select(t => "no " + t).ToList();

            preparateList = new ObservableCollection<PreparatModel>();
            menuList = new ObservableCollection<MenuModel>();
            SearchCommand = new RelayCommand(Search, CanSearch);

            InitialiseComponents();
        }

        public void InitialiseComponents()
        {
            preparateList.Clear();
            menuList.Clear();
            var foodQuery = context.GetPreparate().ToList();
            foreach (var preparat in foodQuery)
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
                    PreparatName = preparat.nume_preparat,
                    PreparatPrice = preparat.pret.ToString(),
                    CantitateMeniu = preparat.cantitate_meniu.ToString(),
                    CantitateTotala = preparat.cantitate_totala.ToString(),
                    FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                    AlergeniComposedString = composedAlergens
                });
            }
            var menuQuery = context.GetMenus().ToList();
            foreach (var meniu in menuQuery)
            {
                string composedQuantities = "";
                var quantities = context.GetMenuQuantities(meniu.id_meniu);
                foreach (var quantity in quantities)
                {
                    string copyQuantity = quantity.ToString();
                    copyQuantity = Regex.Replace(copyQuantity, @"\s+", ""); ;
                    composedQuantities += "/" + copyQuantity;
                }
                string composedAlergens = "";
                var alergens = context.GetFiecareAlergenDinFiecarePreparatAlUnuiMeniu(meniu.id_meniu);
                foreach (var alergen in alergens)
                {
                    string copyAlergen = Regex.Replace(alergen, @"\s+", "");
                    composedAlergens += "/" + copyAlergen.ToString();
                }
                menuList.Add(new MenuModel
                {
                    MenuName = meniu.nume_meniu,
                    MenuPrice = meniu.pret.ToString("0.00"),
                    MenuQuantities = composedQuantities,
                    MenuAlergens = composedAlergens,
                    MenuPhotoPath = AppDomain.CurrentDomain.BaseDirectory + meniu.photo
                });
            }
        }
        #region RelayCommandFunctions
        private void Search(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            if (searchText == string.Empty)
            {
                InitialiseComponents();
                MessageBox.Show("Search criterion resetted.");
                return;
            }
            if (comboBox.SelectedIndex == 0)
            #region NameSearch
            {
                preparateList.Clear();
                menuList.Clear();
                var foodQuery = context.FindPreparatByName(searchText).ToList();
                foreach (var preparat in foodQuery)
                {
                    string composedAlergens = "";
                    var alergens = context.GetAllergensForPreparat(preparat.id_preparat);
                    foreach (string alergen in alergens)
                    {
                        string copyAlergen = Regex.Replace(alergen, @"\s+", "");
                        composedAlergens += "/" + copyAlergen.ToString();
                    }
                    PreparateList.Add(new PreparatModel
                    {
                        PreparatName = preparat.nume_preparat,
                        PreparatPrice = preparat.pret.ToString(),
                        CantitateMeniu = preparat.cantitate_meniu.ToString(),
                        CantitateTotala = preparat.cantitate_totala.ToString(),
                        FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                        AlergeniComposedString = composedAlergens
                    });
                }
                var menuQuery = context.FindMenuByName(searchText).ToList();
                foreach (var meniu in menuQuery)
                {
                    string composedQuantities = "";
                    var quantities = context.GetMenuQuantities(meniu.id_meniu);
                    foreach (var quantity in quantities)
                    {
                        string copyQuantity = quantity.ToString();
                        copyQuantity = Regex.Replace(copyQuantity, @"\s+", ""); ;
                        composedQuantities += "/" + copyQuantity;
                    }
                    string composedAlergens = "";
                    var alergens = context.GetFiecareAlergenDinFiecarePreparatAlUnuiMeniu(meniu.id_meniu);
                    foreach (var alergen in alergens)
                    {
                        string copyAlergen = Regex.Replace(alergen, @"\s+", "");
                        composedAlergens += "/" + copyAlergen.ToString();
                    }
                    MenuList.Add(new MenuModel
                    {
                        MenuName = meniu.nume_meniu,
                        MenuPrice = meniu.pret.ToString("0.00"),
                        MenuQuantities = composedQuantities,
                        MenuAlergens = composedAlergens,
                        MenuPhotoPath = AppDomain.CurrentDomain.BaseDirectory + meniu.photo
                    });
                }
            }
            #endregion
            if (comboBox.SelectedIndex == 1)
                if (!alergens.Contains(searchText) && !noAlergens.Contains(searchText))
                    MessageBox.Show("No such alergen criterion found.");
                else
                    SearchByAlergen(searchText);
        }
        private void SearchByAlergen(string chosenAlergen)
        {
            chosenAlergen = chosenAlergen.ToLower();
            ObservableCollection<PreparatModel> prepCopy = new ObservableCollection<PreparatModel>();
            ObservableCollection<MenuModel> menuCopy = new ObservableCollection<MenuModel>();
            if (chosenAlergen.Contains("no") || chosenAlergen.Contains("No"))
            {
                chosenAlergen = chosenAlergen.Remove(0, 3);
                foreach (var item in preparateList)
                    if (!item.AlergeniComposedString.ToLower().Contains(chosenAlergen))
                        prepCopy.Add(item);
                foreach (var item in menuList)
                    if (!item.MenuAlergens.ToLower().Contains(chosenAlergen))
                        menuCopy.Add(item);
            }
            else
            {
                foreach (var item in preparateList)
                    if (item.AlergeniComposedString.ToLower().Contains(chosenAlergen))
                        prepCopy.Add(item);
                foreach (var item in menuList)
                    if (item.MenuAlergens.ToLower().Contains(chosenAlergen))
                        menuCopy.Add(item);
            }
            preparateList.Clear();
            PreparateList = prepCopy;
            menuList.Clear();
            MenuList = menuCopy;
        }
        private bool CanSearch(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            if(comboBox.SelectedIndex!=-1)
                return true;
            return false;
        }
        #endregion
    }
}
