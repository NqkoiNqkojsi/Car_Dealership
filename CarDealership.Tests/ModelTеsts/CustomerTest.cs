using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarDealership.Models;

namespace CarDealership.Tests.ModelTеsts
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void HashStringTest()
        {
            string testString = "hello";
            string hashed =  Customer.HashString(testString);
            string sha512hash = "9B71D224BD62F3785D96D46AD3EA3D73319BFBC2890CAADAE2DFF72519673CA72323C3D99BA5C11D7C7ACC6E14B8C5DA0C4663475C2E5C3ADEF46F73BCDEC043";
            Assert.AreEqual(sha512hash, hashed, "The hashes arent the same");
        }
    }
}
