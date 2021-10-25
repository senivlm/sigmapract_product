using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Task1
{
    //Summary:
    //    Class contains Products in Storage
    class Storage
    {Лінки в цій задачі - це те, що треба
        public event Action<Storage> OnShow;
        public event Action<Storage, string> OnWrongInput;

        private List<Product> _products;
        public List<Product> Products
        {
            get
            {
                return new List<Product>(_products);
            }
        }

        public Product this[int index]
        {
            get
            {
                if (index < 0 || index >= _products.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                return _products[index];
            }
            set
            {
                if (index < 0 || index >= _products.Count)
                    throw new IndexOutOfRangeException("Index out of range");
                if (value == null)
                    throw new ArgumentNullException("Product cannot be null");
                _products[index] = value;
            }
        }

        public Storage()
        {
            _products = new List<Product>();
        }

        //Summary:
        //    Fills Storage with Products from input string
        //Exceptions:
        //    ArgumentException
        public void ReadInput(string input)
        {
            _products.Clear();

            using (StringReader inputStringReader = new StringReader(input))
            {
                int productsCount;
                if (!Int32.TryParse(inputStringReader.ReadLine(), out productsCount))
                    throw new ArgumentException("Incorrect Products count");

                for (int i = 0; i < productsCount; i++)
                {
                    int productsType = Convert.ToInt32(inputStringReader.ReadLine());

                    string productInfo;
                    if (inputStringReader.Peek() != -1)
                        productInfo = inputStringReader.ReadLine();
                    else
                        return;

                    try
                    {
                        switch (productsType)
                        {
                            case 1:
                                _products.Add(Meat.Parse(productInfo));
                                break;
                            case 2:
                                _products.Add(Dairy_products.Parse(productInfo));
                                break;
                            case 3:
                                _products.Add(Product.Parse(productInfo));
                                break;
                        }
                    }
                    catch (ArgumentException exception)
                    {
                        OnWrongInput?.Invoke(this, productInfo + "\nError: " + exception.Message);
                    }
                }
            }
        }

        public void AddProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException("Cannot add. Product is null");

            _products.Add(product);
        }

        public void AddProducts(List<Product> products)
        {
            if (products == null) throw new ArgumentNullException("Cannot add. Products list is null");

            foreach (Product elem in products)
                AddProduct(elem);
        }

        public bool RemoveProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException("Cannot remove. Product is null");

            return _products.Remove(product);
        }

        public int RemoveProductsByName(string name)
        {
            if (name == null) throw new ArgumentNullException("Cannot remove. Name is null");

            return _products.RemoveAll(elem => elem.Name == name);
        }

        public int RemoveProducts(Predicate<Product> match)
        {
            if (match == null) throw new ArgumentNullException("Cannot remove. Predicate is null");

            return _products.RemoveAll(match);
        }

        public void RemoveAllProducts() => _products.Clear();

        //Summary:
        //    Finds T-type products in Products list
        //Returns:
        //    List of T-type product
        public List<T> FindProducts<T>() where T : Product => _products.FindAll(product => product.GetType() == typeof(T)).Select(elem => elem as T).ToList();

        //Summary:
        //    Finds overdue products list
        //Returns:
        //    List of overdue products
        public List<Product> OverdueProducts() => _products.FindAll(elem => elem.CreateDateTime.AddDays(elem.ExpirationDate) < DateTime.Now);

        //Summary:
        //    Change price for all Products
        //Exceptions:
        //    ArgumentException
        public void ChangePrice(double percent)
        {
            foreach (var elem in _products)
                elem.ChangePrice(percent);
        }

        public override string ToString()
        {
            string output = "Storage:";

            for (int i = 0; i < _products.Count; i++)
                output += $"\nProduct {i + 1}: Type: {this[i].GetType().Name}\n" + this[i].ToString();

            return output;
        }

        //Summary:
        //    Print all Products data
        //Returns:
        //    String with Products data
        public string Print()
        {
            OnShow?.Invoke(this);
            return ToString();
        }
    }
}
