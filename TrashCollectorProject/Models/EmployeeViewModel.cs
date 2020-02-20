﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Contracts;

namespace TrashCollectorProject.Models
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
