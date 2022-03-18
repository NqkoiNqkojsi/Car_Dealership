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
            //Returned the proper file path, method was since changed to create a directory in that path instead.
           /* string id = "1";
            string tobetested = CarController.MakeImgDir(id);
            Assert.AreEqual("C:\\Users\\4o4o\\Source\\Repos\\Car_Dealership\\CarDealership\\Assets\\1", tobetested, "Not equal"); */
        }
    }
}
