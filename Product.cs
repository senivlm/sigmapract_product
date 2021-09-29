using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains data about product
    class Product
    {
        private string name;
        private double price;
        private double weight;

        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The product name cannot be empty");
                else
                    name = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product price cannot be <= 0");
                else
                    price = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product weight cannot be <= 0");
                else
                    weight = value;
            }
        }

        //Exceptions:
        //    ArgumentException
        //    ArgumentNullException
        public Product(string name, double price, double weight)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }

        //Summary:
        //    Checks if name both Product are the same
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
            return $"Name: {Name} Price: {Price} Weight: {Weight}";
        }

        //Exceptions:
        //    ArgumentException
        virtual public void ChangePrice(double percent)
        {
            if ((percent <= -100) && (int.MaxValue / Price) <= (percent / 100))
                throw new ArgumentException("Percent is too small or too large");
            else
                Price *= 1 + percent / 100;
        }
    }
}
