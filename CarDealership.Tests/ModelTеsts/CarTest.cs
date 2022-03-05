using System;
using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarDealership.Tests.ModelTеsts
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void MakeDateTest()
        {
            DateTime date = DateTime.Parse("13/1/2023", "dd/M/yyy");
            string dateStr = date.ToString("M.yyy");
            DateTime result=Car.MakeDate(dateStr);
            Assert.AreEqual(date, result, "The MakeDate returns a wrong DateTime");
        }
    }
}
