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
            GroupEvents = new HashSet<Event>();
            Images = new HashSet<Image>();
            MemberProfiles = new HashSet<Profile>();

        }

        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }        
        public  int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual ICollection<Profile> MemberProfiles { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Event> GroupEvents { get; set; }
    }
}
