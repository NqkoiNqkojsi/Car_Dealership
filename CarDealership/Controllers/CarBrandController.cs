using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;
using CarDealership.Data;

namespace CarDealership.Controllers
{
    /// <summary>
    /// Bussiness logic for CarBrand.
    /// </summary>
    public class CarBrandController
    {
        public static List<CarBrand> carBrands = new List<CarBrand>();
        private static CarDealershipContext cardealershipContext = null;

        /// <summary>
        /// Get all registered brands.
        /// </summary>
        /// <returns>Returns a list of all unique brands.</returns>
        public static List<string> GetBrands()
        {
            using (cardealershipContext = new CarDealershipContext())
            {
                List<string> brands = new List<string>();
                using (CarDealershipContext carBrandContext = new CarDealershipContext())
                {
                    foreach (var carBrand in carBrandContext.carBrands)
                    {
                        if (!brands.Contains(carBrand.brand))
                        {
                            brands.Add(carBrand.brand);
                        }
                    }
                }
                return brands;
            }
        }

        /// <summary>
        /// Get all the models that are in a certain brand
        /// </summary>
        /// <returns>All models in a brand.</returns>
        public static List<string> GetModelsByBrand(string brand)
        {
            using (cardealershipContext = new CarDealershipContext())
            {
                List<string> models = new List<string>();
                foreach (CarBrand carBrand in cardealershipContext.carBrands)
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
