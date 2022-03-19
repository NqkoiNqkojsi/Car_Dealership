﻿using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Models;
using System.IO;
using CarDealership.Data;
using Windows.Storage.Pickers;
using Windows.Storage;
using System.Threading.Tasks;

namespace CarDealership.Controllers
{
    public class CarController
    {
        private static CarContext carContext = null;
        /// <summary>
        /// Make a date from a string with only month and year
        /// </summary>
        /// <param name="date">format=M.yyy :"10.2003"</param>
        /// <returns>DateTime with only moth and year</returns>
        public static DateTime MakeDate(string date)
        {
            try
            {
                string[] dateArray = date.Split('.');//split the month and year
                
                DateTime dateTime = new DateTime();//empty DateTime =1.1.0001
                
                dateTime = dateTime.AddMonths(Convert.ToInt32(dateArray[0]) - 1);//add the months without the first
                
                dateTime = dateTime.AddYears(Convert.ToInt32(dateArray[1]) - 1);//add the years without the first
           
                
                return dateTime;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Unable to parse '{0}'", date);
                return DateTime.MinValue;//at error return min value
            }
        }

        /// <summary>
        /// Adds cars to customer's wish list
        /// </summary>
        /// <param name="carId">ids of liked cars</param>
        public static void AddFavoriteCar(string carId)
        {
            if (CustomerController.sessionID != null)
            {
                Customer.customers.First(x => x.id == CustomerController.sessionID).favoritedCars.Add(Car.approvedCars.First(x => x.id == carId));
            }
        }

        /// <summary>
        /// Show Cars in the Customer's Wishlist    
        /// </summary>
        /// <returns>list of ids</returns>
        public static List<string> ShowFavoriteCars()
        {
            if (CustomerController.sessionID != null)
            {
                Customer customer = Customer.customers.First(x => x.id == CustomerController.sessionID);
                return customer.favoritedCars.Select(x => x.id).ToList();
            }
            return null;
        }
        /// <summary>
        /// Show Cars in the Customer's Wishlist
        /// </summary>
        /// <returns>list of ids</returns>
        public static List<string> ShowOwnedCars()
        {
            if (CustomerController.sessionID != null)
            {
                Customer customer = Customer.customers.First(x => x.id == CustomerController.sessionID);
                return customer.carsOwned.Select(x => x.id).ToList();
            }
            return null;
        }
        /// <summary>
        /// Returns info of car
        /// </summary>
        /// <param name="id">id of needed car</param>
        /// <returns>dictionary of necessary info</returns>
        public static Dictionary<string, string> IDtoCarInfo(string id)=>Car.approvedCars.First(x => x.id == id).PrintCarInfo();

        /// <summary>
        /// Creates a directory that contains a car's photos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static void MakeImgDir(string id)
        {
            string toBeAdded = $"Car_Dealership\\CarDealership\\Assets\\{id}";
            string AssetsDir = Directory.GetCurrentDirectory();
            int index = AssetsDir.LastIndexOf("Car_Dealership");
            if (index >= 0)
                AssetsDir = AssetsDir.Substring(0, index);
            AssetsDir += toBeAdded;
            Directory.CreateDirectory(AssetsDir);
        }

        /// <summary>
        /// Returns directory name for ease of the AddPhotoToDir method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ImgDirString(string id)
        {
            string toBeAdded = $"Car_Dealership\\CarDealership\\Assets\\{id}";
            string AssetsDir = Directory.GetCurrentDirectory();
            int index = AssetsDir.LastIndexOf("Car_Dealership");
            if (index >= 0)
                AssetsDir = AssetsDir.Substring(0, index);
            AssetsDir += toBeAdded;
            return AssetsDir;
        }

        /// <summary>
        /// Uploads an image to a customer's offer
        /// </summary>
        /// <returns></returns>
        public static async Task<StorageFile> ImageUpload()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");
            StorageFile carPhoto = await openPicker.PickSingleFileAsync();
            return carPhoto;
        }

        /// <summary>
        /// Adds the image to a car's photo directory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task AddPhotoToDir(string id)
        {
            StorageFile carPhoto = await ImageUpload();
            if (!Directory.Exists(ImgDirString(id))) MakeImgDir(id);                   
            var dir = await StorageFolder.GetFolderFromPathAsync(ImgDirString(id));
            await carPhoto.MoveAsync(dir);
            
        }
        
    }
}
