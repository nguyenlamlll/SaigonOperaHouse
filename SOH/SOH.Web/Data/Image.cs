using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Data
{
    public class Image
    {
        public Guid Id { get; set; }
        public string URI { get; set; }

        public Post Post { get; set; }
        public Product Product { get; set; }
        public Event Event { get; set; }
    }
}
