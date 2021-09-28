using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class Meat: Product
    {
        public enum Category
        {
            HighestGrade = 10,
            FirstGrade = 7,
            SecondGrade = 3
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

        public Meat(Category category, Type type, string name, double price, double weight)
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
                if ((meat.CategoryField == CategoryField) && (meat.TypeField == TypeField))
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            return "This is Meat class";
        }

        public override void changePrice(int percent)
        {
            Price *= 1 + (double)(percent + CategoryField) / 100;
        }
    }
}
