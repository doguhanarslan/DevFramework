﻿using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.ComplexTypes;

namespace DevFramework.Northwind.DataAccess.Abstract
{
    public interface IProductDal :IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();
    }
}
