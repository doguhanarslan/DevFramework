﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.DataAccess.NHibernate;
using DevFramework.Core.Entities;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate
{
    public class NhProductDal:NhEntityRepositoryBase<Product>,IProductDal
    {
        private NHibernateHelper _nHibernateHelper;
        public NhProductDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }


        public List<ProductDetail> GetProductDetails()
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from p in session.Query<Product>()
                    join c in session.Query<Category>() on p.ProductId equals c.CategoryId
                    select new ProductDetail
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        CategoryName = c.CategoryName
                    };
                return result.ToList();
            }
        }
    }
}
