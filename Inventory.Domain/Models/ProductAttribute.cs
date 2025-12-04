using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductAttribute:BaseModel
    {
        public int ProductId { get; set; }
        public int AttributeTypeId { get; set; }

        public Product Product { get; set; }
        public ProductAttributeType AttributeType { get; set; }

        public ICollection<ProductAttributeValue> Values { get; set; }
    }
}
