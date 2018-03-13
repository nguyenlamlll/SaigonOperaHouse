using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Data
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Int64 Price { get; set; }
        public int StockQuantity { get; set; }
    
        public ICollection<Image> Images { get; set; }
    }
}
