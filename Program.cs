using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Apple", 5.50, 0.120);
            Product product2 = new Product("Sugar", 30, 1);
            Product product3 = new Product("Bread", 15, 0.5);

            Buy buy1 = new Buy(product1, 7);
            Buy buy2 = new Buy(product2, 2);
            Buy buy3 = new Buy(product3, 4);

            Check check = new Check();
            check.print(buy1);
            check.print(buy2);
            check.print(buy3);

            Storage storage = new Storage();
            storage.readInput();
            storage.print();
        }
    }
}
