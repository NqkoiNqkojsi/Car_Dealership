using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Controllers;

namespace CarDealership.Tests.ControllerTests
{
    [TestClass]
    public class CarControllerTest
    {
        [TestMethod]
        public void MakeDateTest()
        {
            DateTime date = new DateTime();
            date.AddYears(2020);
            date.AddMonths(3);
            string dateStr = date.ToString("M.yyy");
            DateTime result = CarController.MakeDate(dateStr);
            Assert.AreEqual(date, result, "The MakeDate returns a wrong DateTime");
        }
        [TestMethod]
        public void MakeImgDirTest()
        {

            string id = "1";
            string tobetested = CarController.ImgDirString(id);
            Assert.AreEqual("C:\\Users\\4o4o\\Source\\Repos\\Car_Dealership\\CarDealership\\Assets\\1", tobetested, "Not equal");
        }

        [TestMethod]
        public void ShowFavoriteCarsTest()
        {
            Car car = new Car("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            List<string> Test = new List<string> {"0"};
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            CustomerController.AddToFavorite(car);
            List<string> toBeTested = CarController.ShowFavoriteCars();
            Assert.AreEqual(Test, toBeTested, "Not equal"); 
        }

        [TestMethod]
        public void AddFavoriteCarTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            Car car = new Car("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            CustomerController.AddToFavorite(car);
            Assert.AreEqual(1, Customer.customers.Where(c=>c.name=="Ivan").FirstOrDefault().favoritedCars.Count());
        }

        [TestMethod]
        public void ShowOwnedCarsTest()
        {
            List<string> test = new List<string> {"0"};
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            CustomerController.CreateOffer("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            Assert.AreEqual(CarController.ShowOwnedCars(), test, "Doesn't work");
        }

        
    }
}
