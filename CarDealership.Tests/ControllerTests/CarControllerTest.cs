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
    }
}
