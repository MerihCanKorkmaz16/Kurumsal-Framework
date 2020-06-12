using System;
using FluentValidation;
using KurumsalFramework.Northwind.Business.Concrete.Managers;
using KurumsalFramework.Northwind.DataAccess.Abstract;
using KurumsalFramework.Northwind.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace KurumsalMimari.Northwind.Business.Tests
{
    [TestClass]
    public class ProductManagerTest
    {
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_Validation_check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager = new ProductManager(mock.Object);

            productManager.Add(new Product());
        }
    }
}
