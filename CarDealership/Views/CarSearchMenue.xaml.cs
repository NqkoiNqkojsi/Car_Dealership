using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CarDealership.Controllers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class CarSearchMenue : UserControl
    {
        public event RoutedEventHandler InitializeSearch;
        public CarSearchMenue()
        {
            this.InitializeComponent();
            buttonSearch.Click += InitializeSearch;
            foreach (string brands in CarBrandController.GetBrands())
                ComboBox_Brand.Items.Add(brands);
            ComboBox_Brand.SelectedIndex = 0;
            for (int i=2022;i>1929;i--)
                ComboBox_Year.Items.Add(i);
            ComboBox_Year.SelectedValue = "0";
            ComboBox_Sort.Items.Add("Year");
            ComboBox_Sort.Items.Add("Price");
            ComboBox_Sort.Items.Add("Price and Year");
            ComboBox_Sort.SelectedValue = "Price";

        }
        public void ComboBox_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            ComboBox_Model.Items.Add("All");
            foreach (string models in CarBrandController.GetModels(ComboBox_Brand.SelectedValue.ToString()))
                ComboBox_Model.Items.Add(models);
            ComboBox_Model.SelectedIndex = 0;
        }
        public List<string> GetResult()
        {
            List<string> result = new List<string>();
            result = CarsSortAndFilterController.CompleteFilter(int.Parse(MinPriceText.Text), int.Parse(MaxPriceText.Text), ComboBox_Brand.Text, int.Parse(ComboBox_Year.Text), ComboBox_Model.Text, ComboBox_Sort.Text);
            return CarsSortAndFilterController.CompleteSort("");
        }
    }
}
