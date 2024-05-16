using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;

namespace CatalogProductsMVVM.ViewModel
{
    public class CatalogViewModel : ViewModelBase
    {
        private readonly Product _product;        
        public string Title {
            get => _product.Title;
            set { OnPropertyChanged(nameof(Title)); }
        }
        public decimal Cost {
            get => _product.Cost;
            set { OnPropertyChanged(nameof(Cost)); }
        }
        public string Photo {
            get => _product.Photo;
            set { OnPropertyChanged(nameof(Photo)); }
        }
        public string Description {
            get => _product.Photo;
            set { OnPropertyChanged(nameof(Description)); }
        }
        public string Quantity {
            get => _product.Photo;
            set { OnPropertyChanged(nameof(Quantity)); }
        }
        public string Producer {
            get => _product.Photo;
            set { OnPropertyChanged(nameof(Producer)); }
        }


        public CatalogViewModel(Product product)
        {
            _product = product;
        }


    }
}
