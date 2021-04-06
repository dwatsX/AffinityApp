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
            Groups = new HashSet<Group>();
            Images = new HashSet<Image>();
            Interests = new HashSet<Interests>();
            Matches = new HashSet<Matches>();
            RelatedRelationships = new HashSet<UserRelationship>();
            RelatingRelationships = new HashSet<UserRelationship>();
        }
        [Key]
        public int ProfileId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Group> Groups { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Interests> Interests { get; set; }
        public ICollection<Matches> Matches { get; set; }

        /// <summary>
        /// Relationships where this User has Friended a User
        /// </summary>
        public virtual ICollection<UserRelationship> RelatedRelationships { get; set; }
        /// <summary>
        /// Relationships where this User was Friended by another User
        /// </summary>
        public virtual ICollection<UserRelationship> RelatingRelationships { get; set; }
        public string ProfileName {get; set;}
        public string Description { get; set; }
        public string Discord { get; set; }
        public string Instagram { get; set; }
        public string Location { get; set; }
        public string Occupation { get; set; }
        public string Education { get; set; }
        public DateTime Birthday { get; set; }
        public Frequency Alcohol { get; set; }
        public Frequency Marijuana { get; set; }
        public Frequency Cigarettes { get; set; }

    }

    public enum Frequency
    {
        Never, 
        Sometimes, 
        Socially, 
        Daily
    }
}
