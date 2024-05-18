using CatalogProductsMVVM.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace CatalogProducsMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ItemsControl? AllProductsView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            AllProductsView = ViewAllProducts;
        }
    }
}