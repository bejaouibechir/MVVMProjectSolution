﻿namespace MVVMProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        //Indicates if the product is avalable
        public bool HasOffer { get; set; }
        public decimal OfferPrice { get; set; }

    }
}
