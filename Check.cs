using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Class prints data about Buy
    sealed class Check
    {
        public Check()
        {

        }

        //Exception:
        //    ArgumentNullException
        public string PrintBuy(Buy buy)
        {
            if (buy == null)
                throw new ArgumentNullException("Buy not set");

            return "CHECK:\n" + buy.ToString();
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
