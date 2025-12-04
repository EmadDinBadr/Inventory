using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Stock:BaseModel
    {
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }

        public decimal QuantityInHand { get; set; }
        public int? ProductAttributeValueId { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
        public ProductAttributeValue AttributeValue { get; set; }
    }
}
