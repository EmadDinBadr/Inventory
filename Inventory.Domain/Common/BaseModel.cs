using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public abstract class BaseModel
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
