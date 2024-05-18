using CatalogProducsMVVM;
using CatalogProducsMVVM.Utilities;
using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace CatalogProductsMVVM.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {

        #region PROPERTIES

        private readonly Product? _products;        
        public string? Title {
            get => _products?.Title;
            set { OnPropertyChanged(nameof(Title)); }
        }
        public decimal Cost {
            get => (_products?.Cost) ?? 0;
            set { OnPropertyChanged(nameof(Cost)); }
        }
        public string? Photo {
            get => _products?.Photo;
            set { OnPropertyChanged(nameof(Photo)); }
        }
        public string? Description {
            get => _products?.Description;
            set { OnPropertyChanged(nameof(Description)); }
        }
        public int? Quantity {
            get => _products?.Quantity;
            set { OnPropertyChanged(nameof(Quantity)); }
        }
        public string? Producer {
            get => _products?.Producer;
            set { OnPropertyChanged(nameof(Producer)); }
        }

        private ObservableCollection<Product> allProducts = DataWorker.GetAllProducts();
        public ObservableCollection<Product> AllProducts
        {
            get => allProducts;
            set { allProducts = value; OnPropertyChanged(nameof(AllProducts)); }
        }

        private ObservableCollection<Category> allCategories = DataWorker.GetAllCategories();
        public ObservableCollection<Category> AllCategories
        {
            get => allCategories;
            set { allCategories = value; OnPropertyChanged(nameof(AllCategories)); }
        }

        #endregion


        public CatalogViewModel(Product product)
        {
            _products = product;
            LoadData();
        }

        private List<Product> GetAllProducts()
        {
            ApplicationContext db = new ApplicationContext();

            return db.Products
                .Include(p => p.Category)
                .Select(p => new Product
                {
                    Title = p.Title,
                    Cost = p.Cost,
                    Photo = p.Photo,
                    Description = p.Description,
                    Quantity = p.Quantity,
                    Producer = p.Producer
                    //Category = p.CategoryId
                })
                .ToList();
        }

        private void LoadData()
        {
            
            GetAllProducts();
        }
    }
}
