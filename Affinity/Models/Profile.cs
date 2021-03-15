using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            Matches = new HashSet<Matches>();
        }
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Interests> Interests { get; set; }
        public ICollection<Matches> Matches { get; set; }
        public string ProfileName {get; set;}
        public string Description { get; set; }
        public string Discord { get; set; }
        public string Instagram { get; set; }
        public string Location { get; set; }
        public string Occupation { get; set; }

    }
}
