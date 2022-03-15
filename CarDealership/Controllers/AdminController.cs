using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Controllers;
using CarDealership.Data;

namespace CarDealership.Controllers
{
    public class AdminController
    {
        /// <summary>
        /// Adds a car to the list of cars visible to customers
        /// </summary>
        public static void ApproveCar(Car car)
        {

            try
            {
                Car.approvedCars.Add(car);
                Car.quarantinedCars.Remove(car);
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Removes car from the list of cars customers can see
        /// </summary>
       
        public static void RemoveCar(Car car)
        {
            Car.approvedCars.Remove(car);
            using (CarContext carContext = new CarContext())
            {
                carContext.cars.Remove(car);
            }
        }

        /// <summary>
        /// Adds a car brand to the list of legitimate car brands
        /// </summary>

        public static void ApproveCarBrand(CarBrand carBrand)
        {
            try
            {
                CarBrand.carBrands.Add(carBrand);
                CarBrand.carBrandsUnverified.Remove(carBrand);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Removes a car brand from the list of legitimate car brands
        /// </summary>

        public static void RemoveCarBrand(CarBrand carBrand)
        {
            CarBrand.carBrands.Remove(carBrand);
            using (CarBrandContext carBrandContext = new CarBrandContext())
            {
                carBrandContext.carBrands.Remove(carBrand);
            }
        }

        public static void RemoveCustomerAccount(Customer customer)
        {
            CustomerController.customers.Remove(customer);
            using (CustomerContext customerContext = new CustomerContext())
            {
                customerContext.customers.Remove(customer);
            }
        }

    }
}

