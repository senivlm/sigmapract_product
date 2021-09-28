using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Dairy_products: Product
    {
        //Standarts
        readonly List<(int, int)> ExpirationDatePercent = new List<(int, int)> { (7, 15), (365, 8), (int.MaxValue, 2) };

        public int ExpirationDate { get; set; }

        public Dairy_products(int expirationDate, string name, double price, double weight)
            : base(name, price, weight)
        {
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return "This is Dairy_products class";
        }

        public override void changePrice(int percent)
        {
            int tempPercent = ExpirationDatePercent[ExpirationDatePercent.Count - 1].Item2;
            foreach (var elem in ExpirationDatePercent)
                if (percent <= elem.Item1)
                    tempPercent = elem.Item2;

            Price *= 1 + (double)(percent + tempPercent) / 100;
        }
    }
}
