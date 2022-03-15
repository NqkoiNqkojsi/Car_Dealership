using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.IO;
using System.Web;
using CarDealership.Data;

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
                //adding manufacture date to the table 
                using (carContext = new CarContext())
                {
                    carContext.cars.Select(u => u.manufDate).Append(dateTime);
                    carContext.SaveChanges();
                }
                return dateTime;
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to parse '{0}'", date);
                return DateTime.MinValue;//at error return min value
                
            }
        }


        /// <summary>
        /// Show Cars in the Customer's Wishlist
        /// </summary>
        /// <param name="customer"></param>
        public static List<string> ShowFavoriteCars(Customer customer)
        {
            List<string> IDs = new List<string>();
            foreach (Car car in customer.favoritedCars)
            {
                IDs.Append(car.id);
            }
            return IDs;          
        }

        public static Dictionary<string, string> IDtoCarInfo(string id)
        {
            return Car.approvedCars.First(x => x.id == id).PrintCarInfo();

        }

    }
}
