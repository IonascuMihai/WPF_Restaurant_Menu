using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Restaurant.ViewModels
{
    public class CustomerMenuVM : MainVM
    {
        #region DataMembers
        RestaurantConnString context = new RestaurantConnString();
        private string searchText;
        public ObservableCollection<PreparatModel> preparateList;
        public ObservableCollection<MenuModel> menuList;
        public ObservableCollection<OrderLBModel> orderList;
        private int selectedFoodItemIndex;
        private int selectedMenuItemIndex;
        private int selectedOrderListIndex;
        private int customerId {get; set;}
        public RelayCommand SearchCommand { get; private set; }
        public RelayCommand AddFoodItemToOrderListCommand { get; private set; }
        public RelayCommand AddMenuItemToOrderListCommand { get; private set; }
        public RelayCommand RemoveFromOrderCommand { get; private set; }
        public RelayCommand ConfirmOrderCommand { get; private set; }
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
        public ObservableCollection<OrderLBModel> OrderList
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
        public int SelectedFoodItemIndex
        {
            get
            {
                return selectedFoodItemIndex;
            }
            set
            {
                selectedFoodItemIndex = value;
                OnPropertyChanged("selectedFoodItemIndex");
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
        public int SelectedOrderListIndex
        {
            get
            {
                return selectedOrderListIndex;
            }
            set
            {
                selectedOrderListIndex = value;
                OnPropertyChanged("selectedOrderListIndex");
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
        public CustomerMenuVM()
        {
            searchText = "Search here...";
            alergens = context.GetAllergenStrings().ToList();
            alergens = alergens.Select(t => Regex.Replace(t, @"\s+", "")).ToList();
            alergens = alergens.ConvertAll(t => t.ToLower());
            noAlergens = alergens.Select(t => "no " + t).ToList();

            preparateList = new ObservableCollection<PreparatModel>();
            menuList = new ObservableCollection<MenuModel>();
            orderList = new ObservableCollection<OrderLBModel>();

            SearchCommand = new RelayCommand(Search, CanSearch);
            AddFoodItemToOrderListCommand = new RelayCommand(AddFoodItemToOrderList, CanAddFoodItemToOrderList);
            AddMenuItemToOrderListCommand = new RelayCommand(AddMenuItemToOrderList, CanAddMenuItemToOrderList);
            RemoveFromOrderCommand = new RelayCommand(RemoveFromOrder, CanRemoveFromOrder);
            ConfirmOrderCommand = new RelayCommand(ConfirmOrder, CanConfirmOrder);
            selectedFoodItemIndex = -1;
            selectedMenuItemIndex = -1;
            selectedOrderListIndex = -1;

            InitialiseComponents();
        }
        public void InitialiseComponents()
        {
            var foodQuery = context.GetPreparate().ToList();
            foreach (var preparat in foodQuery)
            {
                string preparatStatus = "";
                string composedAlergens = "";
                var alergens = context.GetAllergensForPreparat(preparat.id_preparat);
                foreach (string alergen in alergens)
                {
                    string copyAlergen = Regex.Replace(alergen, @"\s+", "");
                    composedAlergens += "/" + copyAlergen.ToString();
                }
                if (preparat.cantitate_totala > preparat.cantitate_meniu)
                    preparatStatus = "available";
                else
                    preparatStatus = "unavailable";
                preparateList.Add(new PreparatModel
                {
                    prepratId = preparat.id_preparat,
                    PreparatName = preparat.nume_preparat,
                    PreparatPrice = preparat.pret.ToString(),
                    CantitateMeniu = preparat.cantitate_meniu.ToString(),
                    CantitateTotala = preparat.cantitate_totala.ToString(),
                    FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                    AlergeniComposedString = composedAlergens,
                    Availability = preparatStatus
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
                string menuAvailability = "available";
                var preparateIdQuery = context.FindPreparateIdForMenuIndex(meniu.id_meniu);
                foreach (int preparatIdFromQuery in preparateIdQuery)
                {
                    foreach (PreparatModel preparat in preparateList)
                        if (preparat.prepratId == preparatIdFromQuery && preparat.Availability == "unavailable")
                            menuAvailability = "unavailable";
                }
                menuList.Add(new MenuModel
                {
                    menuId = meniu.id_meniu,
                    MenuName = meniu.nume_meniu,
                    MenuPrice = meniu.pret.ToString("0.00"),
                    MenuQuantities = composedQuantities,
                    MenuAlergens = composedAlergens,
                    MenuPhotoPath = AppDomain.CurrentDomain.BaseDirectory + meniu.photo,
                    Availability = menuAvailability                    
                });;
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
                    string preparatStatus;
                    if (preparat.cantitate_totala > preparat.cantitate_meniu)
                        preparatStatus = "available";
                    else
                        preparatStatus = "unavailable";
                    PreparateList.Add(new PreparatModel
                    {
                        prepratId = preparat.id_preparat,
                        PreparatName = preparat.nume_preparat,
                        PreparatPrice = preparat.pret.ToString(),
                        CantitateMeniu = preparat.cantitate_meniu.ToString(),
                        CantitateTotala = preparat.cantitate_totala.ToString(),
                        FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                        AlergeniComposedString = composedAlergens,
                        Availability = preparatStatus
                    }) ;
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
                        menuId = meniu.id_meniu,
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
            if (comboBox.SelectedIndex != -1)
                return true;
            return false;
        }

        private void AddFoodItemToOrderList(object obj)
        {
            bool isThere = false;
            OrderLBModel itemToAdd = new OrderLBModel
            {
                foodItemId = preparateList[selectedFoodItemIndex].prepratId,
                ItemName = preparateList[selectedFoodItemIndex].PreparatName,
                ItemPrice = preparateList[selectedFoodItemIndex].PreparatPrice,
                ItemQuantity = 1,
                ItemType = "preparat"
            };
            foreach (var item in orderList)
                if (item.ItemName == itemToAdd.ItemName)
                { 
                    item.ItemQuantity++;
                    isThere = true;
                }
            if (isThere == false)
                orderList.Add(itemToAdd);
        }
        private bool CanAddFoodItemToOrderList(object obj)
        {
            if (selectedFoodItemIndex != -1 && preparateList[selectedFoodItemIndex].Availability== "available")
                return true;
            return false;
        }
        private void AddMenuItemToOrderList(object obj)
        {
            bool isThere = false;
            OrderLBModel itemToAdd = new OrderLBModel
            {
                foodItemId = menuList[selectedMenuItemIndex].menuId,
                ItemName = menuList[selectedMenuItemIndex].MenuName,
                ItemPrice = menuList[selectedMenuItemIndex].MenuPrice,
                ItemQuantity = 1,
                ItemType = "meniu"
            };
            foreach (var item in orderList)
                if (item.ItemName == itemToAdd.ItemName)
                {
                    item.ItemQuantity++;
                    isThere = true;
                }
            if (isThere == false)
                orderList.Add(itemToAdd);
        }
        private bool CanAddMenuItemToOrderList(object obj)
        {
            if (selectedMenuItemIndex != -1 && menuList[selectedMenuItemIndex].Availability== "available")
                return true;
            return false;
        }
        private void RemoveFromOrder(object obj)
        {
            if (orderList[selectedOrderListIndex].ItemQuantity != 1)
                orderList[selectedOrderListIndex].ItemQuantity--;
            else
                orderList.Remove(orderList[selectedOrderListIndex]);
        }

        private bool CanRemoveFromOrder(object obj)
        {
            if (selectedOrderListIndex != -1)
                return true;
            return false;
        }
        private void ConfirmOrder(object obj)
        {
            float totalPrice=0;
            foreach(var foodItem in orderList)
            {
                totalPrice += foodItem.ItemQuantity * float.Parse(foodItem.ItemPrice);
            }
            string lowerTimeInterval = ConfigurationManager.AppSettings.Get("t1");
            string upperTimeInterval = ConfigurationManager.AppSettings.Get("t2");
            int minimumOrderNumber = int.Parse(ConfigurationManager.AppSettings.Get("z"));
            var orderNumbersResult = context.GetNumberOfOrders(LoginVM.userId, lowerTimeInterval, upperTimeInterval, DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")));
            int clientOrderAmmount = 0;
            float deliveryFee = float.Parse(ConfigurationManager.AppSettings.Get("b"));
            float freeDeliveryThreshold = float.Parse(ConfigurationManager.AppSettings.Get("a"));

            foreach (var orderCount in orderNumbersResult)
                clientOrderAmmount = orderCount.GetValueOrDefault();

            if (totalPrice > float.Parse(ConfigurationManager.AppSettings.Get("y")) || clientOrderAmmount > minimumOrderNumber)
                totalPrice -= totalPrice/ float.Parse(ConfigurationManager.AppSettings.Get("w"));
            if (totalPrice < freeDeliveryThreshold)
                totalPrice += deliveryFee;

            DateTime delivery_time = DateTime.Now.AddHours(1);
            context.RegisterOrder(totalPrice, DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("de-DE")), delivery_time.ToString("HH:mm"), LoginVM.userId);
            var lastOrder = context.GetLastOrderId();
            int lastOrderId = 0;
            foreach (var result in lastOrder)
                lastOrderId = result.Value;
            foreach (var item in orderList)
                for (int i = 0; i < item.ItemQuantity; i++)
                    if (item.ItemType == "meniu")
                        context.AddToComandaMeniuAux(lastOrderId, item.foodItemId);
                    else
                        context.AddToComandaPreparatAux(lastOrderId, item.foodItemId);
            MessageBox.Show("Check your orders tab", "Order placed");
            OrderList.Clear();
        }

        private bool CanConfirmOrder(object obj)
        {
            ListBox listBox = (ListBox)obj;
            if (listBox.Items.Count > 0)
                return true;
            return false;
        }
        #endregion
    }
}
