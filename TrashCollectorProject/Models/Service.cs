using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public bool isActive { get; set; }
        public DateTime SuspensionStart { get; set; }
        public DateTime SuspensionEnd { get; set; }
        public DayOfWeek PickupDay { get; set; }
        public double Balance { get; set; }
    }
}
