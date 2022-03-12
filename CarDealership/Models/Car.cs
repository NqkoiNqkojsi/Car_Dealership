using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Controllers;

namespace CarDealership.Models
{
    
    public class Car
    {
        public string id { get; set; }

        /// <summary>
        /// Holds the model and brand of the car
        /// </summary>
        public CarBrand carBrand { get; set; }
        public Customer owner { get; set; }

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
        public Car(CarBrand carBrand, double price, string manufDateStr, double horsePower, double kmDriven, string imgDir, double engineVolume,  string info)
        {
            this.id = counter.ToString();
            this.carBrand = carBrand;
            this.price= price;
            this.manufDate = CarController.MakeDate(manufDateStr);
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.imgDir = imgDir;
            this.engineVolume = engineVolume;
            this.info = info;
            quarantinedCars.Add(this);
            counter++;
        }
        public Car(string brand, string model, double price, string manufDateStr, double horsePower, double kmDriven, double engineVolume,  string info)
        {
            this.id = counter.ToString();
            this.price = price;
            this.manufDate = CarController.MakeDate(manufDateStr);//placeholder
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
        public static List<Car> CarsFilterPrice(double priceStart, double priceEnd, List<Car> cars)=>cars.Where(x => x.price >= priceStart && x.price <= priceEnd).ToList();
       
        /// <summary>
        /// Returns Car's Information
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> PrintCarInfo(Car car)
        {
            Dictionary<string, string> info = new Dictionary<string,string>();
            info.Add("ID", car.id);
            info.Add("Brand", car.carBrand.ToString());
            info.Add("Date of Manufacture", car.manufDate.ToString());
            info.Add("Horsepower", car.horsePower.ToString());
            info.Add("Kilometers", car.kmDriven.ToString());
            info.Add("Engine Volume", car.engineVolume.ToString());
            info.Add("Additional Info", car.info);
            return info;
        }
    }
}
