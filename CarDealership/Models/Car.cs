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
    /// <summary>
    /// Car entity
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Car id
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// CarBrand of the Car
        /// </summary>
        [ForeignKey("CarBrand")]
        public int carBrandId { get; set; }
        public virtual CarBrand carBrand { get; set; }

        /// <summary>
        /// Owner of the car.
        /// </summary>
        public Customer owner { get; set; }
        
        /// <summary>
        /// Price of the car.
        /// </summary>
        [Required]
        public double price { get; set; }


        /// <summary>
        /// Date of manufacturing
        /// </summary>
        public DateTime manufDate { get; set; }

        /// <summary>
        /// Horse power of the car.
        /// </summary>
        [Required]
        public double horsePower { get; set; }
        
        /// <summary>
        /// Driven kilometers on the car.
        /// </summary>
        public double kmDriven { get; set; }

        /// <summary>
        /// Engine volume of the car.
        /// </summary>
        public double engineVolume { get; set; }

        /// <summary>
        /// Additional info about the car
        /// </summary>
        public string info { get; set; }

        /// <summary>
        /// List of all cars
        /// </summary>
         public static List<Car> approvedCars = new List<Car>();

        private static int counter = 0;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="carBrand"></param>
        /// <param name="price"></param>
        /// <param name="manufDateStr"></param>
        /// <param name="horsePower"></param>
        /// <param name="kmDriven"></param>
        /// <param name="engineVolume"></param>
        /// <param name="info"></param>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="price"></param>
        /// <param name="manufDateStr"></param>
        /// <param name="horsePower"></param>
        /// <param name="kmDriven"></param>
        /// <param name="engineVolume"></param>
        /// <param name="info"></param>
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

        /// <summary>
        /// Filters car's in a certain range.
        /// </summary>
        /// <param name="priceStart"></param>
        /// <param name="priceEnd"></param>
        /// <param name="cars"></param>
        /// <returns>A list of cars.</returns>
        public static List<Car> CarsFilterPrice(double priceStart, double priceEnd, List<Car> cars)=>cars.Where(x => x.price >= priceStart && x.price <= priceEnd).ToList();

        /// <summary>
        /// Returns Car's Information
        /// </summary>
        /// <returns>brand, model, date, year, price, seller, horsePower, km, engineVolume, addInfo, sellerPhone, sellerEmail</returns>
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
            carinfo.Add("sellerEmail", owner.email);
            carinfo.Add("horsePower", horsePower.ToString());
            carinfo.Add("km", kmDriven.ToString());
            carinfo.Add("engineVolume", engineVolume.ToString());
            carinfo.Add("addInfo", info);
            return carinfo;
        }
    }
}
