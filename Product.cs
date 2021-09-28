using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Product
    {
        internal string Name { get; set; }
        internal double Price { get; set; }
        internal double Weight { get; set; }

        public Product(string name, double price, double weight)
        {
            Name = (name == null) ? throw new ArgumentNullException("The product name cannot be empty") : name;
            Price = (price <= 0) ? throw new ArgumentNullException("The product name cannot be empty") : price;
            Weight = (weight <= 0) ? throw new ArgumentNullException("The product name cannot be empty") : weight;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Product))
            {
                Product product = (Product)obj;
                if (product.Name == Name)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "This is Product class";
        }

        virtual public void changePrice(int percent)
        {
            Price *= 1 + (double)percent / 100;
        }
    }
}
