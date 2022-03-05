using System;
using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarDealership.Tests.ModelTеsts
{
    [TestClass]
    internal class CarTest
    {
        [TestMethod]
        public void MakeDateTest()
        {
            DateTime date = DateTime.Now;
            string dateStr = date.ToString("d.M.yyy");
            DateTime result=Car.MakeDate(dateStr);
            Assert.AreEqual(date, result, "The MakeDate returns a wrong DateTime");
        }
    }
}
