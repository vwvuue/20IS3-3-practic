using System;
using System.Collections.Generic;

namespace ClassLibrary.Models
{
    public partial class Specification
    {
        public int SpecId { get; set; }
        public string? SpecName { get; set; }
        public int Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
