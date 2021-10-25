using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    static class StorageEvents
    {
        public static void FindAndRemoveOverdueProducts(Storage storage)
        {
            List<Product> products = storage.OverdueProducts();

            if (products.Count == 0)
                return;

            Console.WriteLine("Remove overdue products and write to log? : 1 - yes, 2 - no");
            int answer;
            while (!(Int32.TryParse(Console.ReadLine(), out answer) && (answer == 1 || answer == 2)))
                Console.WriteLine("Incorrect input. Try again");

            if (answer == 1)
            {
                foreach (var elem in products)
                    storage.RemoveProduct(elem);

                using (StreamWriter stream = new StreamWriter("../../../files/log.txt", true))
                {
                    stream.WriteLine(DateTime.Now + "\nRemoved overdue products:");
                    foreach (var elem in products)
                        stream.WriteLine(elem);
                }
            }
        }

        public static void WrongProductInput(Storage storage, string message)
        {
            Console.WriteLine("Incorrect product input: " + message);
            Console.WriteLine("Write data to log or correct them and add to storage? : 1 - write, 2 - correct");
            int answer;
            while (!(Int32.TryParse(Console.ReadLine(), out answer) && (answer == 1 || answer == 2)))
                Console.WriteLine("Incorrect input. Try again");

            if (answer == 1)
            {
                using (StreamWriter stream = new StreamWriter("../../../files/log.txt", true))
                {
                    stream.WriteLine(DateTime.Now + "\nIncorrect product input: " + message);
                }
            }
            else
            {
                bool added = false;
                int productType = -1;
                string productInfo;
                Console.WriteLine("Enter product type: 1 - meat, 2 - dairy, 3 - product");
                while (!(Int32.TryParse(Console.ReadLine(), out productType) && (productType == 1 || productType == 2 || productType == 3)))
                    Console.WriteLine("Incorrect type. Try again");

                while (!added)
                {
                    Console.WriteLine("Enter correct product data:");
                    productInfo = Console.ReadLine();
                    try
                    {
                        switch (productType)
                        {
                            case 1:
                                storage.AddProduct(Meat.Parse(productInfo));
                                added = true;
                                break;
                            case 2:
                                storage.AddProduct(Dairy_products.Parse(productInfo));
                                added = true;
                                break;
                            case 3:
                                storage.AddProduct(Product.Parse(productInfo));
                                added = true;
                                break;
                        }
                    }
                    catch (ArgumentException exception)
                    {
                        Console.WriteLine("Incorrect product input. Error: " + exception.Message + ". Try again");
                    }
                }
            }
        }
    }
}
