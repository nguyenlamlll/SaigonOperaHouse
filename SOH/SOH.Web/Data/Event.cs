using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOH.Web.Data
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }

        public string TicketInformation { get; set; }
        public string TimeInformation { get; set; }
        public string AgeInformation { get; set; }
        public string CategoryInformation { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
