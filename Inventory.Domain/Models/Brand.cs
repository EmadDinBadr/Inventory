using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Brand:BaseModel
    {
        public int ManufacturerId { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }

        public BrandManufacturer Manufacturer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
