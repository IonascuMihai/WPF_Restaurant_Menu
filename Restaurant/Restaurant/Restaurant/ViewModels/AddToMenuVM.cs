using Microsoft.Win32;
using Restaurant.Models;
using Restaurant.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Restaurant.ViewModels
{
    public class AddToMenuVM : INotifyViewModel
    {
        #region DataMembers
        RestaurantConnString context = new RestaurantConnString();
        public ObservableCollection<CategoryModel> categoryList { get; private set; }
        public ObservableCollection<PreparatModel> preparateList { get; private set; }
        public ObservableCollection<MenuModel> menuList { get; private set; }
        public ObservableCollection<AlergenModel> allergenList { get; private set; }

        private string foodCategory;

        private string foodItemName;
        private float foodItemPrice;
        private float menuQty;
        private float restaurantQty;
        private int selectedIndexCategory;
        private string photoPath;
        private Image chosenPhoto;

        private string menuItemName;
        private string menuPhotoPath;
        private Image chosenPhotoMenu;
        
        private string allergen;

        private int selectedMenuIndex;
        private int selectedPreparatIndex;


        private float menuPrice;
        public RelayCommand AddEntryCommand { get; private set; }
        public RelayCommand LoadPhotoCommand { get; private set; }
        public RelayCommand LoadPhotoMenuCommand { get; private set; }
        public string FoodCategory
        {
            get
            {
                return foodCategory;
            }
            set
            {
                foodCategory = value;
                OnPropertyChanged("foodCategory");
            }
        }
        public string MenuItemName
        {
            get
            {
                return menuItemName;
            }
            set
            {
                menuItemName = value;
                OnPropertyChanged("menuItemName");
            }
        }
        public float MenuPrice
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
        public Image ChosenPhoto
        {
            get
            {
                return chosenPhoto;
            }
            set
            {
                chosenPhoto = value;
                OnPropertyChanged("chosenPhoto");
            }
        }
        public Image ChosenPhotoMenu
        {
            get
            {
                return chosenPhotoMenu;
            }
            set
            {
                chosenPhotoMenu = value;
                OnPropertyChanged("chosenPhotoMenu");
            }
        }

        public string FoodItemName
        {
            get
            {
                return foodItemName;
            }
            set
            {
                foodItemName = value;
                OnPropertyChanged("foodItemName");
            }
        }
        public float FoodItemPrice
        {
            get
            {
                return foodItemPrice;
            }
            set
            {
                foodItemPrice = value;
                OnPropertyChanged("foodItemPrice");
            }
        }
        public int SelectedIndexCategory
        {
            get
            {
                return selectedIndexCategory;
            }
            set
            {
                selectedIndexCategory = value;
                OnPropertyChanged("selectedIndexCategory");
            }
        }
        public int SelectedMenuIndex
        {
            get
            {
                return selectedMenuIndex;
            }
            set
            {
                selectedMenuIndex = value;
                OnPropertyChanged("selectedMenuIndex");
            }
        }
        public int SelectedPreparatIndex
        {
            get
            {
                return selectedPreparatIndex;
            }
            set
            {
                selectedPreparatIndex = value;
                OnPropertyChanged("selectedPreparatIndex");
            }
        }
        public float RestaurantQty
        {
            get
            {
                return restaurantQty;
            }
            set
            {
                restaurantQty = value;
                OnPropertyChanged("restaurantQty");
            }
        }
        public float MenuQty
        {
            get
            {
                return menuQty;
            }
            set
            {
                menuQty = value;
                OnPropertyChanged("menuQty");
            }
        }
        public string Allergen
        {
            get
            {
                return allergen;
            }
            set
            {
                allergen = value;
                OnPropertyChanged("allergen");
            }
        }
        #endregion
        public AddToMenuVM()
        {
            categoryList = new ObservableCollection<CategoryModel>();
            preparateList = new ObservableCollection<PreparatModel>();
            menuList = new ObservableCollection<MenuModel>();
            allergenList = new ObservableCollection<AlergenModel>();
            AddEntryCommand = new RelayCommand(AddEntry, CanAddEntry);
            LoadPhotoCommand = new RelayCommand(LoadPhoto, RelayCommand.UniversallyTrueCanExecute);
            LoadPhotoMenuCommand = new RelayCommand(LoadPhotoMenu, RelayCommand.UniversallyTrueCanExecute);
            SelectedIndexCategory = -1;
            chosenPhoto = new Image();
            chosenPhotoMenu = new Image();
            foodCategory = string.Empty;
            allergen = string.Empty;
            photoPath = string.Empty;
            menuPhotoPath = string.Empty;
            InitialiseComponents();
        }
        private void InitialiseComponents()
        {
            categoryList.Clear();
            preparateList.Clear();
            menuList.Clear();
            allergenList.Clear();
            // categoryList
            var categoryListQuery = context.GetCategoryStrings().ToList();
            foreach (var category in categoryListQuery)
                categoryList.Add(new CategoryModel
                {
                    CategoryId = category.id_categorie,
                    CategoryName = category.nume_categorie
                });
            // allergenList
            var allergenListQuery = context.GetAllergenStrings2().ToList();
            foreach (var allergen in allergenListQuery)
                allergenList.Add(new AlergenModel
                {
                    AlergenId = allergen.id_alergen,
                    AlergenName = allergen.nume_alergen
                });
            // preparateList
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
                    prepratId = preparat.id_preparat,
                    PreparatName = preparat.nume_preparat,
                    PreparatPrice = preparat.pret.ToString(),
                    CantitateMeniu = preparat.cantitate_meniu.ToString(),
                    CantitateTotala = preparat.cantitate_totala.ToString(),
                    FotografiePath = AppDomain.CurrentDomain.BaseDirectory + preparat.fotografie,
                    AlergeniComposedString = composedAlergens
                });
            }
            // menuList
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
                    CategoryId = meniu.categorie_id,
                    menuId = meniu.id_meniu,
                    MenuName = meniu.nume_meniu,
                    MenuPrice = meniu.pret.ToString(),
                    MenuQuantities = composedQuantities,
                    MenuAlergens = composedAlergens,
                    MenuPhotoPath = AppDomain.CurrentDomain.BaseDirectory + meniu.photo
                }); ;
            }
        }  
        #region RelayCommandFunctions
        private void AddEntry(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            if (comboBox.SelectedIndex == 0)
            { 
                context.AddCategory(foodCategory);
            }
            if (comboBox.SelectedIndex == 1)
            { 
                context.AddPreparat(foodItemName, foodItemPrice, menuQty, restaurantQty, photoPath, categoryList[selectedIndexCategory].CategoryId);
                EmployeeMenuVM.preparateList.Add(new PreparatModel
                {
                    PreparatName = foodItemName,
                    PreparatPrice = foodItemPrice.ToString(),
                    CantitateMeniu = menuQty.ToString(),
                    CantitateTotala = restaurantQty.ToString(),
                    FotografiePath = photoPath,
                });
            }
            if (comboBox.SelectedIndex == 2)
            { 
                context.AddMenuItem(menuItemName, 0, categoryList[selectedIndexCategory].CategoryId, menuPhotoPath);
                EmployeeMenuVM.menuList.Add(new MenuModel
                {
                    MenuName = menuItemName,
                    MenuPrice = 0.ToString(),
                    MenuPhotoPath = menuPhotoPath,
                });
            }
            if (comboBox.SelectedIndex == 3)
            { 
                context.AddAllergen(allergen); 
            }
            if (comboBox.SelectedIndex == 4)
            {
                float discountValue = float.Parse(ConfigurationManager.AppSettings.Get("x"));
                discountValue /= 100;
                discountValue *= float.Parse(preparateList[selectedPreparatIndex].PreparatPrice);
                context.AddMenuComponent(menuList[selectedMenuIndex].menuId, preparateList[selectedPreparatIndex].prepratId, discountValue);
            }
            if (comboBox.SelectedIndex == 5)
            { 
                context.AddPreparatAllergen(preparateList[selectedMenuIndex].prepratId, allergenList[selectedPreparatIndex].AlergenId); 
            }
            MessageBox.Show("Entry added", "Succes!");
            InitialiseComponents();
        }
        private bool CanAddEntry(object obj)
        {
            ComboBox comboBox = (ComboBox)obj;
            if (comboBox == null)
                return false;
            if (comboBox.SelectedIndex == 0 )
                if (foodCategory != string.Empty)
                    return true;
                else
                    return false;
            if (comboBox.SelectedIndex == 1)
                if (foodItemName != string.Empty && foodItemPrice!=0 && menuQty!=0 
                    && restaurantQty!=0 && photoPath!=string.Empty && selectedIndexCategory!=-1)
                    return true;
                else
                    return false;
            if (comboBox.SelectedIndex == 2)
                if (menuItemName != string.Empty && menuPhotoPath!= string.Empty && selectedIndexCategory!=-1)
                    return true;
                else
                    return false;
            if (comboBox.SelectedIndex == 3)
                if (allergen != string.Empty)
                    return true;
                else
                    return false;
            if (comboBox.SelectedIndex == 4 || comboBox.SelectedIndex == 5)
                return true;
            return false;
        }
        private void LoadPhoto(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                photoPath = openFileDialog.SafeFileName;
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + openFileDialog.SafeFileName))
                    File.Copy(openFileDialog.FileName, AppDomain.CurrentDomain.BaseDirectory + openFileDialog.SafeFileName);
                chosenPhoto.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }
        private void LoadPhotoMenu(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + openFileDialog.SafeFileName))
                    File.Copy(openFileDialog.FileName, AppDomain.CurrentDomain.BaseDirectory + openFileDialog.SafeFileName);
                menuPhotoPath = openFileDialog.SafeFileName;
                chosenPhotoMenu.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        #endregion
    }
}
