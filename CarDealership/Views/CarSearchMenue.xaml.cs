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
        public CarSearchMenue()
        {
            this.InitializeComponent();
            ComboBox_Brand.Items.Add("All");
            foreach (string brands in CarBrandController.GetBrands())
                ComboBox_Brand.Items.Add(brands);
            for (int i=2022;i>1929;i--)
                ComboBox_Year.Items.Add(i);
            ComboBox_Sort.Items.Add("Year");
            ComboBox_Sort.Items.Add("Price");
            ComboBox_Sort.Items.Add("Price and Year");
            
        }
        public void ComboBox_SelectionChanged_1(object sender, RoutedEventArgs e)
        {
            ComboBox_Model.Items.Add("All");
            foreach (string models in CarBrandController.GetModels(ComboBox_Brand.SelectedValue.ToString()))
                ComboBox_Model.Items.Add(models);
        }
        public void SearchEngaged(object sender, RoutedEventArgs e)
        {
                
        }
    }
}
