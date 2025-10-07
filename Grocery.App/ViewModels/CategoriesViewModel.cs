using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private readonly ICategoryService _categoryService;
        public ObservableCollection<Category> Categories { get; set; }

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = [];
            foreach (Category p in _categoryService.GetAll()) Categories.Add(p);
        }
    }
}
