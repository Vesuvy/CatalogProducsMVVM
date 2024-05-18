using CatalogProductsMVVM.ViewModel;
using System.ComponentModel;
using System.Windows.Controls;

namespace CatalogProductsMVVM.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogUserControl.xaml
    /// </summary>
    public partial class CatalogUserControl : UserControl
    {
        public CatalogUserControl()
        {
            InitializeComponent();
        }

        /*public CatalogUserControl()
        {
            InitializeComponent();
            DataContextChanged += (sender, args) =>
            {
                if (DataContext is CatalogViewModel viewModel)
                {
                    // Subscribe to the PropertyChanged event of the Product
                    viewModel.Product.PropertyChanged += Product_PropertyChanged;
                }
            };
        }

        private void Product_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Update the UI when the Product properties change
            this.InvalidateVisual();
        }*/
    }
}
