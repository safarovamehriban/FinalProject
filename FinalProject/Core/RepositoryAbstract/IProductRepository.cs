﻿using Core.Models;
using Core.RepoAbstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.RepositoryAbstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
