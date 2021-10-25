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
            //Standarts mark-up per category
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
            if (obj.GetType().Name == typeof(Meat).Name)
            {
                Meat meat = (Meat)obj;
                if (meat.Name == Name && meat.Price == Price && meat.Weight == Weight && meat.ExpirationDate == ExpirationDate &&
                    meat.CreateDateTime == CreateDateTime && meat.CategoryField == CategoryField && meat.TypeField == TypeField)
                    return true;
            }

            return false;
        }

        public override int GetHashCode() => nameof(Meat).GetHashCode() + ToString().GetHashCode();

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

        //Summary:
        //    Initialize object with data fro string
        //Exceptions:
        //    ArgumentException
        public static new Meat Parse(string s)
        {
            string[] inputData = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputData.Length < 7)
                throw new ArgumentException("Data is incorrect");

            Product baseProduct = Product.Parse(string.Join(" ", inputData, 0, inputData.Length - 2));

            Category category;
            Type type;
            if (!Enum.TryParse(inputData[5], out category) || !Enum.TryParse(inputData[6], out type) || 
                !Enum.IsDefined(typeof(Category), category) || !Enum.IsDefined(typeof(Type), type))
                throw new ArgumentException("Category or type are incorrect");

            return new Meat(baseProduct.Name, baseProduct.Price, baseProduct.Weight, baseProduct.ExpirationDate, baseProduct.CreateDateTime, category, type);
        }
    }
}
