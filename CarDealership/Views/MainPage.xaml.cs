﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CarDealership
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<string> carIds=new List<string>();
        SolidColorBrush toggleOnBrush= new SolidColorBrush(Color.FromArgb(50, 41, 77, 127));
        SolidColorBrush toggleOffBrush = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
        public MainPage()
        {
            this.InitializeComponent();
            DebugMessage.Text= MockUpListsController.GenerateMockUpCarBrand(20);
            DebugMessage.Text =DebugMessage.Text+ MockUpListsController.GenerateMockUpCar(20);
            Search search = new Search();
            MainView.Children.Add(search);
            carIds = CarsSortAndFilterController.CompleteSort("");
        }
        public void DeactivateButtons()
        {
            toggleButtonCarPage.IsChecked = false;
            toggleButtonCarPage.Background = toggleOffBrush;
            toggleButtonListCars.IsChecked = false;
            toggleButtonListCars.Background = toggleOffBrush;
            toggleButtonSearch.IsChecked = false;
            toggleButtonSearch.Background = toggleOffBrush;
            MainView.Children.Clear();
        }
        public void AddToMainView(object sender, PointerRoutedEventArgs e)
        {
            DeactivateButtons();
            CarShowCase carShowCase = (CarShowCase)sender;
            CarPage carPage = new CarPage(carShowCase.id);
            MainView.Children.Add(carPage);
        }

        public void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            ListOfCars listOfCars = new ListOfCars(CarsSortAndFilterController.CompleteSort(""));
            listOfCars.OpenCarPage += AddToMainView;
            MainView.Children.Add(listOfCars);
            toggleButtonListCars.Background = toggleOnBrush;
        }

        private void toggleButtonCarPage_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            CarPage carPage = new CarPage("0");
            MainView.Children.Add(carPage);
            toggleButtonCarPage.Background = toggleOnBrush;
        }

        private void toggleButtonSearch_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            Search search = new Search();
            MainView.Children.Add(search);
            toggleButtonSearch.Background = toggleOnBrush;
        }
    }
}
