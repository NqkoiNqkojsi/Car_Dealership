using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using System.Security.Cryptography;

namespace CarDealership.Controllers
{
    public class CustomerController
    {
        /// <summary>
        /// Safe Password Hashing w/ SHA512
        /// </summary>
        public static string HashString(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        static List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Registers a customer
        /// </summary>
        public static void CreateCustomer(string name, DateTime birthDate, string password, string phoneNum)
        {
            Customer customer = new Customer(name, birthDate, HashString(password), phoneNum);
            customers.Add(customer);
        }

        /// <summary>
        /// Redo Password
        /// </summary>
        public static void UpdatePassword(string id, string oldPass, string newPass)
        {
            if(customers.Where(x => x.id == id).FirstOrDefault().Password == HashString(oldPass))
            try
            {
               customers.Where(x => x.id == id).FirstOrDefault().Password = HashString(newPass);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Username or password is incorrect");
            }
        }

        public
    }
}
