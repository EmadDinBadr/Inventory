using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductInstance: BaseModel
    {
        public int ProductId { get; set; }
        public string InstanceName { get; set; }
        public string SerialNumber { get; set; }

        public int BrandId { get; set; }
        public int? StockId { get; set; }
        public int? LotId { get; set; }

        public string WarrantyTerms { get; set; }
        public int? ProductAttributeValueId { get; set; }

        public Product Product { get; set; }
        public Brand Brand { get; set; }
        public Stock Stock { get; set; }
        public ProductLot Lot { get; set; }
        public ProductAttributeValue AttributeValue { get; set; }
    }
}
