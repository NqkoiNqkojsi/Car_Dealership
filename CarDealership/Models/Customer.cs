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
    /// <summary>
    /// Customer entity.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Customer id.
        /// </summary>
        [Key]
        public int id { get; set; }
       
        /// <summary>
        /// Customer name.
        /// </summary>
        public string name { get; set; }
      
        /// <summary>
        /// Customer birthdate.
        /// </summary>
        public DateTime birthDate { get; set; }
        
        /// <summary>
        /// Customer password
        /// </summary>
        private string password;
        public string Password
        {
            get { return password; }
            set { password = CustomerController.HashString(value); }
        }

        /// <summary>
        /// Customer email.
        /// </summary>
        public string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (CustomerController.IsValidEmail(value))
                    email = value;
                else throw new Exception("Invalid email address!");
            }
        }
        
        /// <summary>
        /// Customer phone number.
        /// </summary>
        public string phoneNum { get; set; }

        /// <summary>
        /// the cars(offers) that are wished by the user
        /// </summary>
        public List<Car> carsFavourite=new List<Car>();

        /// <summary>
        /// List of customers
        /// </summary>
        public static List<Customer> customers = new List<Customer>();

        /// <summary>
        /// the cars(offers) that are owned by the user
        /// </summary>
        public List<Car> publicOffers = new List<Car>();

        public static int counter = 0;//save the last id
        
        /// <summary>
        /// Customer's favotited cars.
        /// </summary>
        public List<Car> favoritedCars = new List<Car>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <param name="password"></param>
        /// <param name="phoneNum"></param>
        /// <param name="email"></param>
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
