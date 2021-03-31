using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class EventGroup
    {
        public int EventUserId { get; set; }

        public int EventId { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Event Event { get; set; }
    }
}
