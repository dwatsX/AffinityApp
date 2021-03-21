using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Affinity.Models;

namespace Affinity.ViewModels
{
    public class MatchesViewModel
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Profile Profile { get; set; }
        public List<Image> Images { get; set; }
        public List<Interests> Interests { get; set; }
        public string Image { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        
    }
}
