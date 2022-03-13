using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Controllers;

namespace CarDealership.Models
{
    public class Customer
    {
       
        public string id { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }

        public static int counter = 0;//save the last id, probably it will be changed later
        
        public bool isLoggedIn = false;

        private string password;

        public string email;

        public string Email
        {
            get { return email; }
            set 
            {   if (CustomerController.IsValidEmail(value))
                    email = value;
                else throw new Exception("Invalid email address!");
            }
        }

        public string Password
        {
            get { return password; }
            set { password = CustomerController.HashString(value); }
        }

        public string phoneNum;

        public string imgDir { get; set; }

        public List<Car> carsOwned = new List<Car>();
        public List<Car> favoritedCars = new List<Car>();


        public Customer(string name, DateTime birthDate, string password, string phoneNum, string email)
        {
            this.id = counter.ToString();
            this.name = name;
            this.birthDate = birthDate;
            Password = password;
            this.phoneNum = phoneNum;
            this.email=email;
            counter++;
        }
    }
}
