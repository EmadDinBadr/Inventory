using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class PurchaseOrderLine:BaseModel
    {
        public int PurchaseOrderHeaderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        public PurchaseOrderHeader Header { get; set; }
        public Product Product { get; set; }
    }
}
