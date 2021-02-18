using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Image
    {
            public int ImageId { get; set; }
            public int UserId { get; set; }
            public virtual User User { get; set; }
    }
}
