using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Group
    {
        public Group()
        {
            CreatedEvents = new HashSet<Event>();
            JoinedEvents = new HashSet<EventGroup>();

        }

        public int id { get; set; }
        public virtual ICollection<Event> CreatedEvents { get; set; }
        public virtual ICollection<EventGroup> JoinedEvents { get; set; }


    }
}
