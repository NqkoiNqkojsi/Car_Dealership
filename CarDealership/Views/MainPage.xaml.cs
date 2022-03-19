using System;
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
using CarDealership.Controllers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CarDealership
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<int> carIds = new List<int>();
        SolidColorBrush toggleOnBrush= new SolidColorBrush(Color.FromArgb(50, 41, 77, 127));
        SolidColorBrush toggleOffBrush = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
        public MainPage()
        {
            this.InitializeComponent();
            MockUpListsController.GenerateMockUpCarBrand(20);
            MockUpListsController.GenerateMockUpCar(20);
            toggleButtonMain_Checked(MainView, new RoutedEventArgs());
            carIds = CarsSortAndFilterController.CompleteSort("");
            toggleButtonMain.IsChecked = true;
            toggleButtonMain.Background = toggleOnBrush;
        }
        public void DeactivateButtons()
        {
            toggleButtonMain.IsChecked = false;
            toggleButtonMain.Background = toggleOffBrush;
            toggleButtonMakeOffer.IsChecked = false;
            toggleButtonMakeOffer.Background = toggleOffBrush;
            toggleButtonOwnOffers.IsChecked = false;
            toggleButtonOwnOffers.Background = toggleOffBrush;
            toggleButtonRegister.IsChecked = false;
            toggleButtonRegister.Background = toggleOffBrush;
            toggleButtonWished.IsChecked = false;
            toggleButtonWished.Background = toggleOffBrush;
            MainView.Children.Clear();
        }
        /// <summary>
        /// event function to add car page from child class (show case)
        /// </summary>
        public void AddCarPage(object sender, PointerRoutedEventArgs e)
        {
            DeactivateButtons();
            CarShowCase carShowCase = (CarShowCase)sender;
            CarPage carPage = new CarPage(carShowCase.id.ToString());
            MainView.Children.Add(carPage);
        }
        /// <summary>
        /// event function to add list of cars from child class (search)
        /// </summary>
        public void AddListCars(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            CarSearchMenue search = (CarSearchMenue)sender;
            ListOfCars listOfCars = new ListOfCars(search.GetResult());
            listOfCars.OpenCarPage += AddCarPage;
            MainView.Children.Add(listOfCars);
        }
        /// <summary>
        /// Called from other views, it resets the view deleting everything in MainView
        /// </summary>
        public void ResetView(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
        }

        /// <summary>
        /// Open the search by clicking the logo, used by most userControls
        /// </summary>
        public void toggleButtonMain_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            CarSearchMenue search = new CarSearchMenue();
            search.InitializeSearch += AddListCars;
            MainView.Children.Add(search);
            toggleButtonMain.Background = toggleOnBrush;
        }
        /// <summary>
        /// Open the log in/sign up by clicking the register button
        /// </summary>
        private void toggleButtonRegister_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            MainPanel mainPanel = new MainPanel();
            mainPanel.ClosePage += ResetView;
            MainView.Children.Add(mainPanel);
            toggleButtonRegister.Background = toggleOnBrush;
        }
        /// <summary>
        /// Open the MakeOffer by clicking the make offer button
        /// </summary>
        private void toggleButtonMakeOffer_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            MakeOffer makeOffer=new MakeOffer();
            makeOffer.ClosePage += ResetView;
            MainView.Children.Add(makeOffer);
            toggleButtonMain.Background = toggleOnBrush;
        }
        /// <summary>
        /// Open the List of cars filled with wished cars by clicking the wished button
        /// </summary>
        private void toggleButtonWished_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            carIds = CarController.ShowFavoriteCars();
            if (carIds != null)
            {
                ListOfCars listOfCars = new ListOfCars(carIds);
                MainView.Children.Add(listOfCars);
                listOfCars.OpenCarPage += AddCarPage;
                toggleButtonMain.Background = toggleOnBrush;
            }
            else
            {
                //Show Error Message
            }
        }
        /// <summary>
        /// Open the List of cars filled with owned cars by clicking the owned button
        /// </summary>
        private void toggleButtonOwnOffers_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            carIds = CarController.ShowOwnedCars();
            if (carIds != null)
            {
                ListOfCars listOfCars = new ListOfCars(carIds);
                MainView.Children.Add(listOfCars);
                listOfCars.OpenCarPage += AddCarPage;
                toggleButtonMain.Background = toggleOnBrush;
            }
            else
            {
                //Show Error Message
            }
        }
        /// <summary>
        /// Toggle dark Mode
        /// </summary>
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {


        }
    }
}
