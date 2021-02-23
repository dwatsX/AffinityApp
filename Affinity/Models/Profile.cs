using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Profile
    {
        public Profile()
        {
            Images = new HashSet<Image>();
            Interests = new HashSet<Interests>();  
        }
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Interests> Interests { get; set; }
        public string Description { get; set; }

    }
}
