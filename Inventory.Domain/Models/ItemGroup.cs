using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class ItemGroup:BaseModel
    {
        public string GroupCode { get; set; }
        public string GroupName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
