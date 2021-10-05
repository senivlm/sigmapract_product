using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    //Summary:
    //    Class contains Products in Storage
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

        //Summary:
        //    Fills Storage with Products
        public void ReadInput()
        {
            StringReader inputStringReader = new StringReader(ProductInput.StorageFileProductInput());

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
                        if (Enum.TryParse(productInfo[5], out category) && Enum.TryParse(productInfo[6], out type))
                        {
                            string[] dateList = productInfo[4].Split(".");
                            DateTime dateTime = new DateTime(Convert.ToInt32(dateList[2]), Convert.ToInt32(dateList[1]), Convert.ToInt32(dateList[0]));
                            Products.Add(new Meat(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2]), 
                                Convert.ToInt32(productInfo[3]), dateTime, category, type));
                        }
                        break;
                    case 2:
                        {
                            string[] dateList = productInfo[4].Split(".");
                            DateTime dateTime = new DateTime(Convert.ToInt32(dateList[2]), Convert.ToInt32(dateList[1]), Convert.ToInt32(dateList[0]));
                            Products.Add(new Dairy_products(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2]), 
                                Convert.ToInt32(productInfo[3]), dateTime));
                        }
                        break;
                    case 3:
                        {
                            string[] dateList = productInfo[4].Split(".");
                            DateTime dateTime = new DateTime(Convert.ToInt32(dateList[2]), Convert.ToInt32(dateList[1]), Convert.ToInt32(dateList[0]));
                            Products.Add(new Product(productInfo[0], Convert.ToDouble(productInfo[1]), Convert.ToDouble(productInfo[2]), Convert.ToInt32(productInfo[3]), dateTime));
                        }
                        break;
                }
            }
        }

        //Summary:
        //    Finds in Products Meat
        //Returns:
        //    List of Meat
        public List<Product> FindMeatProduct()
        {
            List<Product> meatProducts = new List<Product>();

            foreach (var elem in Products)
                if (elem.GetType() == typeof(Meat))
                    meatProducts.Add(elem);

            return meatProducts;
        }

        //Summary:
        //    Change price for all Products
        //Exceptions:
        //    ArgumentException
        public void ChangePrice(double percent)
        {
            foreach (var elem in Products)
                elem.ChangePrice(percent);
        }

        public override string ToString()
        {
            string output = "\nStorage:\n";

            for(int i = 0; i < Products.Count; i++)
                output += $"Product {i + 1}:\n" + this[i].ToString();

            return output;
        }

        //Summary:
        //    Print all Products data
        //Returns:
        //    String with Products data
        public string Print()
        {
            return this.ToString();
        }
    }
}
