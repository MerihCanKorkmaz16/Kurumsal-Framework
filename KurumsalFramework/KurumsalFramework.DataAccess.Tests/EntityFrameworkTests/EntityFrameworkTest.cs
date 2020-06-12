using System;
using KurumsalFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KurumsalFramework.DataAccess.Tests.EntityFrameworkTests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal efProductDal = new EfProductDal();
            var result = efProductDal.GetList();

            Assert.AreEqual(79,result.Count);

        }
        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            EfProductDal efProductDal = new EfProductDal();
            var result = efProductDal.GetList(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);

        }
    }
}
