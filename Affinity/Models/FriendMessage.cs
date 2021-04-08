using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class FriendMessage
    {
        public int FriendMessageId { get; set; }

        public int SendingUserId { get; set; }

        public int ReceivingUserId { get; set; }

        public string MessageContent { get; set; }

        public string MessageDateTime { get; set; }

        public UserRelationship UserRelationship { get; set; }

        public int UserRelationshipId { get; set; }
    }
}
