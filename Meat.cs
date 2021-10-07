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
        public Meat(string name, double price, double weight, int expirationDate, DateTime dateTime, Category category, Type type)
            : base(name, price, weight, expirationDate, dateTime)
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
            return base.ToString() + $"Category: {CategoryField} Type: {TypeField}\n";
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

        //Summary:
        //    Initialize object with data fro string
        //Exceptions:
        //    ArgumentException
        public override void Parse(string s)
        {
            string[] inputData = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputData.Length != 7)
                throw new ArgumentException("Data in line is incorrect");

            string baseInput = string.Join(" ", inputData, 0, inputData.Length - 2);
            base.Parse(s);

            Category category;
            Type type;
            if (Enum.TryParse(inputData[5], out category) && Enum.TryParse(inputData[6], out type))
            {
                CategoryField = category;
                TypeField = type;
            }
            else
                throw new ArgumentException("Category or type are incorrect");
        }
    }
}
