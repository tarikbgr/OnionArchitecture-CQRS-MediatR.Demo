﻿using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Aplication.Interfaces.Repository
{
    public interface IProductRepository:IGenericRepositoryAsync<Product>
    {
        
    }
}
