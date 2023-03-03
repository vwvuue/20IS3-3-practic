using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int ProdId { get; set; }
        public int StatusId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProdCount { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Product Prod { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
