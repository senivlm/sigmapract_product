using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Buy
    {
        private List<Product> productsList;
        private int count;

        public List<Product> ProductsList
        {
            get
            {
                return productsList;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentException("Product list not set");
                else
                    productsList = value;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Element count cannot be <= 0");
                else
                    count = value;
            }
        }

        public double TotalPrice { get; private set; }
        public double TotalWeight { get; private set; }

        public Buy(List<Product> product, int count)
        {
            ProductsList = product;
            Count = count;

            foreach (var elem in ProductsList)
            {
                TotalPrice = elem.Price * Count;
                TotalWeight = elem.Weight * Count;
            }
        }

        public override string ToString()
        {
            string str = "";
            foreach (var elem in ProductsList)
                str += $"Product: " + elem.ToString();
            return str + $"\nCount: {Count}\nTotal price: {TotalPrice}\nTotal weight: {TotalWeight}";
        }
    }
}
