using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership.Models;
using CarDealership.Controllers;

namespace CarDealership.Tests.ControllerTests
{
    [TestClass]
    public class CarsSortAndFilterControllerTest
    {
        [TestMethod]
        public void CarsFilterPriceTest()
        {
            Car car1 = new Car("Test1", "Test1", 10.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 30.00, "4.2005", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> result = CarsSortAndFilterController.CarsFilterPrice(cars, 29, 11);
            Assert.AreEqual(1, result.Count, "Filter failed");
        }
        [TestMethod]
        public void CarsSortPriceTest()
        {
            Car car1 = new Car("Test1", "Test1", 30.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 10.00, "4.2005", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> result = CarsSortAndFilterController.CarsSortPrice(cars);
            Assert.AreNotSame(cars, result, "Sort didnt work");
        }
        [TestMethod]
        public void CarsFilterYearTest()
        {
            Car car1 = new Car("Test1", "Test1", 10.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 30.00, "4.2006", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> result = CarsSortAndFilterController.CarsFilterYear(cars, 2006);
            Assert.AreEqual(1, result.Count, "Filter failed");
        }
        [TestMethod]
        public void CarsSortYearTest()
        {
            Car car1 = new Car("Test1", "Test1", 10.00, "4.2007", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 30.00, "4.2006", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> result = CarsSortAndFilterController.CarsFilterYear(cars, 2006);
            Assert.AreNotSame(cars, result, "Sort didnt work");
        }
        [TestMethod]
        public void CarsFilterBrandTest()
        {
            Car car1 = new Car("Test1", "Test1", 10.00, "4.2007", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 30.00, "4.2006", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> result = CarsSortAndFilterController.CarFilterBrand(cars, "Test2");
            Assert.AreEqual(1, result.Count, "Filter failed");
        }
        [TestMethod]
        public void CarsFilterBrandModelTest()
        {
            Car car1 = new Car("Test1", "Test1", 10.00, "4.2007", 1.00, 1.00, 1.00, "");
            Car car2 = new Car("Test2", "Test2", 20.00, "4.2005", 1.00, 1.00, 1.00, "");
            Car car3 = new Car("Test3", "Test3", 30.00, "4.2006", 1.00, 1.00, 1.00, "");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            CarBrand brand = new CarBrand("Test2", "Test2");
            List<Car> result = CarsSortAndFilterController.CarFilterBrandModel(cars, brand);
            Assert.AreEqual(1, result.Count, "Filter failed");
        }
    }
}
