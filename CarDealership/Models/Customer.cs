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
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public bool admin { get; set; }
        private string password;
        public static int counter = 0;//save the last id, probably it will be changed later

        public string Password
        {
            get { return password; }
            set { value=HashString(value); password = value; }
        }
        private string phoneNum;

        public string PhoneNum
        {
            get { return phoneNum; }
            set { value=value.ToString(); phoneNum = value; }
        }
        public string imgDir { get; set; }

        public static string HashString(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        public Customer(string id, string name, DateTime birthDate, bool admin, string password, string phoneNum, string imgDir)
        {
            this.id = counter.ToString();
            this.name = name;
            this.birthDate = birthDate;
            this.admin = admin;
            Password = password;
            PhoneNum = phoneNum;
            this.imgDir = imgDir;
            counter++;
        }
    }
}
