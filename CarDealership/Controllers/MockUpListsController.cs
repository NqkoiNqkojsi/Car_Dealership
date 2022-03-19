using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;


namespace CarDealership.Controllers
{
    public class MockUpListsController
    {
        public static string GenerateMockUpCar(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++) {
                Car car = new Car(CarBrand.carBrands.ElementAt(random.Next(CarBrand.carBrands.Count - 1)), random.NextDouble() * 10000, "3.2022", random.NextDouble() * 1000, random.NextDouble() * 1000, random.NextDouble() * 1000, "info");
                car.owner = new Customer(random.Next().ToString(), DateTime.Now, random.NextDouble().ToString(), "1111111", "email@abv.bg");
                Car.approvedCars.Add(car);
            }
            return ": "+Car.approvedCars.Count().ToString() +"; "+ Car.quarantinedCars.Count().ToString();
        }
        static List<string> brandsReal = new List<string> { "","BMW", "Mercedes", "Audi", "VW", "Tesla", "Toyota", "Ford"};
        public static string GenerateMockUpCarBrand(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                CarBrand carBrand = new CarBrand(brandsReal.ElementAt(random.Next(7)), random.Next(1000).ToString());
            }
            return CarBrand.carBrands.Count().ToString() +"; ";
        }
        public static string GenerateMockUpCustomer(int count)
        {
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                Customer customer = new Customer(random.Next().ToString(), DateTime.Now, random.NextDouble().ToString(), "1111111", "email@abv.bg");
                CustomerController.customers.Add(customer);
            }
            return CustomerController.customers.Count().ToString();
        }
    }
}
