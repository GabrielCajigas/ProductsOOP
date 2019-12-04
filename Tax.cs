



namespace products
{
    class Taxes
    {
        static public decimal FinalTax { get; set; }



        static public decimal AddTax(decimal _price, Products.ItemType _type, bool _isImport)
        {

            int percent = 0;
            if (_isImport) percent += 5;
            var tax = _price * percent / 100;
            if (_type.ToString() == ("other")) { FinalTax += tax; }
            return _price + tax;
        }
    }
}