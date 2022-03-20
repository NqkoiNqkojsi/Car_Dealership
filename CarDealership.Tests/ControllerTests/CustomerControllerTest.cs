using CarDealership.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

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
        [TestMethod]
        public void CreateCustomerTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899", "ivan@gmail.com");
            Assert.AreEqual(1, Customer.customers.Count, "Customer not created");
        }
        [TestMethod]
        public void UpdatePasswordTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899","ivan@gmail.com");
            CustomerController.UpdatePassword(1, "44444", "55555");
            Assert.AreEqual("55555", Customer.customers.Where(c => c.id == CustomerController.sessionID).First().Password, "Different passwords");
        }
        [TestMethod]
        public void LoginTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899", "ivan@gmail.com");
            CustomerController.Login("ivan@gmail.com", "44444");
            Assert.AreEqual(CustomerController.sessionID, Customer.customers.Where(c => c.name == "Ivan").First().id, "Login failed");
        }

        [TestMethod]
        public void CreateOfferTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899", "ivan@gmail.com");
            CustomerController.CreateOffer("Mazda", "Mazda", 1.00, "3.2015", 1.00, 1.00, 1.00, "Its a car");
            Assert.AreEqual(1, Customer.customers.Where(c => c.id == CustomerController.sessionID).FirstOrDefault().publicOffers.Count, "Offer didnt go through");
        }

        [TestMethod]
        public void RemoveOfferTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899", "ivan@gmail.com");
            CustomerController.CreateOffer("Mazda", "Mazda", 1.00, "3.2015", 1.00, 1.00, 1.00, "Its a car");
            int size1 = Customer.customers.Where(c => c.id == CustomerController.sessionID).FirstOrDefault().publicOffers.Count;
            CustomerController.RemoveOffer(0);
            int size2 = Customer.customers.Where(c => c.id == CustomerController.sessionID).FirstOrDefault().publicOffers.Count;
            Assert.AreEqual(size2 + 1, size1, "Offer not removed");
        }

        [TestMethod]
        public void ForgottenPasswordTest()
        {
            CustomerController.CreateCustomer("Ivan", "23.10.2003", "44444", "0899", "accountbox@abv.bg");
            CustomerController.ForgottenPasswords("accountbox@abv.bg");
        }

        [TestMethod]
        public void MakeBirthDateTest()
        {
            DateTime date = new DateTime();
            date.AddYears(2020);
            date.AddMonths(3);
            string dateStr = date.ToString("dd.M.yyy");
            DateTime result = CustomerController.MakeBirthDate(dateStr);
            Assert.AreEqual(date, result, "The MakeBirthDate returns a wrong DateTime");
        }
        [TestMethod]
        public void isValidPassTest()
        {
            string pass = "12345IT!";
            Assert.AreEqual(CustomerController.IsValidPassword(pass), true, "Pass doesnt work");
        }

    }
}
