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
        private string password;
        public static int counter = 0;//save the last id, probably it will be changed later

        public string Password
        {
            get { return password; }
            set { password = CustomerController.HashString(value); }
        }
        public string phoneNum;

        public string imgDir { get; set; }

        
        public Customer(string name, DateTime birthDate, string password, string phoneNum)
        {
            this.id = counter.ToString();
            this.name = name;
            this.birthDate = birthDate;
            Password = password;
            this.phoneNum = phoneNum;
            //this.imgDir = TO DO;
            counter++;
        }
    }
}
