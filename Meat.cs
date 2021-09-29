using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Class contains data about meat
    class Meat : Product
    {
        public enum Category
        {
            Highest = 10,
            First = 7,
            Second = 3
        }

        public enum Type
        {
            Lamb,
            Veal,
            Pork,
            Chicken
        }

        public Category CategoryField { get; set; }
        public Type TypeField { get; set; }

        //Exceptions:
        //    ArgumentException
        //    ArgumentNullException
        public Meat(string name, double price, double weight, Category category, Type type)
            : base(name, price, weight)
        {
            CategoryField = category;
            TypeField = type;
        }

        //Summary:
        //    Checks if all fields are the same
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Meat))
            {
                Meat meat = (Meat)obj;
                if ((meat.CategoryField == CategoryField) && (meat.TypeField == TypeField) && ((Product)this).Equals((Product)meat) )
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCategory: {CategoryField} Type: {TypeField}";
        }

        //Exceptions:
        //    ArgumentException
        public override void ChangePrice(double percent)
        {
            if ((percent <= -100) && (int.MaxValue / Price) <= ((percent + (double)CategoryField) / 100))
                throw new ArgumentException("Percent is too small or too large");
            else
                Price *= 1 + (percent + (double)CategoryField) / 100;
        }
    }
}
