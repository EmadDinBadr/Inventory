using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductUom:BaseModel
    {
        public string UomName { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<UomConversion> FromConversions { get; set; }
        public ICollection<UomConversion> ToConversions { get; set; }
    }
}
