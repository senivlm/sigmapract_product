using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Task1
{
    class StorageSearcher
    {
        public List<Product> GetJointProducts(Storage storage1, Storage storage2)
        {
            if (storage1 == null) throw new ArgumentNullException("First Storage is null");
            if (storage2 == null) throw new ArgumentNullException("Second Storage is null");

            return storage1.Products.Intersect(storage2.Products).ToList();
        }

        public List<Product> GetProductsExcept(Storage storage1, Storage storage2)
        {
            if (storage1 == null) throw new ArgumentNullException("First Storage is null");
            if (storage2 == null) throw new ArgumentNullException("Second Storage is null");

            return storage1.Products.Except(storage2.Products).ToList();
        }

        public List<Product> GetDifferentProducts(Storage storage1, Storage storage2)
        {
            if (storage1 == null) throw new ArgumentNullException("First Storage is null");
            if (storage2 == null) throw new ArgumentNullException("Second Storage is null");

            return storage1.Products.Union(storage2.Products).Except(GetJointProducts(storage1, storage2)).ToList();
        }
    }
}
