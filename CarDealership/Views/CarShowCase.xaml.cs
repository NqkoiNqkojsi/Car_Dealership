using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
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
using Windows.UI;
using CarDealership.Controllers;
using CarDealership;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace CarDealership.Views
{
    public sealed partial class CarShowCase : UserControl
    {
        public int id { get; set; }
        /// <summary>
        /// color for when the car is unwished
        /// </summary>
        SolidColorBrush buttNormalBrush = new SolidColorBrush(Color.FromArgb(100, 91, 103, 122));
        /// <summary>
        /// color for when the car is already wished
        /// </summary>
        SolidColorBrush buttWishedBrush = new SolidColorBrush(Color.FromArgb(100, 210, 214, 144));
        /// <summary>
        /// get the first image and display it in the rectangle
        /// </summary>
        public void GenerateImg()
        {
            ImageBrush uniformToFillBrush = new ImageBrush();
            try
            {
                if (CarController.PhotoInDirCount(id) > 0)
                {
                    
                    uniformToFillBrush.ImageSource =
                        new BitmapImage(new Uri(CarController.PhotosAll(id).First(), UriKind.Absolute));
                    uniformToFillBrush.Stretch = Stretch.UniformToFill;
                    Image.Fill = uniformToFillBrush;
                    return;
                }
            }catch (Exception ex)
            {
                Popup p = new Popup();
                ErrorMessage errorMessage = new ErrorMessage(ex.Message);
                p.Child = errorMessage;
            }
            uniformToFillBrush.ImageSource =
                new BitmapImage(new Uri("Assets/default_img.png", UriKind.Relative));
            uniformToFillBrush.Stretch = Stretch.UniformToFill;
            Image.Fill = uniformToFillBrush;
        }
        /// <summary>
        /// Displays the preview info in the textblocks
        /// </summary>
        /// <param name="id">car's id</param>
        private void MakeContent(int id)
        {
            Dictionary<string, string> info = CarController.IDtoCarInfo(id);
            Title.Text = info["brand"] + " " + info["model"];
            Price.Text = "Price:" + info["price"] + "lv";
            Year.Text = "Made in:" + info["year"];
            Seller.Text = "From:" + info["seller"];
        }
        /// <summary>
        /// checks if the car is already wished
        /// </summary>
        /// <param name="option">0-check in db, 1-make wished, 2-unwished</param>
        /// <returns></returns>
        private bool IsWished(int option=0)
        {
            if (option ==0)
            {
                if (CarController.IsFavoriteCar(id))
                {
                    AddWish.Background = buttWishedBrush;
                    AddWish.Content = "Wished";
                    return true;
                }
                else
                {
                    AddWish.Background = buttNormalBrush;
                    AddWish.Content = "Add Wished";
                    return false;
                }
            }else if (option == 1)
            {
                AddWish.Background = buttWishedBrush;
                AddWish.Content = "Wished";
                return true;
            }
            else
            {
                AddWish.Background = buttNormalBrush;
                AddWish.Content = "Add Wished";
                return false;
            }
        }
        /// <summary>
        /// The cars preview
        /// </summary>
        /// <param name="id">car's id</param>
        public CarShowCase(int id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent(id);
            IsWished();
            GenerateImg();
        }
        /// <summary>
        /// Func for wish button: wish/unwish a car and change color of button
        /// </summary>
        private void WishCar(object sender, RoutedEventArgs e)
        {
            if (IsWished())
            {
                CarController.RemoveFavoriteCar(id);
                IsWished(1);
            }
            else
            {
                CarController.AddFavoriteCar(id);
                IsWished(2);
            }
            

        }
    }
}
