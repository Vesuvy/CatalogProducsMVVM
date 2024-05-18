using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CatalogProducsMVVM;
using CatalogProducsMVVM.Utilities;
using CatalogProductsMVVM.Model;
using CatalogProductsMVVM.Utilities;
using CatalogProductsMVVM.View;

namespace CatalogProductsMVVM.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region PROPERTIES:

        // Списки с сортировкой и фильтрацией
        public ObservableCollection<string> SortOptions { get; set; } = 
            new ObservableCollection<string> { "-", "Title", "Cost" };
        public ObservableCollection<string> Producers { get; set; } = 
            new ObservableCollection<string> { "-", "Hasbro", "Nvidia", "Добрый", "Школа666" }; 

        private ObservableCollection<Product> _originalProducts;

        private ObservableCollection<Product>? _products;
        public ObservableCollection<Product>? Products {
            get => _products;
            set { _products = value; OnPropertyChanged(nameof(Products)); }
        }

        private string? _searchText;
        public string? SearchText {
            get => _searchText;
            set {
                _searchText = value; 
                OnPropertyChanged(nameof(SearchText));
                SearchProducts();
            }
        }

        private string? _selectedSortOption;
        public string? SelectedSortOption
        {
            get => _selectedSortOption;
            set { 
                _selectedSortOption = value; 
                OnPropertyChanged(nameof(SelectedSortOption));
                SortProducts();
            }
        }

        private string? _selectedFilterProducer;
        public string? SelectedFilterProducer
        {
            get => _selectedFilterProducer;
            set {
                _selectedFilterProducer = value;
                OnPropertyChanged(nameof(SelectedFilterProducer));
                FilterProducts();
            }
        }

        // View Model'ы
        private ObservableCollection<CatalogViewModel> _catalogViewModels;
        public ObservableCollection<CatalogViewModel> CatalogViewModels
        {
            get => _catalogViewModels;
            set { _catalogViewModels = value; OnPropertyChanged(nameof(CatalogViewModels)); }
        }

        #endregion

        public MainWindowViewModel()
        {
            //Products = new List<Product>();
            //Products = DataWorker.GetAllProducts();
            //UpdateAllUserControlList();
            LoadPorducts();
            //_catalogUserControls = 
        }
        private void LoadPorducts()
        {
            _originalProducts = DataWorker.GetAllProducts();
            Products = new ObservableCollection<Product>(_originalProducts);
            UpdateCatalogViewModels();
        }

        private void SearchProducts()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Products = new ObservableCollection<Product>(_originalProducts);
            }
            else
            {
                var filteredProducts = _originalProducts
                    .Where(p => p.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                Products = new ObservableCollection<Product>(filteredProducts);
            }
            UpdateCatalogViewModels();
        }
        private void SortProducts()
        {

            switch (SelectedSortOption)
            {
                case "Title":
                    var sortedProductsByTitle = Products.OrderBy(p => p.Title).ToList();
                    Products.Clear();
                    foreach (var product in sortedProductsByTitle)
                    {
                        Products.Add(product);
                    }
                    break;

                case "Cost":
                    var sortedProductsByCost = Products.OrderBy(p => p.Cost).ToList();
                    Products.Clear();
                    foreach (var product in sortedProductsByCost)
                    {
                        Products.Add(product);
                    }
                    break;

                case "-":
                    Products = _originalProducts;
                    break;
            }
            UpdateCatalogViewModels();
        }
        private void FilterProducts()
        {

            if (string.IsNullOrEmpty(SelectedFilterProducer))
            {
                Products = new ObservableCollection<Product>(_originalProducts);
            }
            else
            {
                var filteredProducts = _originalProducts
                    .Where(p => p.Producer == SelectedFilterProducer)
                    .ToList();
                Products = new ObservableCollection<Product>(filteredProducts);
            }
            UpdateCatalogViewModels();
        }
        private void UpdateCatalogViewModels()
        {
            CatalogViewModels = new ObservableCollection<CatalogViewModel>(Products.Select(p => new CatalogViewModel(p)));
        }
    }
}
