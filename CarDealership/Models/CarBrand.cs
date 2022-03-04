﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class CarBrand
    {
        private string id { get; set; }
        public static int lastId = 0;//save the last id, probably it will be changed later
        private string brand { get; set; }
        private string model { get; set; }
        public static List<CarBrand> carBrands = new List<CarBrand>();//list of all the brands with models
        /// <summary>
        /// Register a brand with model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brand">eg. BMW, Audi...</param>
        /// <param name="model">eg. i30, Duster...</param>
        public CarBrand(string id, string brand, string model)
        {
            this.id = id;
            this.brand = brand;
            this.model = model;
            carBrands.Add(this);
            lastId++;
        }
        public static void SortBrands()
        {
            //TO DO
        }
        /// <summary>
        /// Check if a certain model is new
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool IsNew(string brand, string model)
        {
            if(carBrands.Any(a=>a.brand == brand || a.model == model))//check if the model is in already in the list
            {
                return false;
            }
            return true;
        }
    }
}
