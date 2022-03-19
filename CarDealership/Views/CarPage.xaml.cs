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
using Windows.UI.Xaml.Media.Imaging;
using CarDealership.Controllers;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Threading.Tasks;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class CarPage : UserControl
    {
        public string id { get; set; }
        public List<StorageFile> images=new List<StorageFile>();
        private void MakeContent(string id)
        {
            Dictionary<string, string> info = CarController.IDtoCarInfo(id);
            Title.Text = info["brand"] + " " + info["model"];
            textBlockDate.Text = "Made in"+info["date"];
            textBlockPrice.Text = "Price: " + info["price"]+"lv";
            textBlockKmDriven.Text = "Driven:" + info["km"] + "km";
            textBlockHorsePower.Text = "Power:" + info["horsePower"];
            textBlockLitres.Text = "Volume:" + info["engineVolume"]+"l";
            textBlockInfo.Text = info["addInfo"];
            textBlockName.Text = "Name:"+info["seller"];
            textBlockPhone.Text = "Phone:"+info["sellerPhone"];
            //Image.Source=;
        }
        public void GenerateImg()
        {
            ImageBrush uniformToFillBrush = new ImageBrush();
            uniformToFillBrush.ImageSource =
                new BitmapImage(new Uri("Assets/githubLogo.png", UriKind.Relative));
            uniformToFillBrush.Stretch = Stretch.UniformToFill;
            Image.Fill = uniformToFillBrush;
        }
        public CarPage(string id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent(id);
            
        }
    }
}
