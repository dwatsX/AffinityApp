using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class InterestSubCategory
    {
        public InterestSubCategory()
        {
            Interests = new HashSet<Interests>();
        }
        public int InterestSubCategoryId { get; set; }

        public int InterestCategoryId { get; set; }

        [Display(Name = "Interest Category")]
        public virtual InterestCategory InterestCategory { get; set; }
        public string InterestSubCategoryName { get; set; }

        public virtual ICollection<Interests> Interests { get; set; }

    }
}
