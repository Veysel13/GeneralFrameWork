using System;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyFramework.Business.Concrete.Managers;
using MyFramework.DataAccess.Abstract;
using MyFramework.Entities.Concrete;

namespace MyFramework.Business.Tests
{
    //nuget paketden moq paketini kuruyoruz
    //moq diğer katmanlarla baglantı olan veriler olduğunda istediğimiz testi yapmamızı sağlar

    
    [TestClass]
    public class ProductManagerTests
    {
        //testin geçebilmesi için exception beklediğimizi bu exceptionında ValidationException oldugunu söyledik
        //eğer hata olursa test başarılı eğer hata gelmesse  test çalışmıyor demektir
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Product_validation_check()
        {
            //bize bir iproductDal vermesini soyledik
            Mock<IProductDal> mock = new Mock<IProductDal>();
            ProductManager productManager=new ProductManager(mock.Object);
            productManager.Add(new Product());
        }
    }
}
