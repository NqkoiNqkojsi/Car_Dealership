﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class Picture
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("Car")]
        public int carId { get; set; }

        public virtual Car car { get; set; }

        public string picture { get; set; }

    }
}