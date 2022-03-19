﻿using System;
using CarDealership.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarDealership.Tests.ModelTеsts
{
    [TestClass]
    public class CarBrandTest
    {
        [TestMethod]
        public void isNewTest()//the method checks the method which check if a model is not already saved
        {
            // check for true
            bool result1 = CarBrand.IsNew("Dacia", "Duster");
            // check for false
            CarBrand brand = new CarBrand("None", "None", false);
            bool result2 = CarBrand.IsNew("None", "None");

            // Assert
            Assert.AreEqual(true, result1, "The test returns false instead of true");
            Assert.AreEqual(false, result2, "The test returns true instead of false");
        }
        [TestMethod]
        public void ReturnBrandTest()
        {
            
        }

    }
}
