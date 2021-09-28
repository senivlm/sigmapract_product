using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Buy
    {
        public Product Prod { get; private set; }
        public int Count { get; private set; }
        public double TotalPrice { get; private set; }
        public double TotalWeight { get; private set; }


        public Buy(Product product, int count)
        {
            Prod = (product == null) ? throw new ArgumentNullException("Product not set") : product;
            Count = (count <= 0) ? throw new ArgumentNullException("The product name cannot be empty") : count;
            TotalPrice = Prod.Price * Count;
            TotalWeight = Prod.Weight * Count;
        }
    }
}
