using Affinity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.ViewModels
{
    public class FriendsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserRelationship> PendingRelationships { get; set; }
        public List<UserRelationship> FriendRelationships { get; set; }
    }
}
