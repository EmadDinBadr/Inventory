using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductAttributeType:BaseModel
    {
        public string AttributeName { get; set; }

        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
