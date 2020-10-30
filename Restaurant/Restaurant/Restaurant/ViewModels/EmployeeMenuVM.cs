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
    public class EmployeeMenuVM: MainVM
    {
        #region DataMembers
        static RestaurantConnString context = new RestaurantConnString();
        private int selectedPreparatItemIndex = -1;
        private int selectedMenuItemIndex = -1;
        static public ObservableCollection<PreparatModel> preparateList;
        static public ObservableCollection<MenuModel> menuList;
        public RelayCommand RemoveFromMenuCommand { get; private set; }
        public RelayCommand RemoveMenuItemCommand { get; private set; }
        public RelayCommand RefreshMenuCommand { get; private set; }
        public RelayCommand EditFoodItemCommand { get; private set; }
        public RelayCommand EditMenuItemCommand { get; private set; }
        public RelayCommand SeeLowStockCommand { get; private set; }


        public int SelectedPreparatItemIndex
        {
            get
            {
                return selectedPreparatItemIndex;
            }
            set
            {
                selectedPreparatItemIndex = value;
                OnPropertyChanged("selectedPreparatItemIndex");
            }
        }
        public int SelectedMenuItemIndex
        {
            get
            {
                return selectedMenuItemIndex;
            }
            set
            {
                selectedMenuItemIndex = value;
                OnPropertyChanged("selectedMenuItemIndex");
            }
        }
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
        #endregion
        public EmployeeMenuVM()
        {
            SeeLowStockCommand = new RelayCommand(RelayCommand.EmptyAction, RelayCommand.UniversallyTrueCanExecute);
            EditFoodItemCommand = new RelayCommand(RelayCommand.EmptyAction, CanEditFoodItem);
            EditMenuItemCommand = new RelayCommand(RelayCommand.EmptyAction, CanEditMenuItem);
            RefreshMenuCommand = new RelayCommand(RefreshMenu, RelayCommand.UniversallyTrueCanExecute);
            RemoveFromMenuCommand = new RelayCommand(RemoveFromMenu, CanRemoveFromMenu);
            RemoveMenuItemCommand = new RelayCommand(RemoveMenuItem, CanRemoveMenuItem);
            preparateList = new ObservableCollection<PreparatModel>();
            menuList = new ObservableCollection<MenuModel>();
            InitialiseComponents();
        }

        public static void InitialiseComponents()
        {
            menuList.Clear();
            preparateList.Clear();
            var queryResult = context.GetPreparate().ToList();
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
            var query = context.GetMenus().ToList();
            foreach (var meniu in query)
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
                    menuId = meniu.id_meniu,
                    MenuName = meniu.nume_meniu,
                    MenuPrice = meniu.pret.ToString("0.00"),
                    MenuQuantities = composedQuantities,
                    MenuAlergens = composedAlergens,
                    MenuPhotoPath = AppDomain.CurrentDomain.BaseDirectory + meniu.photo
                });               
            }
        }
        #region RelayCommandFunctions
        private void RemoveMenuItem(object obj)
        {
            context.DeleteMeniu(menuList[SelectedMenuItemIndex].menuId);          
            menuList.Remove(menuList[SelectedMenuItemIndex]);
            MessageBox.Show("Delete succes");
        }
        private bool CanRemoveMenuItem(object obj)
        {
            if (SelectedMenuItemIndex != -1)
                return true;
            return false;
        }

        private void RemoveFromMenu(object obj)
        {
            context.DeletePreparat(preparateList[SelectedPreparatItemIndex].prepratId);
            preparateList.Remove(preparateList[SelectedPreparatItemIndex]);
            MessageBox.Show("Delete succes");
        }
        private bool CanRemoveFromMenu(object obj)
        {
            if (SelectedPreparatItemIndex != -1)
                return true;
            return false;
        }
        private void RefreshMenu(object obj)
        {
            InitialiseComponents();
        }
        private bool CanEditMenuItem(object obj)
        {
            if (selectedMenuItemIndex != -1)
                return true;
            return false;
        }

        private bool CanEditFoodItem(object obj)
        {
            if (selectedPreparatItemIndex != -1)
                return true;
            return false;
        }
        #endregion
    }
}
