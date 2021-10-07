using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains data about dairy
    class Dairy_products : Product
    {
        //Standarts
        readonly List<(int, int)> ExpirationDatePercent = new List<(int, int)> { (7, 15), (365, 8), (int.MaxValue, 2) };

        //Exceptions:
        //    ArgumentException
        //    ArgumentNullException
        public Dairy_products(string name, double price, double weight, int expirationDate, DateTime dateTime)
            : base(name, price, weight, expirationDate, dateTime)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        //Exceptions:
        //    ArgumentException
        public override void ChangePrice(double percent)
        {
            int tempPercent = ExpirationDatePercent[ExpirationDatePercent.Count - 1].Item2;
            foreach (var elem in ExpirationDatePercent)
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
        public override void Parse(string s)
        {
            base.Parse(s);
        }
    }
}
