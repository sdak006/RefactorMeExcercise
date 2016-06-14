using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Models;
using System.Linq;
using Moq;


namespace RefactorMe.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Random _randomNumGen = new Random();
        private Guid _lawnmowerGuid;
        private Guid _phoneCaseGuid;
        private Guid _tShirtGuid;
        private string _lawnmowerName;
        private string _phoneCaseName;
        private string _tShirtName;
        private double _lawnmowerPrice;
        private double _phoneCasePrice;
        private double _tShirtPrice;

        [TestMethod]
        public void GetProductsTest()
        {
            List<Product> expectedProducts = new List<Product>();
            Mock<IReadOnlyRepository<Lawnmower>> mockLawnmowerRepo = new Mock<IReadOnlyRepository<Lawnmower>>();
            Mock<IReadOnlyRepository<TShirt>> mockTShirtRepo = new Mock<IReadOnlyRepository<TShirt>>();
            Mock<IReadOnlyRepository<PhoneCase>> mockPhoneCaseRepo = new Mock<IReadOnlyRepository<PhoneCase>>();
            mockLawnmowerRepo.Setup(ur => ur.GetAll()).Returns(lawnmowerMockedGetAll());
            mockTShirtRepo.Setup(ur => ur.GetAll()).Returns(tShirtMockedGetAll());
            mockPhoneCaseRepo.Setup(ur => ur.GetAll()).Returns(phoneCaseMockedGetAll());
            ProductDataConsolidator consolidator = new ProductDataConsolidator(mockLawnmowerRepo.Object, mockTShirtRepo.Object, mockPhoneCaseRepo.Object);
            List<Product> actualProducts = consolidator.GetProducts();

            Assert.IsTrue(actualProducts.Any(x => x.Id == _lawnmowerGuid && x.Name == _lawnmowerName && x.Price == _lawnmowerPrice && x.Type == "Lawnmower"));
            Assert.IsTrue(actualProducts.Any(x => x.Id == _tShirtGuid && x.Name == _tShirtName && x.Price == _tShirtPrice && x.Type == "T-Shirt"));
            Assert.IsTrue(actualProducts.Any(x => x.Id == _phoneCaseGuid && x.Name == _phoneCaseName && x.Price == _phoneCasePrice && x.Type == "Phone Case"));
            Assert.AreEqual(actualProducts.Count, 3);
        }

        [TestMethod]
        public void GetProductsAndConvertCurrencyTest()
        {
            List<Product> expectedProducts = new List<Product>();
            Mock<IReadOnlyRepository<Lawnmower>> mockLawnmowerRepo = new Mock<IReadOnlyRepository<Lawnmower>>();
            Mock<IReadOnlyRepository<TShirt>> mockTShirtRepo = new Mock<IReadOnlyRepository<TShirt>>();
            Mock<IReadOnlyRepository<PhoneCase>> mockPhoneCaseRepo = new Mock<IReadOnlyRepository<PhoneCase>>();
            mockLawnmowerRepo.Setup(ur => ur.GetAll()).Returns(lawnmowerMockedGetAll());

            ProductDataConsolidator consolidator = new ProductDataConsolidator(mockLawnmowerRepo.Object, mockTShirtRepo.Object, mockPhoneCaseRepo.Object);
            List<Product> actualProducts = consolidator.GetProductsUsingForeignCurrency(CurrencyCode.EUR);

            Assert.AreEqual(_lawnmowerPrice * 0.67, actualProducts.First().Price);
        }

        private IQueryable<Lawnmower> lawnmowerMockedGetAll()
        {
            _lawnmowerGuid = Guid.NewGuid();
            _lawnmowerName = DateTime.Now.ToString() + " Lawnmower";
            _lawnmowerPrice = _randomNumGen.NextDouble() + 1;

            List<Lawnmower> products = new List<Lawnmower>() { new Lawnmower() { Id = _lawnmowerGuid, Name = _lawnmowerName, Price = _lawnmowerPrice } };
            return products.AsQueryable();
        }

        private IQueryable<TShirt> tShirtMockedGetAll()
        {
            _tShirtGuid = Guid.NewGuid();
            _tShirtName = DateTime.Now.ToString() + " T-Shirt";
            _tShirtPrice = _randomNumGen.NextDouble() + 1;

            List<TShirt> products = new List<TShirt>() { new TShirt() { Id = _tShirtGuid, Name = _tShirtName, Price = _tShirtPrice } };
            return products.AsQueryable();
        }

        private IQueryable<PhoneCase> phoneCaseMockedGetAll()
        {
            _phoneCaseGuid = Guid.NewGuid();
            _phoneCaseName = DateTime.Now.ToString() + " Phone Case";
            _phoneCasePrice = _randomNumGen.NextDouble() + 1;

            List<PhoneCase> products = new List<PhoneCase>() { new PhoneCase() { Id = _phoneCaseGuid, Name = _phoneCaseName, Price = _phoneCasePrice } };
            return products.AsQueryable();
        }
    }
}
