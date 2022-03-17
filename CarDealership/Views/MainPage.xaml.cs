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
            MainPanel mainPanel = new MainPanel();
            MainView.Children.Add(mainPanel);
            //CarSearchMenue carSearchMenue = new CarSearchMenue();
            //MainView.Children.Add(carSearchMenue);
        }
        public void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {

        }
    }
}
