using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Product:BaseModel
    {
        public string ProductCode { get; set; }

        public int CategoryId { get; set; }
        public int GroupId { get; set; }
        public int BrandId { get; set; }
        public int GenericId { get; set; }

        public string ModelId { get; set; } 
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public decimal ProductPrice { get; set; }
        public bool HasInstances { get; set; }
        public bool HasLots { get; set; }
        public bool HasAttributes { get; set; }

        public int DefaultUom { get; set; }
        public decimal PackSize { get; set; }
        public decimal AverageCost { get; set; }

        public string SingleUnitProductCode { get; set; }
        public string DimensionGroup { get; set; }
        public string LotInformation { get; set; }
        public string WarrantyTerms { get; set; }

        public bool IsActive { get; set; }
        public bool Deleted { get; set; }

        public ItemCategory Category { get; set; }
        public ItemGroup Group { get; set; }
        public Brand Brand { get; set; }
        public GenericProduct GenericProduct { get; set; }

        public ICollection<ProductAttribute> Attributes { get; set; }
        public ICollection<ProductInstance> Instances { get; set; }
        public ICollection<ProductLot> Lots { get; set; }
        public ICollection<Stock> Stock { get; set; }
    }
}
