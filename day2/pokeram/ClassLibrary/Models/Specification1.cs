using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Specification1
    {
        public Specification1()
        {
            SpecForProducts = new HashSet<SpecForProduct>();
        }

        public int SpecId { get; set; }
        public string? SpecName { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ICollection<SpecForProduct> SpecForProducts { get; set; }
    }
}
