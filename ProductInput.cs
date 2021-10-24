using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1
{
    //Summary:
    //    Class for reading user input
    static class ProductInput
    {
        static public string StorageProductInput()
        {
            int regime;

            Console.WriteLine("Заповнення складу:\nВиберіть режим заповнення: 1 - вручну, 2 - автоматично, 3 - з файлу:");

            try
            {
                regime = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new ArgumentException("Incorrect input. Cannot set regime of filling the warehouse");
            }

            if (regime == 1)
            {
                return StorageConsoleProductInput();
            }
            else if (regime == 2)
            {
                string input = "3\n3\nApple 5.50 0.120 20 15.9.2021\n3\nSugar 30 1 90 23.12.2020\n3\nBread 15 0.5 3 05.10.2021";
                return input;
            }
            else if (regime == 3)
            {
                return StorageFileProductInput();
            }
            else
            {
                throw new ArgumentException("Incorrect input. Cannot set regime of filling the warehouse");
            }
        }

        //Summary:
        //    Reads from console
        //Returns:
        //    Data for Storage
        static public string StorageConsoleProductInput()
        {
            string input = "";

            Console.WriteLine("Введіть кількість товарів:");
            int productCount = Convert.ToInt32(Console.ReadLine());
            input += productCount + "\n";

            for (int i = 0; i < productCount; i++)
            {
                Console.WriteLine($"Виберіть {i + 1} товар: 1 - м'ясо, 2 - молочні продукти, 3 - інше");
                int productType = Convert.ToInt32(Console.ReadLine());
                input += productType + "\n";

                switch (productType)
                {
                    case 1:
                        Console.WriteLine($"Введіть назву, ціну, вагу, термін придатності, дату виготовлення, " +
                            $"категорію(Highest, First, Second) та вид(Lamb, Veal, Pork or Chicken) через пробіл");
                        input += Console.ReadLine();
                        input += "\n";
                        break;
                    case 2:
                        Console.WriteLine($"Введіть назву, ціну, вагу, термін придатності та дату виготовлення через пробіл");
                        input += Console.ReadLine();
                        input += "\n";
                        break;
                    case 3:
                        Console.WriteLine($"Введіть назву, ціну, вагу, термін придатності та дату виготовлення через пробіл");
                        input += Console.ReadLine();
                        input += "\n";
                        break;
                    default:
                        Console.WriteLine("Невірний ввід, спробуйте ще раз");
                        i--;
                        break;
                }
            }
            return input;
        }

        //Summary:
        //    Reads from file
        //Returns:
        //    Data for Storage
        static public string StorageFileProductInput()
        {
            using (StreamReader streamReader = new StreamReader("../../../files/input.txt"))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
