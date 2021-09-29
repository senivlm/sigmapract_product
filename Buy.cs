using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains buy data
    class Buy
    {
        private List<Product> productsList;
        private int count = 0;

        public List<Product> ProductsList
        {
            get
            {
                return productsList;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException("Product list not set");
                else
                {
                    productsList = value;
                    count++;
                }
            }
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= productsList.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                else
                    return productsList[index];
            }

            set
            {
                if (index < 0 || index >= productsList.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                else
                    productsList[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Element count cannot be <= 0");
                else
                    count = value;
            }
        }

        public double TotalPrice { get; private set; }
        public double TotalWeight { get; private set; }

        //Exception:
        //    ArgumentException
        //    ArgumentNullException
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

        //Summary:
        //    Adds Product into list
        //Exception:
        //    ArgumentNullException
        public void AddProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product not set");
            else
                productsList.Add(product);
        }
    }
}
