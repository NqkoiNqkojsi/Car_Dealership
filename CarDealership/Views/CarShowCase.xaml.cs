﻿using System;
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
        public string id { get; set; }
        /// <summary>
        /// color for when the car is unwished
        /// </summary>
        SolidColorBrush buttNormalBrush = new SolidColorBrush(Color.FromArgb(100, 91, 103, 122));
        /// <summary>
        /// color for when the car is already wished
        /// </summary>
        SolidColorBrush buttWishedBrush = new SolidColorBrush(Color.FromArgb(100, 210, 214, 144));
        /// <summary>
        /// make the image 
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
        private void MakeContent(string id)
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
        public CarShowCase(string id)
        {
            this.InitializeComponent();
            this.id = id;
            MakeContent(id);
            IsWished();
            GenerateImg();
        }
        public void c_OpenCarPage(object sender, EventArgs e)
        {

        }

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
