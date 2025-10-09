using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productcategories;
        public ProductCategoryRepository()
        {
            productcategories = [
                new ProductCategory(1, 1, 1),
                new ProductCategory(2, 2, 1),
                new ProductCategory(3, 3, 2),
                new ProductCategory(4, 4, 3)
                ];
        }
        public List<ProductCategory> GetAll()
        {
            return productcategories;
        }

        public ProductCategory? Get(int id)
        {
            return productcategories.FirstOrDefault(p => p.Id == id);
        }

        public ProductCategory Add(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Delete(ProductCategory item)
        {
            throw new NotImplementedException();
        }

        public ProductCategory? Update(ProductCategory item)
        {
            ProductCategory? productcategory = productcategories.FirstOrDefault(p => p.Id == item.Id);
            if (productcategory == null) return null;
            productcategory.Id = item.Id;
            return productcategory;
        }
    }
}
