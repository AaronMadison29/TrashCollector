using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Address GetAddress(int addressId) => FindByCondition(c => c.Id.Equals(addressId)).SingleOrDefault();
        public void CreateAddress(Address address) => Create(address);
    }
}
