using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains data about dairy
    class Dairy_products : Product
    {
        //Standarts mark-up
        private readonly List<(int, int)> _expirationDatePercent;

        //Exceptions:
        //    ArgumentException
        //    ArgumentNullException
        public Dairy_products(string name, double price, double weight, int expirationDate, DateTime dateTime)
            : base(name, price, weight, expirationDate, dateTime)
        {
            _expirationDatePercent =  new List<(int, int)> { (7, 15), (365, 8), (int.MaxValue, 2) };
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType().Name == typeof(Dairy_products).Name)
            {
                Dairy_products dairyProduct = (Dairy_products)obj;
                if (dairyProduct.Name == Name && dairyProduct.Price == Price && dairyProduct.Weight == Weight && 
                    dairyProduct.ExpirationDate == ExpirationDate && dairyProduct.CreateDateTime == CreateDateTime)
                    return true;
            }
            return false;
        }

        public override int GetHashCode() => nameof(Dairy_products).GetHashCode() + ToString().GetHashCode();

        public override string ToString()
        {
            return base.ToString();
        }

        //Exceptions:
        //    ArgumentException
        public override void ChangePrice(double percent)
        {
            int tempPercent = _expirationDatePercent[_expirationDatePercent.Count - 1].Item2;
            foreach (var elem in _expirationDatePercent)
                if (percent <= elem.Item1)
                    tempPercent = elem.Item2;

            if ((percent <= -100) && (int.MaxValue / Price) <= ((percent + tempPercent) / 100))
                throw new ArgumentException("Percent is too small or too large");
            else
                Price *= 1 + (double)(percent + tempPercent) / 100;
        }

        //Summary:
        //    Initialize object with data fro string
        //Exceptions:
        //    ArgumentException
        public static new Dairy_products Parse(string s)
        {
            Product baseProduct = Product.Parse(s);
            return new Dairy_products(baseProduct.Name, baseProduct.Price, baseProduct.Weight, baseProduct.ExpirationDate, baseProduct.CreateDateTime);
        }
    }
}
