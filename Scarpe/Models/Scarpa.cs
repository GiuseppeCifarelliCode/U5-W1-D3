using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Scarpe.Models
{
    public class Scarpa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get ; set; }
        public string Description { get; set; }
        public string CoverImg { get; set; }
        public string Img1 { get; set; }
        public string Img2 { get; set;}
        public int Quantity { get; set; }
        public bool Production { get; set; }

        public bool Visible { get; set; }
        public Scarpa () { }

        public Scarpa (string name, double price, string description, string coverImg, string img1, string img2, int quantity, bool production, bool visible)
        {
            Name = name;
            Price = price;
            Description = description;
            CoverImg = coverImg;
            Img1 = img1;
            Img2 = img2;
            Quantity = quantity;
            Production = production;
            Visible = visible;
        }
    }
}