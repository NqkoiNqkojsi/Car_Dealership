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
        public void ApproveCar(Car car)
        {
            if (CustomerController.sessionID != null)
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
        }

        /// <summary>
        /// Removes car from the list of cars customers can see
        /// </summary>
       
        public void RemoveCar(int id)
        {
            if (CustomerController.sessionID != null)
            {
                using (CarContext carContext = new CarContext())
                {
                    var car = carContext.cars.Find(id);
                    if (car != null)
                    {
                        Car.approvedCars.Remove(car);
                        carContext.cars.Remove(car);
                        carContext.SaveChanges();
                    }
                }
            }
        }

        /// <summary>
        /// Adds a car brand to the list of legitimate car brands
        /// </summary>

        public void ApproveCarBrand(CarBrand carBrand)
        {
            if (CustomerController.sessionID != null)
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
        }

        /// <summary>
        /// Removes a car brand from the list of legitimate car brands
        /// </summary>

        public void RemoveCarBrand(int id)
        {
            if (CustomerController.sessionID != null)
            {
                using (CarBrandContext carBrandContext = new CarBrandContext())
                {
                    var carBrand = carBrandContext.carBrands.Find(id);
                    if (carBrand != null)
                    {
                        CarBrand.carBrands.Remove(carBrand);
                        carBrandContext.carBrands.Remove(carBrand);
                        carBrandContext.SaveChanges();
                    }
                }
            }
        }

        public void RemoveCustomerAccount(int id)
        {
            if (CustomerController.sessionID != null)
            {
                using (CustomerContext customerContext = new CustomerContext())
                {
                    var customer = customerContext.customers.Find(id);
                    if (customer != null)
                    {
                        CustomerController.customers.Remove(customer);
                        customerContext.customers.Remove(customer);
                        customerContext.SaveChanges();
                    }
                }
            }
        }

    }
}

