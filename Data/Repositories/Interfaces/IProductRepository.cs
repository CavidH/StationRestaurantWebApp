using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAll(Expression<Func<Product,bool>> expression=null); 
    }
}
