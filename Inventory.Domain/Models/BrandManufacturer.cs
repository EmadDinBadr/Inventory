using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class BrandManufacturer: BaseModel
    {
        public string ManufacturerName { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
