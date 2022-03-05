using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CarDealership.Models
{
    public class Customer
    {
        /// <summary>
        /// Safely Encrypts the Password
        /// </summary>
        
        public string id { get; set; }
        public static int counter = 0;//save the last id, probably it will be changed later
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public bool admin { get; set; }
        public string phoneNum { get; set; }
        public string imgDir { get; set; }
        private string password;
        /// <summary>
        /// password with hash
        /// </summary>
        public string Password
        {
            get { return password; }
            set { value=HashString(value); password = value; }
        }
        /// <summary>
        /// A customer class holding everything about them
        /// </summary>
        public Customer(string name, DateTime birthDate, bool admin, string password, string phoneNum, string imgDir)
        {
            this.id = counter.ToString();
            this.name = name;
            this.birthDate = birthDate;
            this.admin = admin;
            Password = password;
            this.phoneNum = phoneNum;
            this.imgDir = imgDir;
            counter++;
        }
        /// <summary>
        /// Get a hash of a string
        /// </summary>
        /// <param name="input">the password to be hashed</param>
        public static string HashString(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                var hashedInputStringBuilder = new StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
