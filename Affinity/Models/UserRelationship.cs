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
        public int RelatingProfileId { get; set; }
        /// <summary>
        /// This user's related User's ID (ie: Friend).
        /// </summary>
        public int RelatedProfileId { get; set; }
        /// <summary>
        /// The relationship type for these two users.
        /// </summary>
        public Relationship Type { get; set; }

        /// <summary>
        /// This Users profile.
        /// </summary>
        public Profile RelatingProfile { get; set; }
        /// <summary>
        /// This user's related Profile (ie: Friend).
        /// </summary>
        public Profile RelatedProfile { get; set; }
        /// <summary>
        /// This User.
        /// </summary>
        public User RelatingUser { get; set; }
        /// <summary>
        /// This user's related User (ie: Friend).
        /// </summary>
        public User RelatedUser { get; set; }

        public virtual ICollection<FriendMessage> FriendMessages { get; set; }
    }
    public enum Relationship
    {
        Pending,
        Friend,
        Blocked,
    }
}
