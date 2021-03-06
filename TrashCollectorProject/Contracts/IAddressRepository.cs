﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrashCollectorProject.Models;

namespace TrashCollectorProject.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Address GetAddress(int addressId);
        void CreateAddress(Address address);
    }
}
