using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    sealed class Check
    {
        public Check()
        {

        }
        public void print(Buy buy)
        {
            if (buy == null)
                throw new ArgumentNullException("Buy not set");

            Console.WriteLine($"Name: {buy.Prod.Name} Price: {buy.Prod.Price} Weight: {buy.Prod.Weight}\nCount: {buy.Count}\nTotal price: " +
                    $"{buy.TotalPrice}\nTotal weight: {buy.TotalWeight}\n");
        }
    }

    //Помилка при спробі наслідування
    /*class CheckDerived : Check
    {
        public CheckDerived()
        {

        }
    }*/
}
