using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public partial class User : IdentityUser<int>
    {
        public User()
        {
            
        }

        [Display(Name = "Account Number")]
        public string AccountNum { get; set; }

        //[Display(Name = "User Name")]
        //public override string UserName { get => base.UserName; set => base.UserName = value; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }
    }
}
