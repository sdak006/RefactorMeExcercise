using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;

namespace RefactorMe
{
    public enum CurrencyCode
    {
        USD,
        EUR
    }

    public class ProductPriceConverter
    {
        private double rate;

        public ProductPriceConverter(CurrencyCode currencyCode)
        {
            switch (currencyCode)
            {
                case CurrencyCode.USD:
                    rate = 0.76;
                    break;
                case CurrencyCode.EUR:
                    rate = 0.67;
                    break;
            }
        }

        public List<Product> ConvertProductPrices(List<Product> products)
        {
            foreach (Product product in products)
            {
                product.Price *= rate;
            }
            return products;
        }
    }
}
