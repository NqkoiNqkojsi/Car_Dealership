using System;
using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarDealership.Tests.ModelTеsts
{
    [TestClass]
    internal class CarBrandTest
    {
        [TestMethod]
        public void isNewTest()//the method checks the method which check if a model is not already saved
        {
            // check for true
            bool result1 = CarBrand.IsNew("Dacia", "Duster");
            // check for false
            bool result2 = CarBrand.IsNew("None", "None");

            // Assert
            Assert.AreEqual(true, result1, "The test returns false instead of true");
            Assert.AreEqual(false, result2, "The test returns true instead of false");
        }
        [TestMethod]
        public void SortBrandsTest()
        {
            //TO DO
        }

    }
}
