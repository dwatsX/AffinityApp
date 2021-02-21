using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Image> Images { get; set; }
        public string Description { get; set; }

    }
}
