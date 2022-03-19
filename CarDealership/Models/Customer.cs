using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Controllers;
using CarDealership.Data;

namespace CarDealership.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }
      
        public string name { get; set; }
      
        public DateTime birthDate { get; set; }

        public static List<Customer> customers = new List<Customer>();
        public static int counter = 0;//save the last id, probably it will be changed later
        /// <summary>
        /// the cars(offers) that are owned by the user
        /// </summary>
        public List<Car> publicOffers = new List<Car>();

        private string password;

        public string email;
      
        /// <summary>
        /// the cars(offers) that are wished by the user
        /// </summary>
        public List<Car> carsFavourite=new List<Car>();
        public static List<Customer> customers = new List<Customer>();
        
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

        public string phoneNum { get; set; }

        public List<Car> favoritedCars = new List<Car>();

        public Customer(string name, DateTime birthDate, string password, string phoneNum, string email)
        {
            this.id = counter;
            this.name = name;
            this.birthDate = birthDate;
            Password = password;
            this.phoneNum = phoneNum;
            this.email=email;
            counter++;
        }
    }
}
