using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ProductLot:BaseModel
    {
        public string LotCode { get; set; }
        public DateTime DateManufactured { get; set; }
        public DateTime DateExpiry { get; set; }

        public int? ProductAttributeValueId { get; set; }

        public ProductAttributeValue AttributeValue { get; set; }
    }
}
