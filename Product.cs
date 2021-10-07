using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains data about product
    class Product
    {
        private string name;
        private double price;
        private double weight;
        private int expirationDate;
        private DateTime createDateTime;

        public string Name {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The product name cannot be empty");
                else
                    name = value;
            }
        }
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product price cannot be <= 0");
                else
                    price = value;
            }
        }
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product weight cannot be <= 0");
                else
                    weight = value;
            }
        }

        public int ExpirationDate
        {
            get
            {
                return expirationDate;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid expiration date");
                else
                    expirationDate = value;
            }
        }

        public DateTime CreateDateTime
        {
            get
            {
                return createDateTime;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Create date time cannot be null");
                else
                    createDateTime = value;
            }
        }

        //Exceptions:
        //    ArgumentException
        //    ArgumentNullException
        public Product(string name, double price, double weight, int expirationDate, DateTime dateTime)
        {
            Name = name;
            Price = price;
            Weight = weight;
            ExpirationDate = expirationDate;
            CreateDateTime = dateTime;
        }

        //Summary:
        //    Checks if name both Product are the same
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Product))
            {
                Product product = (Product)obj;
                if (product.Name == Name)
                    return true;
            }

            return false;
        }

        public override string ToString()
        {
            string info = $"Name: {Name} Price: {Price} Weight: {Weight} Expiration date: {ExpirationDate} " +
                $"Create date: {CreateDateTime.Day}.{CreateDateTime.Month}.{CreateDateTime.Year}\n";

            return info;
        }

        //Exceptions:
        //    ArgumentException
        virtual public void ChangePrice(double percent)
        {
            if ((percent <= -100) && (int.MaxValue / Price) <= (percent / 100))
                throw new ArgumentException("Percent is too small or too large");
            else
                Price *= 1 + percent / 100;
        }

        //Summary:
        //    Initialize object with data fro string
        //Exceptions:
        //    ArgumentException
        virtual public void Parse(string s)
        {
            string[] inputData = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputData.Length != 5)
                throw new ArgumentException("Data in line is incorrect");

            Name = inputData[0];
            Price = Convert.ToDouble(inputData[1]);
            Weight = Convert.ToDouble(inputData[2]);
            ExpirationDate = Convert.ToInt32(inputData[3]);

            string[] dateList = inputData[4].Split(".");
            CreateDateTime = new DateTime(Convert.ToInt32(dateList[2]), Convert.ToInt32(dateList[1]), Convert.ToInt32(dateList[0]));
        }
    }
}
