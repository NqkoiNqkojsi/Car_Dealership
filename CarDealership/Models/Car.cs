using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Car
    {
        public string id { get; set; }
        public CarBrand carBrand { get; set; }
        public double price { get; set; }
        public DateTime manufDate { get; set; }
        public DateTime saleDate { get; set; }
        public double horsePower { get; set; }
        public double kmDriven { get; set; }
        public string imgDir { get; set; }
        public double engineVolume { get; set; }
        public double litres { get; set; }
        public string info { get; set; }
        public Car(string id, CarBrand carBrand, string manufDateStr, DateTime saleDate, double horsePower, double kmDriven, double engineVolume, double litres, string info)
        {
            this.id = id;
            this.carBrand = carBrand;
            this.manufDate = DateTime.Now;//placeholder
            this.saleDate = saleDate;
            this.horsePower = horsePower;
            this.kmDriven = kmDriven;
            this.engineVolume = engineVolume;
            this.litres = litres;
            this.info = info;
        }
    }
}
