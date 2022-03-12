﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Car
    {
        public string id { get; set; }

        /// <summary>
        /// Holds the model and brand of the car
        /// </summary>
        public CarBrand carBrand { get; set; }

        public double price { get; set; }
        /// <summary>
        /// Date of manufacturing
        /// </summary>

        public DateTime manufDate { get; set; }
        /// <summary>
        /// Date the offer is made
        /// </summary>
        public double horsePower { get; set; }
        public double kmDriven { get; set; }
        /// <summary>
        /// Directory of the image
        /// </summary>
        public string imgDir { get; set; }
        public double engineVolume { get; set; }
        /// <summary>
        /// Additional info about the car
        /// </summary>
        public string info { get; set; }
        private static ulong counter=0;
        /// <summary>
        /// List of all cars
        /// </summary>
         public static List<Car> quarantinedCars = new List<Car>();
         public static List<Car> approvedCars = new List<Car>();
        public Car(CarBrand carBrand, string manufDateStr, double horsePower, double kmDriven, string imgDir, double engineVolume, string info)
        {
            this.id = counter.ToString();
            this.carBrand = carBrand;
            this.manufDate = MakeDate(manufDateStr);
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.imgDir = imgDir;
            this.engineVolume = engineVolume;
            this.info = info;
            quarantinedCars.Add(this);
            counter++;
        }
        public Car(string brand, string model, string manufDateStr, double horsePower, double kmDriven, double engineVolume, string info)
        {
            this.id = counter.ToString();
            this.manufDate = MakeDate(manufDateStr);//placeholder
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.imgDir = imgDir;
            this.engineVolume = engineVolume;
            this.info = info;
            this.carBrand = CarBrand.ReturnBrand(brand, model);//check for the model if its available, make new if nothing is found
            if (carBrand == null)
            {
                carBrand = new CarBrand(brand, model,false);
            }
            quarantinedCars.Add(this);
            counter++;
        }

        /// <summary>
        /// Make a date from a string with only month and year
        /// </summary>
        /// <param name="date">format=M.yyy :"10.2003"</param>
        /// <returns>DateTime with only moth and year</returns>
        public static DateTime MakeDate(string date)
        {
            try
            {
                string[] dateArray = date.Split('.');//split the month and year
                DateTime dateTime = new DateTime();//empty DateTime =1.1.0001
                dateTime = dateTime.AddMonths(Convert.ToInt32(dateArray[0]) - 1);//add the months without the first
                dateTime = dateTime.AddYears(Convert.ToInt32(dateArray[1]) - 1);//add the years without the first
                return dateTime;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Unable to parse '{0}'", date);
                return DateTime.MinValue;//at error return min value
            }
        }

        //Prints out the car's information
        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.Append($"ID: {this.id}" + Environment.NewLine);
            carInfo.Append($"Brand: {this.carBrand}" + Environment.NewLine);
            carInfo.Append($"Manufacturing Date: {this.manufDate}" + Environment.NewLine);
            carInfo.Append($"Horsepower: {this.horsePower}" + Environment.NewLine);
            carInfo.Append($"Kilometers: {this.kmDriven}" + Environment.NewLine);
            carInfo.Append($"Engine Volume: {this.engineVolume}" + Environment.NewLine);
            carInfo.Append($"Additional Info: {this.info}");
            return carInfo.ToString();
        }
    }
}
