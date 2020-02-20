using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Account Active")]
        [DefaultValue(true)]
        public bool isActive { get; set; }

        [Display(Name = "Suspension Start")]
        public DateTime? SuspensionStart { get; set; }

        [Display(Name = "Suspension End")]
        public DateTime? SuspensionEnd { get; set; }

        [Display(Name = "One Time Pickup")]
        public DateTime? OneTimePickup { get; set; }

        [Display(Name = "Pickup Day")]
        public DayOfWeek PickupDay { get; set; }
        public double Balance { get; set; }

        
    }
}
