namespace Grocery.App.Views
{
    public partial class ProductCategoryView : ContentPage
    {
        public ProductCategoryView(ProductCategoryView viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
