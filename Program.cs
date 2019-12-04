using System;
using System.Collections.Generic;
using System.Linq;



namespace products
{
    class Program
    {
        static private decimal FinalTax;



        static public decimal AddTax(decimal _price, Products.ItemType _type, bool _isImport)
        {

            int percent = 0;
            if (_isImport) percent += 5;
            var tax = _price * percent / 100;
            if (_type.ToString() == ("other")) { FinalTax += tax; }
            return _price + tax;
        }



        static void Main(string[] args)
        {
            var _prodList = new List<Products.Product>();
            while (true)
            {

                Console.WriteLine("--- Please Select Type ---");
                Console.WriteLine("1- Book, 2-Food, 3-Medical Product or 4other");
                Console.WriteLine("Please select a menu option or 'E' to end:");
                var user = Console.ReadLine();
                if (user.Equals("E"))
                {
                    if (_prodList.Count == 0)
                    {
                        Console.WriteLine("Program has been terminated and no Product was added");
                        break;
                    }
                    Products.Product.Log(_prodList);
                    break;
                }

                Console.WriteLine("Is this product an import? (Y/N)");
                var _import = (Console.ReadLine().ToUpper().Equals("Y")) ? true : false;
                var _other = (user.Equals("4")) ? true : false;

                Console.WriteLine("***Please enter the price***");
                var _price = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Please enter the name for the product");
                var _name = Console.ReadLine();
                Products.ItemType eltype = Products.ItemType.other;
                if (!_other)
                {

                    eltype = Products.ItemType.food;
                }

                _prodList.Add(new Products.Product(_name, _price, _import, eltype));

            }
        }
    }
}
