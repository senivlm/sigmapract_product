using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //Buy and Check
            try
            {
                Product product1 = new Product("Apple", 5.50, 0.120, 20, new DateTime(2021, 9, 15));
                Product product2 = new Product("Sugar", 30, 1, 10, new DateTime(2021, 7, 31));
                Product product3 = new Product("Bread", 15, 0.5, 7, new DateTime(2021, 10, 6));

                List<Product> list = new List<Product>() { product1, product2, product3 };
                Buy buy = new Buy(list, list.Count);

                Check check = new Check();
                Console.WriteLine(check.PrintBuy(buy));
            }
            catch(Exception exception)
            {
                ShowException.ConsoleWrite(exception.Message);
            }

            //Storage
            try
            {
                Storage storage = new Storage();
                storage.OnShow += StorageEvents.FindAndRemoveOverdueProducts;
                storage.OnWrongInput += StorageEvents.WrongProductInput;

                storage.ReadInput(ProductInput.StorageProductInput());
                //Вивід storage та спрацювання події пошуку перетермінованих товарів
                Console.WriteLine(storage.Print());

                Storage storage1 = new Storage();
                storage1.ReadInput(ProductInput.StorageProductInput());

                //Всі спільні продукти
                StorageSearcher storageSearcher = new StorageSearcher();
                Console.WriteLine("\nJoint products in first and second storage:");
                foreach (var elem in storageSearcher.GetJointProducts(storage, storage1))
                    Console.WriteLine(elem);

                //Всі продукти в першому складі, яких немає в 2 складі
                Console.WriteLine("\nProducts in first storage except products in second storage:");
                foreach (var elem in storageSearcher.GetProductsExcept(storage, storage1))
                    Console.WriteLine(elem);

                //Всі різні продукти
                Console.WriteLine("\nDifferent products in first and second storage:");
                foreach (var elem in storageSearcher.GetDifferentProducts(storage, storage1))
                    Console.WriteLine(elem);

            }
            catch (FileNotFoundException exception)
            {
                ShowException.ConsoleWrite("Storage: " + exception.Message);
            }
            catch (IndexOutOfRangeException exception)
            {
                ShowException.ConsoleWrite("Storage: " + exception.Message);
            }
            catch (ArgumentNullException exception)
            {
                ShowException.ConsoleWrite("Storage: " + exception.Message);
            }
            catch (ArgumentException exception)
            {
                ShowException.ConsoleWrite("Storage: " + exception.Message);
            }
            catch (Exception exception)
            {
                ShowException.ConsoleWrite("Storage: " + exception.Message);
            }
        }
    }
}
