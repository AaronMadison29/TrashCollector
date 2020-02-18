using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollectorProject.Contracts
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        ICustomerRepository Customer { get; }
        IAddressRepository Address { get; }
        IServiceRepository Service { get; }
        void Save();
    }
}
