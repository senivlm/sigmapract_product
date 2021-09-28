using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Meat: Product
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

        public Meat(string name, double price, double weight, Category category, Type type)
            : base(name, price, weight)
        {
            CategoryField = category;
            TypeField = type;
        }

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
            return base.ToString() + $"\nCategory: {CategoryField} Type: {TypeField}\n";
        }

        public override void ChangePrice(double percent)
        {
            Price *= 1 + (percent + (double)CategoryField) / 100;
        }
    }
}
