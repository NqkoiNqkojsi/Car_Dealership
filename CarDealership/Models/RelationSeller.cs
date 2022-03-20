using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    /// <summary>
    /// RelationSeller class entity.
    /// </summary>
    public class RelationSeller
    {
        /// <summary>
        /// RelationSeller id
        /// </summary>
        [Key]
        public int id { get; set; }
        
        /// <summary>
        /// Customer id
        /// </summary>
        [ForeignKey("Customer")]
        public int customerId { get; set; }
        
        /// <summary>
        /// An instance of clsss Customer
        /// </summary>
        public virtual Customer customer { get; set; }

        /// <summary>
        /// Car id
        /// </summary>
        [ForeignKey("Car")]
        public int carId { get; set; }

        /// <summary>
        /// An instance of clsss Car
        /// </summary>
        public virtual Car car { get; set; }
    }
}
