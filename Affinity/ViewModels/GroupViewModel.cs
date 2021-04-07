using Affinity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.ViewModels
{
    public class GroupViewModel
    {
        public int GroupId { get; set; }
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
        public List<Profile> Members { get; set; }
        public List<Event> Events { get; set; }
        public string GroupName { get; set; }
        public string GroupDescription { get; set; }
        public string ImageUrl { get; set; }

    }
}
