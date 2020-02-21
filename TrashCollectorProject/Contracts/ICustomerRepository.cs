using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetCustomer(string customerId);
        void CreateCustomer(Customer customer);
        Customer GetCustomerIncludeAll(string customerId);
        List<Customer> GetCustomersIncludeAll();
        public IdentityUser GetIdentityUser(string customerId);
    }
}
