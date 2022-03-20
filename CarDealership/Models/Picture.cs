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
    /// Picture entity.
    /// </summary>
    public class Picture
    {
        /// <summary>
        /// Picture id
        /// </summary>
        [Key]
        public int id { get; set; }

        /// <summary>
        /// Car id 
        /// </summary>
        [ForeignKey("Car")]
        public int carId { get; set; }
        
        /// <summary>
        /// Reference to class Car
        /// </summary>
        public virtual Car car { get; set; }

        /// <summary>
        /// picture direcory holder
        /// </summary>
        public string picture { get; set; }

    }
}
