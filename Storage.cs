using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Storage
    {
        public List<Product> products { get; set; } = new List<Product>();

        public Product this[int index]
        {
            get
            {
                return products[index];
            }

            set
            {
                products[index] = value;
            }
        }

        public Storage()
        {

        }

        public void readInput()
        {
            Console.WriteLine("Виберіть режим заповнення: 1 - вручну, 2 - автоматично;");

            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Console.WriteLine("Виберіть кількістю товарів:");

                int countProduct = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < countProduct; i++)
                {
                    Console.WriteLine($"Введіть {i + 1} товар");
                    products.Add(new Product(Console.ReadLine(), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine())));
                }
            }
            else
            {
                products.Add(new Product("Apple", 5.50, 0.120));
                products.Add(new Product("Sugar", 30, 1));
                products.Add(new Product("Bread", 15, 0.5));
            }    
        }

        public List<Product> findMeatProduct()
        {
            List<Product> meatProducts = new List<Product>();

            foreach (var elem in products)
                if (elem.GetType() == typeof(Meat))
                    meatProducts.Add(elem);

            return meatProducts;
        }

        public void changePrice(int percent)
        {
            foreach (var elem in products)
                elem.Price *= 1 + (double)percent / 100;
        }

        public void print()
        {
            foreach (var elem in products)
                Console.WriteLine($"Name: {elem.Name} Price: {elem.Price} Weight: {elem.Weight}");
        }
    }
}
