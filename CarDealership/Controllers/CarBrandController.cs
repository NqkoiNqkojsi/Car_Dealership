using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Data;

namespace CarDealership.Controllers
{
    public class CarBrandController
    {
        public static List<CarBrand> carBrands = new List<CarBrand>();
        private static CarBrandContext carBrandContext = null;

        /// <summary>
        /// Get all registered brands.
        /// </summary>
        /// <returns>Returns a list of all unique brands.</returns>
        public static List<string> GetBrands()
        {
            using (carBrandContext = new CarBrandContext())
            {
                List<string> brands = new List<string>();
                foreach (var carBrand in carBrandContext.carBrands)
                {
                    if (!brands.Contains(carBrand.brand))
                    {
                        brands.Add(carBrand.brand);
                    }
                }
                return brands;
            }

        }



        /// <summary>
        /// Get all the models that are in a certain brand
        /// </summary>
        /// <returns>all models in a brand</returns>
        public static List<string> GetModelsByBrand(string brand)
        {
            using (carBrandContext = new CarBrandContext())
            {
                List<string> models = new List<string>();
                foreach (CarBrand carBrand in carBrandContext.carBrands)
                {
                    if (carBrand.brand == brand)
                    {
                        models.Add(carBrand.model);
                    }
                }
                return models;
            }
            
        }

        /// <summary>
        /// Get all registered car models.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns>Returns a list of all unique .</returns>
        public static List<string> GetModels(string brand) => GetModelsByBrand(brand);

       
    }
}
