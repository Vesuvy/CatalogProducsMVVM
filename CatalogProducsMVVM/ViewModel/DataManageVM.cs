using CatalogProducsMVVM.Utilities;
using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogProducsMVVM.ViewModel
{
    public class DataManageVM : ViewModelBase
    {
        private List<Product> allProducts = DataWorker.GetAllProducts();
        public List<Product> AllProducts
        {
            get => allProducts;
            set { allProducts = value; OnPropertyChanged(nameof(AllProducts)); }
        }

        private List<Category> allCategories = DataWorker.GetAllCategories();
        public List<Category> AllCategories
        {
            get => allCategories;
            set { allCategories = value; OnPropertyChanged(nameof(AllCategories)); }
        }
    }
}
