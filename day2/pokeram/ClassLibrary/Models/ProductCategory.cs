using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
            Specification1s = new HashSet<Specification1>();
        }

        public int CategoryId { get; set; }
        public string? ProdCategoryName { get; set; }
        public int IdSpecification { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Specification1> Specification1s { get; set; }
    }
}
