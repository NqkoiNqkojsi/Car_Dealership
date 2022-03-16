using CarDealership.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.ControllerTests
{
    [TestClass]
    public class CustomerControllerTest
    {
        [TestMethod]
        public void HashStringTest()
        {
            string testString = "hello";
            string hashed = CustomerController.HashString(testString);
            string sha512hash = "9B71D224BD62F3785D96D46AD3EA3D73319BFBC2890CAADAE2DFF72519673CA72323C3D99BA5C11D7C7ACC6E14B8C5DA0C4663475C2E5C3ADEF46F73BCDEC043";
            Assert.AreEqual(sha512hash, hashed, "The hashes arent the same");
        }
        [TestMethod]
        public void EmailValidityTest()
        {
            string emailWrong = "pesho @ asdighiuh.www";
            string emailCorrect = "s_kucarov@gmail.com";
            Assert.AreEqual(true, CustomerController.IsValidEmail(emailCorrect), "The email isn't correct");
            Assert.AreEqual(false, CustomerController.IsValidEmail(emailWrong), "The email is correct but shouldn't be");
        }

        [TestMethod]
        public void SendMailTest()
        {
            CustomerController.SendEmail("accountbox@abv.bg", "Test", "Success!");
        }

    }
}
