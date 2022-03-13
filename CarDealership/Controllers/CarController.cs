using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.IO;
using System.Web;

namespace CarDealership.Controllers
{
    public class CarController
    {
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
        /// Show Cars in the Customer's Wishlist
        /// </summary>
        /// <param name="customer">the user using the app</param>
        /// <returns>list of ids</returns>
        public static List<string> ShowFavoriteCars(Customer customer)=>customer.carsFavourite.Select(x=>x.id).ToList();
        /// <summary>
        /// Returns info of car
        /// </summary>
        /// <param name="id">id of needed car</param>
        /// <returns>dictionary of necessary info</returns>
        public static Dictionary<string, string> IDtoCarInfo(string id)=>Car.approvedCars.First(x => x.id == id).PrintCarInfo();


    }
}
