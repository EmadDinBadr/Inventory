using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Warehouse: BaseModel
    {
        public int SiteId { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }

        public Site Site { get; set; }
        public ICollection<Stock> Stock { get; set; }
    }
}
