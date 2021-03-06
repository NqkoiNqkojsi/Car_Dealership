using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
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
        public void ImgDirStringTest()
        {

            int id = 1;
            string tobetested = CarController.ImgDirString(id);
            Assert.AreEqual("<C:\\Users\\PC\\Source\\Repos\\NqkoiNqkojsi\\Car_Dealership\\CarDealership\\Assets\\1", tobetested, "Not equal");
        }

        [TestMethod]
        public void ShowFavoriteCarsTest()
        {
            Car car = new Car("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            List<string> Test = new List<string> {"0"};
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            CustomerController.AddToFavorite(car);
            List<int> toBeTested = CarController.ShowFavoriteCars();
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

        [TestMethod]
        public void isFavoriteTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            Car car = new Car("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            CustomerController.AddToFavorite(car);
            Assert.AreEqual(true, CarController.IsFavoriteCar(car.id), "Isnt in favorites");
        }
        
        [TestMethod]
        public void RemoveFaveCarTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "123", "44444", "ivan@gmail.com");
            Car car = new Car("Test", "Test", 1.00, "4.2005", 1.00, 1.00, 1.00, "");
            CustomerController.AddToFavorite(car);
            int size1 = Customer.customers.Where(c=>c.name == "Ivan").First().favoritedCars.Count();
            CarController.RemoveFavoriteCar(car.id);
            int size2 = Customer.customers.Where(c => c.name == "Ivan").First().favoritedCars.Count();
            Assert.AreEqual(size2 + 1, size1, "Car removed unsuccessfully");
        }
        [TestMethod]
        public void MakeImgDirTest()
        {
            int id = 10000001;
            CarController.MakeImgDir(id);
            bool isExisting = Directory.Exists($"Car_Dealership\\CarDealership\\Assets\\{id}");
            Assert.AreEqual(isExisting, true, "Not accurate count");
        }
        [TestMethod]
        public async void AddPhotoToDirTest()
        {
            int id = 10000001;
            StorageFile storageFile = await StorageFile.GetFileFromPathAsync(CarController.ImgDirString(id-1)+"\\1");
            await CarController.AddPhotoToDir(id, storageFile, "2");
            Assert.AreEqual(2, CarController.PhotoInDirCount(id), "Not accurate count");
        }
        [TestMethod]
        public void PhotoInDirCountTest()
        {

            int id = 10000000;
            int tobetested = CarController.PhotoInDirCount(id);
            Assert.AreEqual(1, tobetested, "Not accurate count");
        }
        [TestMethod]
        public void PhotosAllTest()
        {
            int id = 10000000;
            string photo = CarController.PhotosAll(id).First();
            Assert.AreEqual(photo, $"Car_Dealership\\CarDealership\\Assets\\{id}\\1", "Not accurate count");
        }
    }
}
