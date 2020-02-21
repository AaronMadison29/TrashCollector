using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Customer GetCustomer(string customerId) =>FindByCondition(c => c.IdentityId.Equals(customerId)).SingleOrDefault();
        public void CreateCustomer(Customer customer) => Create(customer);
        public Customer GetCustomerIncludeAll(string customerId) => FindByCondition(c => c.Id.Equals(customerId)).Include(c => c.Address).Include(x => x.Service).Include(y => y.IdentityUser).SingleOrDefault();
        public List<Customer> GetCustomersIncludeAll() => FindAll().Include(c => c.Address).Include(x => x.Service).Include(y => y.IdentityUser).ToList();
        public IdentityUser GetIdentityUser(string customerId)
        {
            var user = FindByCondition(c => c.IdentityId.Equals(customerId)).SingleOrDefault();

            return ApplicationDbContext.Users.Where(c => c.Id == user.IdentityId).First();
        }
    }
}
