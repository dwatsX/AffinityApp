using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Matches
    {
        public Matches()
        {
            SharedInterests = new HashSet<Interests>();
        }

        public int MatchId { get; set; }

        public int ProfileId { get; set; }

        public int MatchedProfileId { get; set; }

        public Profile Profile { get; set; }

        public Profile MatchedProfile { get; set; }

        public ICollection<Interests> SharedInterests { get; set; }

    }
}
