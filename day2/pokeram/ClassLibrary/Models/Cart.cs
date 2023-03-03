using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Cart
    {
        public int ProdId { get; set; }
        public int ProdCount { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Prod { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
