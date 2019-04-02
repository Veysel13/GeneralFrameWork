using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFramework.DataAccess.Concrete.EntityFramework;
using MyFramework.DataAccess.Concrete.NHibernate;
using MyFramework.DataAccess.Concrete.NHibernate.Helpers;

namespace MyFramework.DataAccess.Tests.NHibernateTests
{
    [TestClass]
    public class NHibernateTests
    {
        //Entitlerimin virtual imzalı olması gerkiyor
        [TestMethod]
        public void Get_all_returns_all_products()
        {
        NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();
            Assert.AreEqual(81, result.Count);
        }

        [TestMethod]
        public void Get_all_with_parameter_returns_filtered_products()
        {
            NhProductDal productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));
            Assert.AreEqual(4, result.Count);
        }
    }
}
