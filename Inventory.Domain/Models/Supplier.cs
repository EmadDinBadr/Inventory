using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Supplier:BaseModel
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string SupplierType { get; set; }

        public ICollection<PurchaseOrderHeader> PurchaseOrders { get; set; }
    }
}
