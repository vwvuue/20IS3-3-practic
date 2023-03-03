using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class SpecForProduct
    {
        public int SpecId { get; set; }
        public int ProdId { get; set; }
        public int SpecProductId { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Prod { get; set; } = null!;
        public virtual Specification1 Spec { get; set; } = null!;
    }
}
