using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Employee GetEmployee(int employeeId) => FindByCondition(c => c.Id.Equals(employeeId)).SingleOrDefault();
        public void CreateEmployee(Employee employee) => Create(employee);
    }
}
