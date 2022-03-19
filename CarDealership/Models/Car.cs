using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Models
{
    
    public class Car
    {
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Holds the model and brand of the car
        /// </summary>
        [ForeignKey("CarBrand")]
        public int carBrandId { get; set; }
        
        public virtual CarBrand carBrand { get; set; }

        public Customer owner { get; set; }
        
        [Required]
        public double price { get; set; }
        /// <summary>
        /// Date of manufacturing
        /// </summary>
        
        public DateTime manufDate { get; set; }
        /// <summary>
        /// Date the offer is made
        /// </summary>

        [Required]
        public double horsePower { get; set; }
        public double kmDriven { get; set; }

        public double engineVolume { get; set; }
        /// <summary>
        /// Additional info about the car
        /// </summary>
        public string info { get; set; }
        private static int counter=0;

        /// <summary>
        /// List of all cars
        /// </summary>
         
         public static List<Car> approvedCars = new List<Car>();
        public Car(CarBrand carBrand, double price, string manufDateStr, double horsePower, double kmDriven, double engineVolume,  string info)
        {
            this.id = counter;
            this.carBrand = carBrand;
            this.price= price;
            this.manufDate = CarController.MakeDate(manufDateStr);
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.engineVolume = engineVolume;
            this.info = info;
            approvedCars.Add(this);
            counter++;
        }
        
        public Car()
        {

        }
        public Car(string brand, string model, double price, string manufDateStr, double horsePower, double kmDriven, double engineVolume,  string info)
        {
            this.id = counter;
            this.price = price;
            this.manufDate = CarController.MakeDate(manufDateStr);
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.engineVolume = engineVolume;
            this.info = info;
            this.carBrand = CarBrand.ReturnBrand(brand, model);//check for the model if its available, make new if nothing is found
            if (carBrand == null)
            {
                carBrand = new CarBrand(brand, model);
            }
            approvedCars.Add(this);
            counter++;
        }
        public static List<Car> CarsFilterPrice(double priceStart, double priceEnd, List<Car> cars)=>cars.Where(x => x.price >= priceStart && x.price <= priceEnd).ToList();

        /// <summary>
        /// Returns Car's Information
        /// </summary>
        /// <returns>brand, model, date, year, price, seller, imgDir, horsePower, km, engineVolume, addInfo</returns>
        public Dictionary<string, string> PrintCarInfo()
        {
            Dictionary<string, string> carinfo = new Dictionary<string, string>();
            carinfo.Add("brand", carBrand.brand.ToString());
            carinfo.Add("model", carBrand.model.ToString());
            carinfo.Add("date", manufDate.ToString("M.yyy"));
            carinfo.Add("year", manufDate.Year.ToString());
            carinfo.Add("price", price.ToString());
            carinfo.Add("seller", owner.name);
            carinfo.Add("sellerID", owner.id.ToString());
            carinfo.Add("sellerPhone", owner.phoneNum);
            carinfo.Add("horsePower", horsePower.ToString());
            carinfo.Add("km", kmDriven.ToString());
            carinfo.Add("engineVolume", engineVolume.ToString());
            carinfo.Add("addInfo", info);
            return carinfo;
        }
    }
}
