using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class InterestCategory
    {
        public InterestCategory()
        {
            InterestSubCategories = new HashSet<InterestSubCategory>();
        }
        public int InterestCategoryId { get; set; }
        public string InterestCategoryName { get; set; }

        public virtual ICollection<InterestSubCategory> InterestSubCategories { get; set; }


    }
}
