using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class GroupMessage
    {
        public int GroupMessageId { get; set; }

        public int SendingUserProfileId { get; set; }

        public string SendingUserProfileName { get; set; }

        public string MessageContent { get; set; }

        public string MessageDateTime { get; set; }

        public Group Group { get; set; }

        public int GroupId { get; set; }
    }
}
