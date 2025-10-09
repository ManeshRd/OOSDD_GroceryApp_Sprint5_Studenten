using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(ProductCategory), nameof(ProductCategory))]
    public partial class ProductCategoryViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private readonly IFileSaverService _fileSaverService;
        private string searchText = "";

        public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];
        public ObservableCollection<Product> CategoryProducts { get; set; } = [];

        [ObservableProperty]
        ProductCategory productCategory;

        [ObservableProperty]
        string myMessage;

        public ProductCategoryViewModel(IProductCategoryService productCategoryService, IProductService productService, IFileSaverService fileSaverService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            _fileSaverService = fileSaverService;
            LoadCategories();
        }

        private void LoadCategories()
        {
            ProductCategories.Clear();
            foreach (var category in _productCategoryService.GetAll())
                ProductCategories.Add(category);
        }

        /*private void LoadProductsForCategory(int categoryId)
        {
            CategoryProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (p.ProductCategoryId == categoryId && p.Stock > 0 && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                    CategoryProducts.Add(p);
        }*/

        /*partial void OnProductCategoryChanged(ProductCategory value)
        {
            if (value != null)
                LoadProductsForCategory(value.Id);
        }*/

        [RelayCommand]
        public async Task ChangeColor()
        {
            Dictionary<string, object> parameter = new() { { nameof(ProductCategory), ProductCategory } };
            await Shell.Current.GoToAsync($"{nameof(ChangeColorView)}?Name={ProductCategory.Name}", true, parameter);
        }

        [RelayCommand]
        public async Task AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName)) return;

            ProductCategory newCategory = new(0, "None", 0, 0);
            _productCategoryService.Add(newCategory);
            ProductCategories.Add(newCategory);
            await Toast.Make("Categorie toegevoegd.").Show();
        }

        [RelayCommand]
        public async Task DeleteCategory(ProductCategory category)
        {
            if (category == null) return;

            //_productCategoryService.Delete();
            ProductCategories.Remove(category);
            await Toast.Make("Categorie verwijderd.").Show();
        }

        [RelayCommand]
        public async Task ShareCategories(CancellationToken cancellationToken)
        {
            if (ProductCategories == null || ProductCategories.Count == 0) return;

            string jsonString = JsonSerializer.Serialize(ProductCategories);
            try
            {
                await _fileSaverService.SaveFileAsync("Categorieën.json", jsonString, cancellationToken);
                await Toast.Make("Categorieën zijn opgeslagen.").Show(cancellationToken);
            }
            catch (Exception ex)
            {
                await Toast.Make($"Opslaan mislukt: {ex.Message}").Show(cancellationToken);
            }
        }

        /*[RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            if (ProductCategory != null)
                LoadProductsForCategory(ProductCategory.Id);
        }*/

        [RelayCommand]
        public async Task UpdateCategory(ProductCategory category)
        {
            if (category == null) return;

            _productCategoryService.Update(category);
            await Toast.Make("Categorie bijgewerkt.").Show();
        }
    }
}