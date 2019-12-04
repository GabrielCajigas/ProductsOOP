
using System;
using System.Collections.Generic;
using System.Linq;

namespace products
{
    class Products
    {
        public enum ItemType
        {
            book = 1,
            medical = 2,
            food = 3,
            other = 4
        }
        public class Product
        {
            public string Name { get; set; }
            public decimal BasePrice { get; set; }
            public bool IsImport { get; set; }
            public ItemType Type { get; set; }
            public decimal PriceAndTax { get; set; }

            public Product(string _name, decimal _basePrice, bool _isImport, ItemType _type)
            {
                Name = _name;
                BasePrice = _basePrice;
                IsImport = _isImport;
                Type = _type;
                PriceAndTax = Taxes.AddTax(_basePrice, _type, _isImport);
            }
            static public void Log(List<Products.Product> ProdList)
            {

                var grouping = ProdList.GroupBy(p => new { p.Name, p.BasePrice, p.Type, p.IsImport })
                                                 .Select(p => new
                                                 {
                                                     _prodName = p.Key.Name,
                                                     _sum = p.Sum(z => z.BasePrice),
                                                     _count = p.Count(),
                                                     _prodPrice = p.Key.BasePrice,
                                                     _isOther = p.Key.Type,
                                                     _isImport = p.Key.IsImport,
                                                 });

                foreach (var product in grouping)
                {
                    if (product._count > 1)
                    {
                        Console.WriteLine(product._prodName + ": " + string.Format("{0:0.00}", Taxes.AddTax(product._sum, product._isOther, product._isImport)) + " (" + product._count + " @ " + product._prodPrice + ")");
                    }

                    else
                    {
                        Console.WriteLine(product._prodName + ": " + string.Format("{0:0.00}", Taxes.AddTax(product._sum, product._isOther, product._isImport)));
                    }

                }
                Console.WriteLine("Sales Taxes: " + string.Format("{0:0.00}", Taxes.FinalTax));
                Console.WriteLine("Total: " + string.Format("{0:0.00}", ProdList.Sum(product => product.PriceAndTax) + Taxes.FinalTax));
                // Console.ReadLine();

            }

        }
    }
}