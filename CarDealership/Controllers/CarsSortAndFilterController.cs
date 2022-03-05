using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealership.Models;

namespace CarDealership.Controllers
{
    internal class CarsSortAndFilterController
    {
        public static List<Car> CarsFilterPrice(double priceStart, double priceEnd, List<Car> cars) => cars.Where(x => x.price >= priceStart && x.price <= priceEnd).ToList();
        //public static List<Car> CarsSortPrice(List<Car>cars)=>cars.Sort(x => x.price);
    }
}
