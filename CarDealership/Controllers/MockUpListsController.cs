using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;


namespace CarDealership.Controllers
{
    /// <summary>
    /// Mock up bussiness.
    /// </summary>
    public class MockUpListsController
    {
        /// <summary>
        /// Creates a mock up car.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>A string of the result.</returns>
        public static string GenerateMockUpCar(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++) {
                Car car = new Car(CarBrand.carBrands.ElementAt(random.Next(CarBrand.carBrands.Count - 1)), random.NextDouble() * 10000, "3.2022", random.NextDouble() * 1000, random.NextDouble() * 1000, random.NextDouble() * 1000, "info");
                car.owner = new Customer(random.Next().ToString(), DateTime.Now, random.NextDouble().ToString(), "1111111", "email@abv.bg");
                Car.approvedCars.Add(car);
            }
            return ": "+Car.approvedCars.Count().ToString() +"; "+ Car.approvedCars.Count().ToString();
        }

        /// <summary>
        /// Creates a list of existing brands. (To create better mock ups)
        /// </summary>
        static List<string> brandsReal = new List<string> { "","BMW", "Mercedes", "Audi", "VW", "Tesla", "Toyota", "Ford"};

        /// <summary>
        /// Creates a mock up car brand.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>A string of the result.</returns>
        public static string GenerateMockUpCarBrand(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                CarBrand carBrand = new CarBrand(brandsReal.ElementAt(random.Next(7)), random.Next(1000).ToString());
            }
            return CarBrand.carBrands.Count().ToString() +"; ";
        }
        
        /// <summary>
        /// Creates a mock up customer.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>A string of the result.</returns>
        public static string GenerateMockUpCustomer(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Customer customer = new Customer(random.Next().ToString(), DateTime.Now, random.NextDouble().ToString(), "1111111", "email@abv.bg");
                Customer.customers.Add(customer);
            }
            return Customer.customers.Count().ToString();
        }
    }
}
