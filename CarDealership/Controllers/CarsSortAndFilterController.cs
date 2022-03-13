using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class CarsSortAndFilterController
    {
        /// <summary>
        /// Find the carse in the given price range
        /// </summary>
        /// <param name="priceEnd">The max price</param>
        /// <param name="priceStart">The min price (optional)</param>
        public static List<Car> CarsFilterPrice(List<Car> cars, double priceEnd, double priceStart = 0) => cars.Where(x => x.price >= priceStart && x.price <= priceEnd).ToList();

        /// <summary>
        /// Sort the cars by price
        /// </summary>
        public static List<Car> CarsSortPrice(List<Car>cars)=>cars.OrderBy(x=>x.price).ToList();

        /// <summary>
        /// Find the cars made after a given year
        /// </summary>
        /// <param name="year">the earliest year wanted</param>
        public static List<Car> CarsFilterYear(List<Car> cars, int year)=>cars.Where(x=>x.manufDate.Year>=year).ToList();

        /// <summary>
        /// Sort the cars by age
        /// </summary>
        public static List<Car> CarsSortYear(List<Car> cars) => cars.OrderBy(x => x.manufDate).ToList();

        /// <summary>
        /// Find the cars with a specific brand
        /// </summary>
        /// <param name="brand">the searched brand</param>
        public static List<Car> CarFilterBrand(List<Car> cars, string brand)=>cars.Where(x=>x.carBrand.brand==brand).ToList();

        /// <summary>
        /// Find the cars with a certain model and brand
        /// </summary>
        /// <param name="carBrand">the brand and model as an object</param>
        /// <returns></returns>
        public static List<Car> CarFilterBrandModel(List<Car> cars, CarBrand carBrand) => cars.Where(x => x.carBrand == carBrand).ToList();

    }
}
