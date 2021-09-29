using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    static class ProductInput
    {
        static public string StorageConsoleProductInput()
        {
            string input = "";

            Console.WriteLine("Виберіть режим заповнення: 1 - вручну, 2 - автоматично;");
            int regime = Convert.ToInt32(Console.ReadLine());

            if (regime == 1)
            {
                Console.WriteLine("Введіть кількість товарів:");
                int productCount = Convert.ToInt32(Console.ReadLine());
                input += productCount + "\n";

                for (int i = 0; i < productCount; i++)
                {
                    Console.WriteLine($"Виберіть {i + 1} товар: 1 - м'ясо, 2 - молочні продукти, 3 - інше");
                    int productType = Convert.ToInt32(Console.ReadLine());
                    input += productType + "\n";

                    switch(productType)
                    {
                        case 1:
                            Console.WriteLine($"Введіть назву, ціну, вагу, категорію(Highest, First, Second) та вид(Lamb, Veal, Pork or Chicken) через пробіл");
                            input += Console.ReadLine();
                            input += "\n";
                            break;
                        case 2:
                            Console.WriteLine($"Введіть назву, ціну, вагу та термін придатності через пробіл");
                            input += Console.ReadLine();
                            input += "\n";
                            break;
                        case 3:
                            Console.WriteLine($"Введіть назву, ціну та вагу через пробіл");
                            input += Console.ReadLine();
                            input += "\n";
                            break;
                        default:
                            Console.WriteLine("Невірний ввід, спробуйте ще раз");
                            i--;
                            break;
                    }
                }
            }
            else if (regime == 2)
            {
                input += "3\n3\nApple 5.50 0.120\n3\nSugar 30 1\n3\nBread 15 0.5";
            }

            return input;
        }
    }
}
