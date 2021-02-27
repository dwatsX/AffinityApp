using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Interests
    {
        public Interests()
        {
            
        }
        public int InterestId { get; set; }
        public int InterestCategoryId { get; set; }
        public int InterestSubCategoryId { get; set; }

        [Display(Name = "Interest Category")]
        public virtual InterestCategory InterestCategory { get; set; }

        [Display(Name = "Interest Sub Category")]
        public virtual InterestSubCategory InterestSubCategory { get; set; }
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }  
    }
}
