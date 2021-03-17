using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class UserRelationship
    {
        public int UserRelationshipId { get; set; }
        /// <summary>
        /// This User's ID.
        /// </summary>
        public int RelatingUserId { get; set; }
        /// <summary>
        /// This user's related User's ID (ie: Friend).
        /// </summary>
        public int RelatedUserId { get; set; }
        /// <summary>
        /// The relationship type for these two users.
        /// </summary>
        public Relationship Type { get; set; }

        /// <summary>
        /// This User.
        /// </summary>
        public Profile RelatingUser { get; set; }
        /// <summary>
        /// This user's related User (ie: Friend).
        /// </summary>
        public Profile RelatedUser { get; set; }
    }
    public enum Relationship
    {
        Pending,
        Friend,
        Blocked,
    }
}
