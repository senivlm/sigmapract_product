using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    class Storage
    {
        public List<Product> Products { get; private set; } = new List<Product>();

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= Products.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                else
                    return Products[index];
            }

            set
            {
                if (index < 0 || index >= Products.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                else
                    Products[index] = value;
            }
        }

        public Storage()
        {

        }

        public void ReadInput()
        {
            StringReader inputStringReader = new StringReader(ProductInput.StorageConsoleProductInput());

            int productsCount = Convert.ToInt32(inputStringReader.ReadLine());
            for (int i = 0; i < productsCount; i++)
            {
                int productsType = Convert.ToInt32(inputStringReader.ReadLine());
                string[] productInfo = inputStringReader.ReadLine().Split(" ");

                switch (productsType)
                {
                    case 1:
                        Meat.Category category;
                        Meat.Type type;
                        if (Enum.TryParse(productInfo[3], out category) && Enum.TryParse(productInfo[4], out type))
                            Products.Add(new Meat(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2]), category, type));
                        break;
                    case 2:
                        Products.Add(new Dairy_products(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2]), Convert.ToInt32(productInfo[3])));
                        break;
                    case 3:
                        Products.Add(new Product(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2])));
                        break;
                }
            }
        }

        public List<Product> FindMeatProduct()
        {
            List<Product> meatProducts = new List<Product>();

            foreach (var elem in Products)
                if (elem.GetType() == typeof(Meat))
                    meatProducts.Add(elem);

            return meatProducts;
        }

        public void ChangePrice(double percent)
        {
            foreach (var elem in Products)
                elem.ChangePrice(percent);
        }

        public override string ToString()
        {
            string output = "";

            for(int i = 0; i < Products.Count; i++)
                output += $"Product {i + 1}:\n" + this[i].ToString() + "\n";

            return output;
        }

        public void Print()
        {
            this.ToString();
        }
    }
}
