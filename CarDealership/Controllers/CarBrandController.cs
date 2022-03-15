using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    public class CarBrandController
    {
        public static List<string> GetBrands()=>CarBrand.GetBrands();
        public static List<string> GetModels(string brand) => CarBrand.GetModelsByBrand(brand);
    }
}
