using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class PurchaseOrderHeader:BaseModel
    {
        public int SupplierId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Supplier Supplier { get; set; }
        public ICollection<PurchaseOrderLine> Lines { get; set; }
    }
}
