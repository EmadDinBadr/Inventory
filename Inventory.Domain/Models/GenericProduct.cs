using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class GenericProduct:BaseModel
    {
        public string GenericName { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
