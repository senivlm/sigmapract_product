using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace Task1
{
    //Summary:
    //    Class contains Products in Storage
    class Storage
    {
        //
        public const string PATH = @"D:\Andrii\Programyvannya\C#\Sigma pract\Product\Task\output.txt";

        public delegate void PrintMessageHandler(string message);
        public delegate void PrintIncorrect(string path, string message);

        public virtual event PrintMessageHandler OnAdd;
        public virtual event PrintIncorrect OnWrongInput;
        //

        public List<Product> Products { get; }

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
            Products = new List<Product>();
        }

        //Summary:
        //    Fills Storage with Products
        public void ReadInput()
        {
            Products.Clear();

            StringReader inputStringReader = new StringReader(ProductInput.StorageProductInput());

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
                        else
                        {
                            OnWrongInput?.Invoke(PATH, "Wrong product!");
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

        public void AddProduct(Product product)
        {
            OnAdd?.Invoke("Add Product to Storage");
            Products.Add(product);
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
        //    Removes overdue Dairy Products and writes data in log
        public void RemoveOverdueDairyProduct(string path)
        {
            using (StreamWriter writeFile = new StreamWriter(path, true))
            {
                writeFile.WriteLine("Date: " + DateTime.Now + "\tRemoved: ");

                for (int i = 0; i < Products.Count; i++)
                    if (Products[i].GetType() == typeof(Dairy_products) && Products[i].CreateDateTime.AddDays(Products[i].ExpirationDate) < DateTime.Now)
                    {
                        writeFile.Write(Products[i].ToString());
                        Products.Remove(Products[i]);
                        i--;
                    }

                writeFile.WriteLine();
                writeFile.Close();
            }
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
            string output = "Storage:\n";

            for (int i = 0; i < Products.Count; i++)
                output += $"Product {i + 1}:\n" + this[i].ToString() + "\n";

            return output;
        }

        //Summary:
        //    Print all Products data
        //Returns:
        //    String with Products data
        public string Print()
        {
            return ToString();
        }
    }
}
