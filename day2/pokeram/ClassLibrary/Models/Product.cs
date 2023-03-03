using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            SpecForProducts = new HashSet<SpecForProduct>();
        }

        public int ProdId { get; set; }
        public string ProdName { get; set; } = null!;
        public decimal? ProdPrice { get; set; }
        public int? ProdCount { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<SpecForProduct> SpecForProducts { get; set; }
    }
}
