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
using System.Drawing;
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CarDealership
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Table.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                await Task.Delay(60);
                Table.Background = new SolidColorBrush(Windows.UI.Colors.Magenta);
                await Task.Delay(60);
            }
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Table.Background = new SolidColorBrush(Windows.UI.Colors.WhiteSmoke);
        }
    }
}
