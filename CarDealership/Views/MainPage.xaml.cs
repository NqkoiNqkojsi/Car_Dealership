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
        public List<string> carIds=new List<string>();
        SolidColorBrush toggleOnBrush= new SolidColorBrush(Color.FromArgb(50, 41, 77, 127));
        SolidColorBrush toggleOffBrush = new SolidColorBrush(Color.FromArgb(20, 0, 0, 0));
        public MainPage()
        {
            this.InitializeComponent();
            DebugText.Text= MockUpListsController.GenerateMockUpCarBrand(20);
            DebugText.Text =DebugText.Text+ MockUpListsController.GenerateMockUpCar(20);
            CarSearchMenue search = new CarSearchMenue();
            MainView.Children.Add(search);
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
        public void AddToMainView(object sender, PointerRoutedEventArgs e)
        {
            DeactivateButtons();
            CarShowCase carShowCase = (CarShowCase)sender;
            CarPage carPage = new CarPage(carShowCase.id);
            MainView.Children.Add(carPage);
        }


        private void toggleButtonMain_Checked(object sender, RoutedEventArgs e)
        {
            DeactivateButtons();
            CarSearchMenue search = new CarSearchMenue();
            MainView.Children.Add(search);
            toggleButtonMain.Background = toggleOnBrush;
        }

        private void toggleButtonRegister_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void toggleButtonMakeOffer_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void toggleButtonWished_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void toggleButtonOwnOffers_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }
    }
}
