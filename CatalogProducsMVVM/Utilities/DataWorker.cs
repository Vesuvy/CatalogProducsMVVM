using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;
using System.Collections.ObjectModel;

namespace CatalogProducsMVVM.Utilities
{
    public static class DataWorker
    {
        public static ObservableCollection<Product> GetAllProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Products.ToList();
                return new ObservableCollection<Product>(result);
            }
        }
        public static ObservableCollection<Category> GetAllCategories()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Categories.ToList();
                return new ObservableCollection<Category>(result);
            }
        }
    }
}
