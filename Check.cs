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

        public string PrintBuy(Buy buy)
        {
            if (buy == null)
                throw new ArgumentException("Buy not set");

            return buy.ToString();
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
