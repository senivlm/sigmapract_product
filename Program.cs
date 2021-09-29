using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Product product1 = new Product("Apple", 5.50, 0.120);
            Product product2 = new Product("Sugar", 30, 1);
            Product product3 = new Product("Bread", 15, 0.5);

            List<Product> list = new List<Product>() { product1, product2, product3 };
            Buy buy = new Buy(list, list.Count);

            Check check = new Check();
            Console.WriteLine(check.PrintBuy(buy));

            Storage storage = new Storage();
            storage.ReadInput();
            Console.WriteLine(storage.Print());
        }
    }
}
