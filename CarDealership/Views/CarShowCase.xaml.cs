using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using CarDealership.Controllers;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class CarShowCase : UserControl
    {
        public string id { get; set; }
        public void GenerateImg()
        {
            ImageBrush uniformToFillBrush = new ImageBrush();
            uniformToFillBrush.ImageSource =
                new BitmapImage(new Uri("sampleImages\\square.jpg", UriKind.Relative));
            uniformToFillBrush.Stretch = Stretch.UniformToFill;
            Image.Fill = uniformToFillBrush;
        }
        private void MakeContent(string id)
        {
            Dictionary<string, string> info = CarController.IDtoCarInfo(id);
            Title.Text = info["brand"] + " " + info["model"];
            Price.Text = "Price:" + info["price"] + "lv";
            Year.Text = "Made in:" + info["year"];
            Seller.Text = "From:" + info["seller"];
            //Image.Source=;
        }
        public CarShowCase(string id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent(id);
            OpenCarPage = c_OpenCarPage;
        }
        public event EventHandler OpenCarPage;
        public static void c_OpenCarPage(object sender, EventArgs e)
        {

        }

        private async void WishCar(object sender, RoutedEventArgs e)
        {
            //CarController.AddFavoriteCar();
        }
    }
}
