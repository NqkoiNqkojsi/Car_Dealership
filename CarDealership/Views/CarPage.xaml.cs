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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class CarPage : UserControl
    {
        public string id { get; set; }
        /*private void MakeContent(string id)
        {
            Dictionary<string, string> info = CarController.IDtoCarInfo(id);
            Title.Text = info["brand"] + " " + info["model"];
            Price.Text = "Price:" + info["price"] + "lv";
            Year.Text = "Made in:" + info["year"];
            Seller.Text = "From:" + info["seller"];
            //Image.Source=;
        }*/
        public CarPage(string id)
        {
            this.InitializeComponent();
        }
    }
}
