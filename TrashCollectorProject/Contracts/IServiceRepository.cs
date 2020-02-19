using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Contracts
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        Service GetService(int serviceId);
        void CreateService(Service service);
    }
}
