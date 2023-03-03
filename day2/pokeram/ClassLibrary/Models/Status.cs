using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int StatusId { get; set; }
        public bool OrdersStatus { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
