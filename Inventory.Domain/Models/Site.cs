using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Models
{
    public class Site:BaseModel
    {
        public string SiteCode { get; set; }
        public string SiteName { get; set; }

        public ICollection<Warehouse> Warehouses { get; set; }=new List<Warehouse>();
    }
}
