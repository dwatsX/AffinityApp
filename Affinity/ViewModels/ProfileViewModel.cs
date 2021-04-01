using Affinity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.ViewModels
{
    public class ProfileViewModel
    {
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Profile Profile{ get; set; }
        public List<Image> Images { get; set; }
        public List<Interests> Interests { get; set; }
        public string ProfileName { get; set; }
        public string Description { get; set; }
        public string Discord { get; set; }
        public string Instagram { get; set; }
        public string Location { get; set; }
        public string Occupation { get; set; }
        public string Education { get; set; }
        public string Age { get; set; }
        public Frequency Alcohol { get; set; }
        public Frequency Marijuana { get; set; }
        public Frequency Cigarettes { get; set; }
    }
}
