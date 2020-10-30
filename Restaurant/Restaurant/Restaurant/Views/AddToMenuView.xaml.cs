using System.Windows;
using System.Windows.Controls;


namespace Restaurant.Views
{
    /// <summary>
    /// Interaction logic for AddToMenuView.xaml
    /// </summary>
    public partial class AddToMenuView : Window
    {
        public AddToMenuView()
        {           
            InitializeComponent();
        }
        #region ChangeVisibility
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(categCombo.IsSelected)
            {
                ChangeFoodItemVisibility(Visibility.Hidden);
                ChangeAllergenVisibility(Visibility.Hidden);
                ChangeMenuVisibility(Visibility.Hidden);
                ChangeMenuComponentsVisibility(Visibility.Hidden);
                ChangeFoodItemAllergenVisibility(Visibility.Hidden);

                ChangeCategoryVisbility(Visibility.Visible);
            }
            else if(foodItemCombo.IsSelected)
            {
                ChangeAllergenVisibility(Visibility.Hidden);
                ChangeMenuVisibility(Visibility.Hidden);
                ChangeCategoryVisbility(Visibility.Hidden);
                ChangeMenuComponentsVisibility(Visibility.Hidden);
                ChangeFoodItemAllergenVisibility(Visibility.Hidden);

                ChangeFoodItemVisibility(Visibility.Visible);
            }
            else if(menuItemCombo.IsSelected)
            {
                ChangeAllergenVisibility(Visibility.Hidden);
                ChangeCategoryVisbility(Visibility.Hidden);
                ChangeFoodItemVisibility(Visibility.Hidden);
                ChangeMenuComponentsVisibility(Visibility.Hidden);
                ChangeFoodItemAllergenVisibility(Visibility.Hidden);

                ChangeMenuVisibility(Visibility.Visible);
            }
            else if(allergenCombo.IsSelected)
            {
                ChangeFoodItemVisibility(Visibility.Hidden);
                ChangeMenuVisibility(Visibility.Hidden);
                ChangeMenuComponentsVisibility(Visibility.Hidden);
                ChangeCategoryVisbility(Visibility.Hidden);
                ChangeFoodItemAllergenVisibility(Visibility.Hidden);

                ChangeAllergenVisibility(Visibility.Visible);
            }
            else if(menuCompCombo.IsSelected)
            {
                ChangeFoodItemVisibility(Visibility.Hidden);
                ChangeMenuVisibility(Visibility.Hidden);
                ChangeCategoryVisbility(Visibility.Hidden);
                ChangeAllergenVisibility(Visibility.Hidden);
                ChangeFoodItemAllergenVisibility(Visibility.Hidden);

                ChangeMenuComponentsVisibility(Visibility.Visible);
            }
            else if (foodallerCombo.IsSelected)
            {
                ChangeFoodItemVisibility(Visibility.Hidden);
                ChangeMenuVisibility(Visibility.Hidden);
                ChangeCategoryVisbility(Visibility.Hidden);
                ChangeAllergenVisibility(Visibility.Hidden);
                ChangeMenuComponentsVisibility(Visibility.Hidden);

                ChangeFoodItemAllergenVisibility(Visibility.Visible);
            }
        }
        private void ChangeFoodItemVisibility(Visibility visibility)
        {
            figrp1.Visibility = visibility; figrp2.Visibility = visibility; figrp3.Visibility = visibility;
            figrp4.Visibility = visibility; figrp5.Visibility = visibility; figrp6.Visibility = visibility;
            figrp7.Visibility = visibility; figrp8.Visibility = visibility; figrp9.Visibility = visibility;
            figrp10.Visibility = visibility; figrp11.Visibility = visibility; figrp12.Visibility = visibility;
            figrp13.Visibility = visibility;
        }
        private void ChangeCategoryVisbility(Visibility visibility)
        {
            catgrp1.Visibility = visibility; catgrp2.Visibility = visibility;
        }
        private void ChangeMenuVisibility(Visibility visibility)
        {
            menugrp1.Visibility = visibility; menugrp2.Visibility = visibility; menugrp3.Visibility = visibility;
            menugrp4.Visibility = visibility; menugrp5.Visibility = visibility; menugrp6.Visibility = visibility;
            menugrp7.Visibility = visibility; menugrp8.Visibility = visibility; menugrp9.Visibility = visibility;
        }
        private void ChangeAllergenVisibility(Visibility visibility)
        {
            alergrp1.Visibility = visibility; alergrp2.Visibility = visibility;
        }
        private void ChangeMenuComponentsVisibility(Visibility visibility)
        {
            compgrp1.Visibility = visibility; compgrp2.Visibility = visibility;
            compgrp3.Visibility = visibility; compgrp4.Visibility = visibility;
        }
        private void ChangeFoodItemAllergenVisibility(Visibility visibility)
        {
            foodItemAllerGrp1.Visibility = visibility; foodItemAllerGrp2.Visibility = visibility;
            foodItemAllerGrp3.Visibility = visibility; foodItemAllerGrp4.Visibility = visibility;
        }
        #endregion
    }
}
