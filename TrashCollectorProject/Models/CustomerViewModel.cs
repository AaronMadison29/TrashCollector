using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Models
{
    public class CustomerViewModel
    {
        public Address Address {get;set;}
        public Customer Customer { get; set; }
        public IdentityUser IdentityUser { get; set; }
        public Service Service { get; set; }
    }
}
