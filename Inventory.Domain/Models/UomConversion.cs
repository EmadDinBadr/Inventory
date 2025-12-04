using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class UomConversion: BaseModel
    {
        public int FromUomId { get; set; }
        public int ToUomId { get; set; }
        public string ConversionRule { get; set; }

        public ProductUom FromUom { get; set; }
        public ProductUom ToUom { get; set; }
    }
}
