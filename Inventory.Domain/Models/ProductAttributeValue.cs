using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductAttributeValue:BaseModel
    {
        public int ProductAttributeId { get; set; }
        public string Value { get; set; }

        public ProductAttribute ProductAttribute { get; set; }
    }
}
