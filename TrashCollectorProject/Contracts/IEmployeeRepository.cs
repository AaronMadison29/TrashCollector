﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Employee GetEmployee(int employeeId);
        void CreateEmployee(Employee employee);
    }
}
