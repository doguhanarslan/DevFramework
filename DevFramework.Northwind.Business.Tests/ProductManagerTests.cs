using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoMapper;
using DevFramework.Northwind.Business.Concrete.Managers;
using Moq;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;

namespace DevFramework.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTests
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            ProductManager productManager = new ProductManager(mock.Object,mockMapper.Object);

            productManager.Add(new Product());
        }
    }
}
