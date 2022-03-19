using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.IO;
using System.Web;
using CarDealership.Data;
using Windows.Storage;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;
using Syncfusion.Pdf.Graphics;

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
           
                //add manufacture date to the car table 
                using (carContext = new CarContext())
                {
                    var newDate = carContext.cars.Select(d=> d.manufDate == dateTime);
                    carContext.SaveChanges();
                }
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
        /// <param name="customerId"> </param>
        /// <param name="carId">id of liked car</param>

        public static void AddFavoriteCar(string customerId, string carId)
        {
            Customer.customers.First(x => x.id == customerId).favoritedCars.Add(Car.approvedCars.First(x => x.id == carId));

            FavoriteCarContext favoriteCarContext = null;

            FavoriteCar favoriteCar = new FavoriteCar(customerId, carId);

            using(favoriteCarContext = new FavoriteCarContext())
            {
                favoriteCarContext.relaionFavourite.Add(favoriteCar);
                favoriteCarContext.SaveChanges();
            }
        }

        /// <summary>
        /// Show Cars in the Customer's Wishlist    
        /// </summary>
        /// <param name="customerId">the user id using the app</param>
        /// <returns>list of ids</returns>
        
        public static List<string> ShowFavoriteCars(string customerId)=> Customer.customers.First(x => x.id == customerId).favoritedCars.Select(x=>x.id).ToList();
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
            int index = AssetsDir.IndexOf("Car_Dealership");
            if (index >= 0)
                AssetsDir = AssetsDir.Substring(0, index);
            AssetsDir += toBeAdded;
            Directory.CreateDirectory(AssetsDir);
        }
        public static void AddPhoto()
        {
            //Load a PDF document

            PdfLoadedDocument doc = new PdfLoadedDocument("input.pdf");

            //Get first page from document

            PdfLoadedPage page = doc.Pages[0] as PdfLoadedPage;

            //Create PDF graphics for the page

            PdfGraphics graphics = page.Graphics;

            //Load the image from the disk

            PdfBitmap image = new PdfBitmap("Autumn Leaves.jpg");

            //Draw the image

            graphics.DrawImage(image, 0, 0);

            //Save the document

            doc.Save("Output.pdf");

            //Close the document

            doc.Close(true);
        }      
    }
}
