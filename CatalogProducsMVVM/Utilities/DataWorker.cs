using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogProducsMVVM.Utilities
{
    public static class DataWorker
    {
        public static List<Product> GetAllProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Products.ToList();
                return result;
            }
        }
        public static List<Category> GetAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Categories.ToList();
                return result;
            }
        }
    }
}
