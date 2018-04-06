using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Data
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
