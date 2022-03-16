using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Controllers;

namespace CarDealership.Tests.ControllerTest
{
    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void ApproveCarTest()
        {
            Car car = new Car("Mazda", "Whatever", 24000.00, "4.2015", 120.00, 100000.00, 1000.00, "Goes fast");
            Car car2 = new Car("Ferrari", "Whatever", 24000.00, "4.2015", 120.00, 100000.00, 1000.00, "Goes fast");
            int size1 = Car.quarantinedCars.Count;
            AdminController.ApproveCar(car);
            int size2 = Car.quarantinedCars.Count;
            Assert.AreEqual(size1, size2+1, "Car didn't change lists as expected");
        }
    }
}
