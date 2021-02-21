using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ProfileID { get; set; }
        public Profile Profile { get; set; }
        public string ImageURL { get; set; }
    }
}
