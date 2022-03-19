using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CarDealership.Models
{
    public class CarBrand
    {
        [Key]
        public string id { get; set; }

        public static int counter = 0;//save the last id, probably it will be changed later

        public string brand { get; set; }

        public string model { get; set; }
        /// <summary>
        /// list of all the brands with models that are real
        /// </summary>
        public static List<CarBrand> carBrands = new List<CarBrand>();
        
        
        /// <summary>
        /// Register a brand with model
        /// </summary>
        /// <param name="brand">eg. BMW, Audi...</param>
        /// <param name="model">eg. i30, Duster...</param>
        
        public CarBrand(string brand, string model)
        {
            this.id = counter.ToString();
            this.brand = brand;
            this.model = model;
            counter++;
            carBrands.Add(this);
        }


        /// <summary>
        /// Returns the first CarBrand available
        /// </summary>
        public static CarBrand ReturnBrand(string brand, string model)=>carBrands.Where(c => c.brand == brand && c.model==model).First();

        /// <summary>
        /// Check if a certain model is new
        /// </summary>
        public static bool IsNew(string brand, string model)
        {
            if(carBrands.Any(a => a.brand == brand || a.model == model))//check if the model is in already in the list
            {
                return false;
            }
            return true;
        }


    }
}
