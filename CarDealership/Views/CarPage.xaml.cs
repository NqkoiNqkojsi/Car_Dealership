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
        public int id { get; set; }
        public string ownerEmail { get; set; }
        //variables to track the images
        public List<string> paths=new List<string>();
        public int imgCount = 0;
        public int imgAt = 0;
        /// <summary>
        /// Display full info
        /// </summary>
        /// <param name="id">cars id</param>
        private void MakeContent(int id)
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
            ownerEmail = info["sellerEmail"];
        }
        /// <summary>
        /// show the selected image in the window
        /// </summary>
        /// <param name="addres">the image adress on the pc</param>
        public void DisplayImg(string addres)
        {
            ImageBrush uniformToFillBrush = new ImageBrush();
            try
            {
                if (addres != null)
                {
                    uniformToFillBrush.ImageSource =
                        new BitmapImage(new Uri(addres, UriKind.Absolute));
                    uniformToFillBrush.Stretch = Stretch.UniformToFill;
                    Image.Fill = uniformToFillBrush;
                    return;
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            uniformToFillBrush.ImageSource =
                new BitmapImage(new Uri("Assets/default_img.png", UriKind.Relative));
            uniformToFillBrush.Stretch = Stretch.UniformToFill;
            Image.Fill = uniformToFillBrush;
        }
        /// <summary>
        /// Manages the changing of images
        /// </summary>
        /// <param name="mode">1-prevImg, 2-nextImg, 3-current</param>
        public void GenerateImg(int mode)
        {
            if (mode == 1) imgAt--;
            else if(mode == 2) imgAt++;
            if (imgCount > 0)
            {
                DisplayImg(paths[imgAt]);
                if (imgAt == 0)
                {
                    buttonPrev.IsEnabled = false;
                }
                else
                {
                    buttonPrev.IsEnabled = true;
                }
                if(imgAt == imgCount - 1)
                {
                    buttonNext.IsEnabled = false;
                }
                else
                {
                    buttonNext.IsEnabled= true;
                }
            }
            DisplayImg(null);
        }
        /// <summary>
        /// Page to show full car information
        /// </summary>
        /// <param name="id">car's id</param>
        public CarPage(int id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent(id);
            buttonPrev.IsEnabled = false;
            imgCount=CarController.PhotoInDirCount(id);
            if (imgCount > 0)
            {
                paths = CarController.PhotosAll(id);
                GenerateImg(3);
            }

        }
        /// <summary>
        /// Send email message to the seller
        /// </summary>
        private void buttonSendEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CustomerController.SendEmail(ownerEmail, "AutoHub", textBoxEmail.Text);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// generate the next image
        /// </summary>
        private void buttonNext_Click(object sender, RoutedEventArgs e)
        {
            GenerateImg(2);
        }
        /// <summary>
        /// generate the previous image
        /// </summary>
        private void buttonPrev_Click(object sender, RoutedEventArgs e)
        {
            GenerateImg(1);
        }
    }
}
