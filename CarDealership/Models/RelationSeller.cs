using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class RelationSeller
    {
        [Key]
        public int id { get; set; }
        
        [ForeignKey("Customer")]
        public int customerId { get; set; }

        public virtual Customer customer { get; set; }

        [ForeignKey("Car")]
        public int carId { get; set; }

        public virtual Car car { get; set; }
    }
}
