using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Models
{
    public class Event
    {
        public Event()
        {
            EventGroups = new HashSet<EventGroup>();
        }

        public virtual int EventId { get; set; }
        [Required(ErrorMessage = "User is required.")]
        public virtual int GroupId { get; set; }
        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Event Name is required.")]
        public virtual string EventName { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public virtual string EventDescription { get; set; }
        [Display(Name = "Date & Time")]
        public virtual DateTime EventDateTime { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<EventGroup> EventGroups { get; set; }
    }
}
