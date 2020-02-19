using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Contracts;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Data
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public Service GetService(int serviceId) => FindByCondition(c => c.Id.Equals(serviceId)).SingleOrDefault();
        public void CreateService(Service service) => Create(service);
    }
}
