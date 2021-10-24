using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;

namespace Task1
{
    //Summary:
    //    Contains data about product
    class Product
    {
        private string _name;
        private double _price;
        private double _weight;
        private int _expirationDate;
        private DateTime _createDateTime;

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("The product name cannot be empty");
                else
                    _name = value;
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product price cannot be <= 0");
                else
                    _price = value;
            }
        }
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("The product weight cannot be <= 0");
                else
                    _weight = value;
            }
        }
        public int ExpirationDate
        {
            get
            {
                return _expirationDate;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid expiration date");
                else
                    _expirationDate = value;
            }
        }
        public DateTime CreateDateTime
        {
            get
            {
                return _createDateTime;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Create date time cannot be null");
                else
                    _createDateTime = value;
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

        public override bool Equals(object obj)
        {
            if (obj.GetType().Name == typeof(Product).Name)
            {
                Product product = (Product)obj;
                if (product.Name == Name && product.Price == Price && product.Weight == Weight && product.ExpirationDate == ExpirationDate && product.CreateDateTime == CreateDateTime)
                    return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return typeof(Product).Name.GetHashCode() + ToString().GetHashCode();
        }

        public override string ToString()
        {
            string info = $"Name: {Name} Price: {Price} Weight: {Weight} Expiration date: {ExpirationDate} " +
                $"Create date: {CreateDateTime.Day}.{CreateDateTime.Month}.{CreateDateTime.Year}";

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
        //    Initialize object with data from string
        //Exceptions:
        //    ArgumentException
        public static Product Parse(string s)
        {
            string[] inputData = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputData.Length < 5)
                throw new ArgumentException("Data is incorrect");

            string name = "";
            double price, weight;
            int expirationDate, index;
            DateTime createDateTime;

            for (index = 0; index < inputData.Length - 4; index++)
                name += inputData[index];

            if (!Double.TryParse(inputData[index++], out price)) throw new ArgumentException("Price is incorrect");
            if (!Double.TryParse(inputData[index++], out weight)) throw new ArgumentException("Weight is incorrect");
            if (!Int32.TryParse(inputData[index++], out expirationDate)) throw new ArgumentException("Expiration date is incorrect");

            //string[] dateList = inputData[index++].Split(".", StringSplitOptions.RemoveEmptyEntries);
            if (!DateTime.TryParseExact(inputData[index++], "d.M.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out createDateTime))
                throw new ArgumentException("Creation date time is incorrect");

            return new Product(name, price, weight, expirationDate, createDateTime);
        }
    }
}
