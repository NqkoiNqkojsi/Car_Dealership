using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarBrand
    {
        public string id { get; set; }
        public static int counter = 0;//save the last id, probably it will be changed later
        public string brand { get; set; }
        public string model { get; set; }
        /// <summary>
        /// list of all the brands with models that are real
        /// </summary>
        public static List<CarBrand> carBrands = new List<CarBrand>();
        /// <summary>
        /// list of the unverified models
        /// </summary>
        public static List<CarBrand> carBrandsUnverified=new List<CarBrand>();
        /// <summary>
        /// Register a brand with model
        /// </summary>
        /// <param name="brand">eg. BMW, Audi...</param>
        /// <param name="model">eg. i30, Duster...</param>
        /// <param name="verified">is it sure if it's real model</param>
        public CarBrand(string brand, string model, bool verified)
        {
            this.id = counter.ToString();
            this.brand = brand;
            this.model = model;
            counter++;
            if (verified)
            {
                carBrands.Add(this);
            }
            else
            {
                carBrandsUnverified.Add(this);
            }
        }
        /// <summary>
        /// Returns the first CarBrand available
        /// </summary>
        public static CarBrand ReturnBrand(string brand, string model)=>carBrands.Where(c => c.brand == brand && c.model==model).First();
        /// <summary>
        /// Get all unique brands
        /// </summary>
        /// <returns>list of all brands available</returns>
        public static List<string> GetBrands()
        {
            List<string> brands = new List<string>();
            foreach (var carBrand in carBrands)
            {
                if (!brands.Contains(carBrand.brand))
                {
                    brands.Add(carBrand.brand);
                }
            }
            return brands;
        }
        /// <summary>
        /// Get all the models that are in a certain brand
        /// </summary>
        /// <returns>all models in a brand</returns>
        public static List<string> GetModelsByBrand(string brand)
        {
            List<string> models = new List<string>();
            foreach (CarBrand carBrand in carBrands)
            {
                if (carBrand.brand == brand)
                {
                    models.Add(carBrand.model);
                }
            }
            return models;
        }
        /// <summary>
        /// Check if a certain model is new
        /// </summary>
        public static bool IsNew(string brand, string model)
        {
            if(carBrandsUnverified.Any(a=>a.brand == brand || a.model == model) || carBrands.Any(a => a.brand == brand || a.model == model))//check if the model is in already in the list
            {
                return false;
            }
            return true;
        }


    }
}
