using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;

namespace DevFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal = new EfProductDal();

            var result = productDal.GetList();

            Assert.AreEqual(79,result.Count);
        }
    }
}
