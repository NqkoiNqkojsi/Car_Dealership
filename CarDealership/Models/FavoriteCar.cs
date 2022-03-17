using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class FavoriteCar
    {
        public string id { get; set; }

        public string customerId { get; set; }

        public string carId { get; set; }

        public FavoriteCar(string customerId, string carId)
        {
            this.customerId = customerId;
            this.carId = carId;
        }
    }
}
