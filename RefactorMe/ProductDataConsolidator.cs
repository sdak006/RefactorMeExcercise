using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Data;

namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        private IReadOnlyRepository<Lawnmower> _lawnmowerRepo;
        private IReadOnlyRepository<TShirt> _tShirtRepo;
        private IReadOnlyRepository<PhoneCase> _phoneCaseRepo;

        public ProductDataConsolidator(IReadOnlyRepository<Lawnmower> lawnmowerRepo, IReadOnlyRepository<TShirt> tShirtRepo, IReadOnlyRepository<PhoneCase> phoneCaseRepo)
        {
            _lawnmowerRepo = lawnmowerRepo;
            _tShirtRepo = tShirtRepo;
            _phoneCaseRepo = phoneCaseRepo;
        }

        private List<Product> convertFromRepo<T>(IReadOnlyRepository<T> repository, string type) where T : class
        {
            IQueryable<T> rawData = repository.GetAll();
            List<Product> products = rawData
                .Select(x => new Product()
                { 
                    Id = (Guid)x.GetType().GetProperty("Id").GetValue(x, null),
                    Name = (string)x.GetType().GetProperty("Name").GetValue(x, null),
                    Price = (double)x.GetType().GetProperty("Price").GetValue(x, null),
                    Type = type
                }).ToList();
            return products;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.AddRange(convertFromRepo(_lawnmowerRepo, "Lawnmower"));
            products.AddRange(convertFromRepo(_tShirtRepo, "T-Shirt"));
            products.AddRange(convertFromRepo(_phoneCaseRepo, "Phone Case"));
            return products;
        }

        public List<Product> GetProductsUsingForeignCurrency(CurrencyCode currencyCode)
        {
            ProductPriceConverter converter = new ProductPriceConverter(currencyCode);
            return converter.ConvertProductPrices(GetProducts());
        }
    }
}
